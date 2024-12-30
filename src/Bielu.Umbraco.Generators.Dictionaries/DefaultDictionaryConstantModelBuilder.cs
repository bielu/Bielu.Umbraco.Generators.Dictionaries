using System.Text;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Services;
using File = System.IO.File;

namespace Bielu.Umbraco.Generators.Dictionaries;

public class DefaultDictionaryConstantModelBuilder(ILocalizationService localizationService)
    : IDictionaryConstantModelBuilder
{
    public async Task BuildAsync(IEnumerable<IDictionaryItem> dictionaryItems)
    {
        var dictionaryConstantModelText = await GenerateDictionaryConstantModelText(dictionaryItems);

        var dictionaryConstantModelFilePath =
            Path.Combine(Directory.GetCurrentDirectory(), "Models", $"Dictionaries.cs");
        await File.WriteAllTextAsync(dictionaryConstantModelFilePath, dictionaryConstantModelText);
    }

    private async Task<string> GenerateDictionaryConstantModelText(IEnumerable<IDictionaryItem> dictionaryItems)
    {
        var dictionaryConstantModelText = new StringBuilder();

        dictionaryConstantModelText.AppendLine("namespace Bielu.Umbraco.Generators.Dictionaries.Models;");
        dictionaryConstantModelText.AppendLine("public static class Dictionaries");
        dictionaryConstantModelText.AppendLine("{");
        foreach (var dictionaryItem in dictionaryItems)
        {
            await GenerateDictionaryAsync(dictionaryConstantModelText, dictionaryItem);
        }

        dictionaryConstantModelText.AppendLine("}");

        return dictionaryConstantModelText.ToString();
    }

    private const string SpacerTemplate = "    ";

    private async Task GenerateDictionaryAsync(StringBuilder stringBuilder, IDictionaryItem dictionary, int lvl = 0)
    {
        stringBuilder.AppendLine("public static class ExampleDictionary");
        AppendSpacer(stringBuilder, lvl + 1);
        stringBuilder.AppendLine($"{{");
        AppendSpacer(stringBuilder, lvl + 2);
        stringBuilder.AppendLine($"public const string Alias = \"{dictionary.ItemKey}\";");
        AppendSpacer(stringBuilder, lvl + 2);
        stringBuilder.AppendLine($"public static readonly Guid Key = new Guid(\"{dictionary.Key}\");");
        AppendSpacer(stringBuilder, lvl + 2);
        stringBuilder.AppendLine($"public const int Id = {dictionary.Id};");
        AppendSpacer(stringBuilder, lvl + 2);
        stringBuilder.AppendLine($"//SubDictionaries of level {lvl + 1} (if any)");

        foreach (var dictionaryItem in localizationService.GetDictionaryItemChildren(dictionary.Key).ToList())
        {
            await GenerateDictionaryAsync(stringBuilder, dictionaryItem, lvl + 1);
        }

        AppendSpacer(stringBuilder, lvl + 1);
        stringBuilder.AppendLine("}");
    }

    private static void AppendSpacer(StringBuilder stringBuilder, int lvl)
    {
        for (var i = 0; i < lvl; i++)
        {
            stringBuilder.Append(SpacerTemplate);
        }
    }
}
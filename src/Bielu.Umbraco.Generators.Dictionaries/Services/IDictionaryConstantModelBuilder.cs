using Umbraco.Cms.Core.Models;
//todo: adjust namespace in v2
// ReSharper disable once CheckNamespace
namespace Bielu.Umbraco.Generators.Dictionaries;

public interface IDictionaryConstantModelBuilder
{
    public Task BuildAsync(IEnumerable<IDictionaryItem> dictionaryItems);
}

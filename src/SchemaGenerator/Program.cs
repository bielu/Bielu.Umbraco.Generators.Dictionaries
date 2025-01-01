using System.Reflection;
using bielu.SchemaGenerator.Build.Configuration;
using bielu.SchemaGenerator.Build.Services;
using Bielu.Umbraco.Generators.Dictionaries.Configuration;
using CommandLine;

namespace SchemageGerator;

internal static class Program
{
    private static readonly IList<Assembly> _assemblies = new List<Assembly>()
    {
        typeof(BieluDictionariesUmbracoSchemaDefinition).Assembly
    };

    public static async Task Main(string[] args)
    {
        try
        {
            await Parser.Default.ParseArguments<Options>(args)
                .WithParsedAsync(Execute);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    private static Task Execute(Options options)
    {
        Console.WriteLine("Schema generator v {0}", typeof(SchemaGeneratorService).Assembly.GetName().Version?.ToString());


        var schemaGenerator = new SchemaGeneratorService(new SchemaGenerator(), options);
        schemaGenerator.GenerateSchema(_assemblies);

        Console.WriteLine("Schema generator v {0}", typeof(SchemaGeneratorService).Assembly.GetName().Version?.ToString());
        return Task.CompletedTask;
    }
}

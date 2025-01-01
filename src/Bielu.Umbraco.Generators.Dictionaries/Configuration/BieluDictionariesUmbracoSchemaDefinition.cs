using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;
using bielu.SchemaGenerator.Core.Attributes;
[assembly: InternalsVisibleTo("SchemaGenerator")]
namespace Bielu.Umbraco.Generators.Dictionaries.Configuration;

[SchemaGeneration]
internal class BieluDictionariesUmbracoSchemaDefinition
{
    [SchemaPrefix]
    [JsonIgnore]
    public const string SectionName = BieluDictionariesModelsBuilderOptions.SectionName;
    public UmbracoDefition? Umbraco { get; set; }
    internal class UmbracoDefition
    {
        public UmbracoCmsDefinition? Cms { get; set; }
        internal class UmbracoCmsDefinition
        {
            public UmbracoModelsBuilderDefinition? ModelsBuilder { get; set; }
            internal class UmbracoModelsBuilderDefinition
            {
                public BieluDictionariesModelsBuilderOptions? Dictionaries { get; set; }
            }
        }
    }
}

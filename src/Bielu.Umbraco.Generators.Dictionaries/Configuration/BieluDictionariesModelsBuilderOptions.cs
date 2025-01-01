using System.Text.Json.Serialization;

namespace Bielu.Umbraco.Generators.Dictionaries.Configuration;
public class BieluDictionariesModelsBuilderOptions
{
    public bool Enabled { get; set; }
    [JsonIgnore]
    public const string  SectionName = "Umbraco:CMS:ModelsBuilder:Dictionaries";
    public string? ConstantsNamespace { get; set; }
    public string? ConstantsClassName { get; set; }
    public string? ConstantsOutputDirectory { get; set; }
    public bool IncludeGuids { get; set; } = true;
    public bool IncludeIds { get; set; } = true;
}

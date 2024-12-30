using Umbraco.Cms.Core.Models;

namespace Bielu.Umbraco.Generators.Dictionaries;

public interface IDictionaryConstantModelBuilder
{
    public Task BuildAsync(IEnumerable<IDictionaryItem> dictionaryItems);
}
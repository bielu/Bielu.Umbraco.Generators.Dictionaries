using Umbraco.Cms.Core.Events;
using Umbraco.Cms.Core.Notifications;
using Umbraco.Cms.Core.Services;

namespace Bielu.Umbraco.Generators.Dictionaries.NotificationHandlers;

// ReSharper disable once ClassNeverInstantiated.Global
public class DictionaryNotificationsHandler(
    ILocalizationService localizationService,
    IDictionaryConstantModelBuilder dictionaryConstantModelBuilder)
    : INotificationAsyncHandler<DictionaryItemSavedNotification>,
        INotificationAsyncHandler<DictionaryItemDeletedNotification>
{
    public async Task HandleAsync(DictionaryItemSavedNotification notification, CancellationToken cancellationToken)
    {
        var dictionaries = localizationService.GetRootDictionaryItems();
        await dictionaryConstantModelBuilder.BuildAsync(dictionaries);
    }

    public async Task HandleAsync(DictionaryItemDeletedNotification notification, CancellationToken cancellationToken)
    {
        var dictionaries = localizationService.GetRootDictionaryItems();
        await dictionaryConstantModelBuilder.BuildAsync(dictionaries);
    }
}
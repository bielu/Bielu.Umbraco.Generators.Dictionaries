using Bielu.Umbraco.Generators.Dictionaries.NotificationHandlers;
using Microsoft.Extensions.DependencyInjection;
using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DependencyInjection;
using Umbraco.Cms.Core.Notifications;
using Umbraco.Extensions;

namespace Bielu.Umbraco.Generators.Dictionaries.Composition;

public class DictionaryModelsBuilderComposer : IComposer
{
    public void Compose(IUmbracoBuilder builder)
    {
        builder.Services.AddUnique<IDictionaryConstantModelBuilder, DefaultDictionaryConstantModelBuilder>(ServiceLifetime.Transient);
        builder.AddNotificationAsyncHandler<DictionaryItemDeletedNotification, DictionaryNotificationsHandler>()
            .AddNotificationAsyncHandler<DictionaryItemSavedNotification, DictionaryNotificationsHandler>()
            .AddNotificationAsyncHandler<UmbracoApplicationStartingNotification, DictionaryNotificationsHandler>()
            .AddNotificationAsyncHandler<UmbracoRequestEndNotification, DictionaryNotificationsHandler>()
            .AddNotificationAsyncHandler<ContentTypeCacheRefresherNotification, DictionaryNotificationsHandler>()
            .AddNotificationAsyncHandler<DataTypeCacheRefresherNotification, DictionaryNotificationsHandler>();
    }
}
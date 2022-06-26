using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace GeorgeVlad.TicketingSystem.Localization
{
    public static class TicketingSystemLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(TicketingSystemConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(TicketingSystemLocalizationConfigurer).GetAssembly(),
                        "GeorgeVlad.TicketingSystem.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}

using System.Collections.Generic;

namespace GeorgeVlad.TicketingSystem.Authentication.External
{
    public interface IExternalAuthConfiguration
    {
        List<ExternalLoginProviderInfo> Providers { get; }
    }
}

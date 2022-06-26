using GeorgeVlad.TicketingSystem.Debugging;

namespace GeorgeVlad.TicketingSystem
{
    public class TicketingSystemConsts
    {
        public const string LocalizationSourceName = "TicketingSystem";

        public const string ConnectionStringName = "Default";

        public const bool MultiTenancyEnabled = true;


        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public static readonly string DefaultPassPhrase =
            DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "d61b4f30e4d148de921d23c9d3d8e416";
    }
}

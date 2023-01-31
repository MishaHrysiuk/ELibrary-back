using ELibrary.Debugging;

namespace ELibrary
{
    public class ELibraryConsts
    {
        public const string LocalizationSourceName = "ELibrary";

        public const string ConnectionStringName = "Default";

        public const string DefaultArenaName = "ArenaDefault";

        public const int DefaultArenaCapacity = 100;

        public const bool MultiTenancyEnabled = true;

        /// <summary>
        /// Maximum allowed page size for paged requests.
        /// </summary>
        public const int MaxPageSize = 1000;

        /// <summary>
        /// Default page size for paged requests.
        /// </summary>
        public const int DefaultPageSize = 10;

        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public static readonly string DefaultPassPhrase =
            DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "ba9ca8a2b2a14dc9a8b55e0ed1faae03";
    }
}

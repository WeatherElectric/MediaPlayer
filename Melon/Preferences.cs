using MelonLoader;

namespace MediaPlayer.Melon
{
    internal static class Preferences
    {
        public static MelonPreferences_Category category = MelonPreferences.CreateCategory("Media Player");

        public static ModPref<LoggingMode> loggingMode;
        public static ModPref<bool> notificationsEnabled;
        

        public static void Setup()
        {
            loggingMode = new ModPref<LoggingMode>(category, "LoggingMode", LoggingMode.NORMAL, "Logging Mode", "The logging mode for the mod. DEBUG will show all messages, NORMAL will show all messages except DEBUG messages.");
            notificationsEnabled = new ModPref<bool>(category, "NotificationsEnabled", true, "Notifications Enabled", "Whether or not to show notifications when a song changes.");
            
            category.SaveToFile(false);
            ModConsole.Msg("Finished preferences setup", LoggingMode.DEBUG);
        }
    }
}
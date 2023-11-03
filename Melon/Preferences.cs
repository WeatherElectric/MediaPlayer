using MelonLoader;

namespace MediaPlayer.Melon
{
    internal static class Preferences
    {
        public static readonly MelonPreferences_Category Category = MelonPreferences.CreateCategory("Media Player");

        public static ModPref<LoggingMode> LoggingMode;
        public static ModPref<bool> NotificationsEnabled;
        

        public static void Setup()
        {
            LoggingMode = new ModPref<LoggingMode>(Category, "LoggingMode", global::LoggingMode.NORMAL, "Logging Mode", "The logging mode for the mod. DEBUG will show all messages, NORMAL will show all messages except DEBUG messages.");
            NotificationsEnabled = new ModPref<bool>(Category, "NotificationsEnabled", true, "Notifications Enabled", "Whether or not to show notifications when a song changes.");
            
            Category.SaveToFile(false);
            ModConsole.Msg("Finished preferences setup", global::LoggingMode.DEBUG);
        }
    }
}
using MelonLoader;

namespace MediaPlayer.Melon
{
    internal static class Preferences
    {
        public static readonly MelonPreferences_Category GlobalCategory = MelonPreferences.CreateCategory("Global");
        public static readonly MelonPreferences_Category Category = MelonPreferences.CreateCategory("Media Player");

        public static ModPref<LoggingMode> loggingMode;
        public static ModPref<bool> NotificationsEnabled;
        

        public static void Setup()
        {
            loggingMode = new ModPref<LoggingMode>(GlobalCategory, "loggingMode", LoggingMode.NORMAL, "Logging Mode", "The level of logging to use. DEBUG = Everything, NORMAL = Important Only");
            NotificationsEnabled = new ModPref<bool>(Category, "NotificationsEnabled", true, "Notifications Enabled", "Whether or not to show notifications when a song changes.");
            GlobalCategory.SetFilePath(MelonUtils.UserDataDirectory+"/WeatherElectric.cfg");
            GlobalCategory.SaveToFile(false);
            Category.SetFilePath(MelonUtils.UserDataDirectory+"/WeatherElectric.cfg");
            Category.SaveToFile(false);
            ModConsole.Msg("Finished preferences setup", LoggingMode.DEBUG);
        }
    }
}
using MelonLoader;

namespace MediaPlayer.Melon
{
    internal static class Preferences
    {
        public static readonly MelonPreferences_Category GlobalCategory = MelonPreferences.CreateCategory("Global");
        public static readonly MelonPreferences_Category OwnCategory = MelonPreferences.CreateCategory("Media Player");
        
        public static MelonPreferences_Entry<int> loggingMode { get; set; }
        public static MelonPreferences_Entry<bool> NotificationsEnabled { get; set; }

        public static void Setup()
        {
            loggingMode = GlobalCategory.GetEntry<int>("LoggingMode") ?? GlobalCategory.CreateEntry("LoggingMode", 0, "Logging Mode", "The level of logging to use. 0 = Important Only, 1 = All");
            NotificationsEnabled = OwnCategory.CreateEntry("NotificationsEnabled", true, "Notifications Enabled", "Whether or not to show notifications when a new song plays");
            GlobalCategory.SetFilePath(MelonUtils.UserDataDirectory+"/WeatherElectric.cfg");
            GlobalCategory.SaveToFile(false);
            OwnCategory.SetFilePath(MelonUtils.UserDataDirectory+"/WeatherElectric.cfg");
            OwnCategory.SaveToFile(false);
            ModConsole.Msg("Finished preferences setup for MODNAMEHERE", 1);
        }
    }
}
namespace MediaPlayer.Melon;

internal static class Preferences
{
    private static readonly MelonPreferences_Category GlobalCategory = MelonPreferences.CreateCategory("Global");
    public static readonly MelonPreferences_Category OwnCategory = MelonPreferences.CreateCategory("Media Player");
        
    public static MelonPreferences_Entry<int> LoggingMode { get; private set; }
    public static MelonPreferences_Entry<bool> NotificationsEnabled { get; private set; }
    public static MelonPreferences_Entry<float> NotificationDuration { get; private set; }
    public static MelonPreferences_Entry<bool> ShowAlbumArt { get; private set; }

    public static void Setup()
    {
        LoggingMode = GlobalCategory.GetEntry<int>("LoggingMode") ?? GlobalCategory.CreateEntry("LoggingMode", 0, "Logging Mode", "The level of logging to use. 0 = Important Only, 1 = All");
        NotificationsEnabled = OwnCategory.CreateEntry("NotificationsEnabled", true, "Notifications Enabled", "Whether or not to show notifications when a new song plays");
        NotificationDuration = OwnCategory.CreateEntry("NotificationDuration", 2f, "Notification Duration", "How long to show the notification for. Float, can have a decimal");
        if (HelperMethods.IsAndroid()) ShowAlbumArt = OwnCategory.CreateEntry("ShowAlbumArt", false, "Show Album Art", "Whether or not to show album art on the media player. Can cause lag on Quest.");
        GlobalCategory.SetFilePath(MelonUtils.UserDataDirectory+"/WeatherElectric.cfg");
        GlobalCategory.SaveToFile(false);
        OwnCategory.SetFilePath(MelonUtils.UserDataDirectory+"/WeatherElectric.cfg");
        OwnCategory.SaveToFile(false);
        ModConsole.Msg("Finished preferences setup for MODNAMEHERE", 1);
    }
}
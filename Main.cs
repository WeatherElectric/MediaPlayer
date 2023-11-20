#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
namespace MediaPlayer;

// ReSharper disable once InconsistentNaming
public class Main : MelonMod
{
    internal const string Name = "Media Player";
    internal const string Description = "Plays custom MP3 files in game";
    internal const string Author = "SoulWithMae";
    internal const string Company = "Weather Electric";
    internal const string Version = "2.0.0";
    internal const string DownloadLink = "https://bonelab.thunderstore.io/package/SoulWithMae/MediaPlayer/";

    private static readonly string UserDataDirectory = Path.Combine(MelonUtils.UserDataDirectory, "Weather Electric/MediaPlayer");
    public static readonly string CustomMusicDirectory = Path.Combine(UserDataDirectory, "Custom Music");
    private static readonly string PluginsDirectory = Path.Combine(MelonUtils.GameDirectory, "Plugins");
    public static readonly string DLLPath = Path.Combine(PluginsDirectory, "TagLibSharp.dll");
        
    public static Assembly CurrAssembly { get; private set; }
    public static int CurrentClipIndex { get; set; }

    public override void OnInitializeMelon()
    {
        ModConsole.Setup(LoggerInstance);
        Preferences.Setup();
#if DEBUG
        ModConsole.Warning("This is a debug build! Expect bugs!");
#endif
        CurrAssembly = Assembly.GetExecutingAssembly();
        Assets.LoadAudio();
        Assets.LoadBundle();
        Assets.CheckAssembly();
        BoneMenu.CreateMenu();
    }

    public override void OnLateInitializeMelon()
    {
        var tagLibLoaded = HelperMethods.CheckIfAssemblyLoaded("TagLibSharp");
        if (!tagLibLoaded)
        {
            ModConsole.Error("TagLib is not loaded, something went wrong!");
        }
    }
}
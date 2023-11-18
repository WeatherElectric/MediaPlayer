using HelperMethods = BoneLib;

namespace MediaPlayer;

// ReSharper disable once InconsistentNaming
public class Main : MelonMod
{
    internal const string Name = "Media Player";
    internal const string Description = "Plays custom MP3 files in game";
    internal const string Author = "SoulWithMae";
    internal const string Company = "Weather Electric";
    internal const string Version = "0.0.2";
    internal const string DownloadLink = "null";
        
    public static readonly string UserDataDirectory = Path.Combine(MelonUtils.UserDataDirectory, "Weather Electric/MediaPlayer");
    public static readonly string CustomMusicDirectory = Path.Combine(UserDataDirectory, "Custom Music");
    public static readonly string DLLPath = Path.Combine(UserDataDirectory, "TagLibSharp.dll");
        
    public static Assembly CurrAssembly { get; private set; }
    public static int CurrentClipIndex { get; set; }

    public override void OnInitializeMelon()
    {
        ModConsole.Setup(LoggerInstance);
        Preferences.Setup();
#if DEBUG
        ModConsole.Warning("This is a debug build! Expect bugs!");
#endif
        if (BoneLib.HelperMethods.IsAndroid()) ModConsole.Warning("You are on Quest! You will not get album art or any metadata!");
        CurrAssembly = Assembly.GetExecutingAssembly();
        if (!Assets.LoadBundle())
        {
            ModConsole.Error("Failed to load bundle!");
        }
        if (!Assets.LoadAudio())
        {
            ModConsole.Error("Failed to load audio! You likely don't have any audio in the folder!");
        }
        BoneMenu.CreateMenu();
    }
        
    public override void OnSceneWasInitialized(int buildIndex, string sceneName)
    {
        if (sceneName.ToUpper().Contains("BOOTSTRAP"))
        {
            AssetWarehouse.OnReady(new Action(WarehouseReady));
        }
    }

    private static void WarehouseReady()
    {
        if (BoneLib.HelperMethods.IsAndroid()) return;
        if (!Assets.LoadAssembly())
        {
            ModConsole.Error("Failed to load assembly!");
        }
    }

    public override void OnApplicationQuit()
    {
        if (BoneLib.HelperMethods.IsAndroid()) return;
        Assets.UnloadAssembly();
    }
}
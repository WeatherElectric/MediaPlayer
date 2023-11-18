#if PRERELEASE
using HelperMethods = MediaPlayer;
#endif

namespace MediaPlayer;

internal static class Assets
{
    #region Prefab
    public static GameObject Prefab;
    public static Texture2D DummyIcon;
    public static bool LoadBundle()
    {
        if (BoneLib.HelperMethods.IsAndroid())
        {
            var bundle = HelperMethods.LoadEmbeddedAssetBundle(Assembly.GetExecutingAssembly(), "MediaPlayer.Resources.MediaPlayer.Android.bundle");
            ModConsole.Msg($"Loaded Android bundle: {bundle.name}", 1);
            Prefab = bundle.LoadPersistentAsset<GameObject>("Assets/MediaPlayer/Thingy.prefab");
            ModConsole.Msg($"Loaded prefab: {Prefab.name}", 1);
            DummyIcon = bundle.LoadPersistentAsset<Texture2D>("Assets/MediaPlayer/Texture2D/dumbass.png");
            ModConsole.Msg($"Loaded dummy icon: {DummyIcon.name}", 1);
        }
        else
        {
            var bundle = HelperMethods.LoadEmbeddedAssetBundle(Assembly.GetExecutingAssembly(), "MediaPlayer.Resources.MediaPlayer.bundle");
            ModConsole.Msg($"Loaded Windows bundle: {bundle.name}", 1);
            Prefab = bundle.LoadPersistentAsset<GameObject>("Assets/MediaPlayer/Thingy.prefab");
            ModConsole.Msg($"Loaded prefab: {Prefab.name}", 1);
            DummyIcon = bundle.LoadPersistentAsset<Texture2D>("Assets/MediaPlayer/Texture2D/dumbass.png");
            ModConsole.Msg($"Loaded dummy icon: {DummyIcon.name}", 1);
        }
        return  Prefab && DummyIcon != null;
    }
    #endregion
    #region Audio
    public static readonly List<AudioClip> AudioClips = new List<AudioClip>();
        
    public static List<string> FilePaths = new List<string>();
        
    public static bool LoadAudio()
    {
        if (!Directory.Exists(Main.CustomMusicDirectory))
        {
            ModConsole.Msg("Creating custom music directory", 1);
            Directory.CreateDirectory(Main.CustomMusicDirectory);
        }
        if (Directory.GetFiles(Main.CustomMusicDirectory).Length == 0)
        {
            ModConsole.Msg("No audio files found, adding dummy audio", 1);
            var file = HelperMethods.GetResourceBytes(Main.CurrAssembly, "Michael Wyckoff - Pick It Up (Ima Say Ma Namowa).mp3");
            File.WriteAllBytes(Path.Combine(Main.CustomMusicDirectory, "Michael Wyckoff - Pick It Up (Ima Say Ma Namowa).mp3"), file);
        }
        FilePaths = GetFilesInFolder(Main.CustomMusicDirectory);
        ShuffleAudio();
        foreach (var clip in FilePaths.Select(filePath => AudioImportLib.API.LoadAudioClip(filePath)))
        {
            AudioClips.Add(clip);
            ModConsole.Msg($"Loaded audio clip: {clip.name}", 1);
        }
            
        return AudioClips != null;
    }
        
    private static void ShuffleAudio()
    {
        int n = FilePaths.Count;
        while (n > 1)
        {
            n--;
            int k = UnityEngine.Random.Range(0, n + 1);
            (FilePaths[k], FilePaths[n]) = (FilePaths[n], FilePaths[k]);
        }
    }
        
    private static List<string> GetFilesInFolder(string folderPath)
    {
        var filePaths = new List<string>();

        try
        {
            if (Directory.Exists(folderPath))
            {
                string[] files = Directory.GetFiles(folderPath);
                    
                foreach (string file in files)
                {
                    filePaths.Add(file);
                }
            }
            else
            {
                ModConsole.Error("Folder does not exist: " + folderPath);
            }
        }
        catch (Exception e)
        {
            ModConsole.Error("Error while searching for files: " + e.Message);
        }

        return filePaths;
    }
        
    #endregion
    #region Assembly
    private static bool _assemblyLoaded;
        
    [DllImport("kernel32.dll")]
    private static extern IntPtr LoadLibrary(string dllToLoad);

    [DllImport("kernel32.dll")]
    private static extern bool FreeLibrary(IntPtr hModule);

    private static IntPtr _lib;
        
    public static bool LoadAssembly()
    {
        if (!Directory.Exists(Main.UserDataDirectory))
        {
            Directory.CreateDirectory(Main.UserDataDirectory);
        }
        if (!File.Exists(Main.DLLPath))
        {
            ModConsole.Msg("Creating TagLibSharp.dll", 1);
        }
        if (!_assemblyLoaded)
        {
            ModConsole.Msg("Loading TagLibSharp.dll", 1);
            _lib = LoadLibrary(Main.DLLPath);
            _assemblyLoaded = _lib != null;
        }
        return _assemblyLoaded;
    }
        
    public static void UnloadAssembly()
    {
        if (_assemblyLoaded)
        {
            ModConsole.Msg("Unloading TagLibSharp.dll", 1);
            FreeLibrary(_lib);
            _assemblyLoaded = false;
        }
    }
    #endregion
}
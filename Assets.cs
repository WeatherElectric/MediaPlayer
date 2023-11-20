using Random = UnityEngine.Random;

namespace MediaPlayer;

internal static class Assets
{
    #region Prefab
    
    public static GameObject Prefab;
    public static Texture2D DummyIcon;
    private static AssetBundle _bundle;
    public static void LoadBundle()
    {
        if (HelperMethods.IsAndroid())
        {
            _bundle = HelperMethods.LoadEmbeddedAssetBundle(Main.CurrAssembly, "MediaPlayer.Resources.MediaPlayer.Android.bundle");
        }
        else
        {
            _bundle = HelperMethods.LoadEmbeddedAssetBundle(Main.CurrAssembly, "MediaPlayer.Resources.MediaPlayer.bundle");
        }
        ModConsole.Msg($"Loaded Windows bundle: {_bundle.name}", 1);
        Prefab = _bundle.LoadPersistentAsset<GameObject>("Assets/MediaPlayer/Thingy.prefab");
        ModConsole.Msg($"Loaded prefab: {Prefab.name}", 1);
        DummyIcon = _bundle.LoadPersistentAsset<Texture2D>("Assets/MediaPlayer/Texture2D/dumbass.png");
        ModConsole.Msg($"Loaded dummy icon: {DummyIcon.name}", 1);
    }
    #endregion
    
    #region Audio
    
    public static readonly List<AudioClip> AudioClips = new List<AudioClip>();
        
    public static List<string> FilePaths = new List<string>();
        
    public static void LoadAudio()
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
        foreach (var clip in FilePaths.Select(filePath => API.LoadAudioClip(filePath)))
        {
            AudioClips.Add(clip);
            ModConsole.Msg($"Loaded audio clip: {clip.name}", 1);
        }
    }
        
    private static void ShuffleAudio()
    {
        int n = FilePaths.Count;
        while (n > 1)
        {
            n--;
            int k = Random.Range(0, n + 1);
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
    
    public static void CheckAssembly()
    {
        if (!File.Exists(Main.DLLPath))
        {
            ModConsole.Msg("Creating TagLibSharp.dll", 1);
            var file = HelperMethods.GetResourceBytes(Main.CurrAssembly, "TagLibSharp.dll");
            File.WriteAllBytes(Main.DLLPath, file);
            ModConsole.Warning("Please restart the game! TagLibSharp was not in Plugins, so I have created it, but it requires a game restart!");
        }
    }
    
    #endregion
}
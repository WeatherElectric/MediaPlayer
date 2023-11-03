using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using BoneLib;
using UnityEngine;
using BoneLib.AssetLoader;
using MediaPlayer.Melon;
using MelonLoader;

namespace MediaPlayer
{
    public static class Assets
    {
        #region Prefab
        public static GameObject Prefab;
        public static Texture2D DummyIcon;
        public static bool LoadBundle()
        {
            if (Main.IsAndroid)
            {
                var bundle = EmbeddedBundle.LoadFromAssembly(Assembly.GetExecutingAssembly(), "MediaPlayer.Resources.MediaPlayer.Android.bundle");
                ModConsole.Msg($"Loaded Android bundle: {bundle.name}", LoggingMode.DEBUG);
                Prefab = bundle.LoadPersistentAsset<GameObject>("Assets/MediaPlayer/MediaPlayer.prefab");
                ModConsole.Msg($"Loaded prefab: {Prefab.name}", LoggingMode.DEBUG);
                DummyIcon = bundle.LoadPersistentAsset<Texture2D>("Assets/MediaPlayer/Texture2D/dummy.png");
                ModConsole.Msg($"Loaded dummy icon: {DummyIcon.name}", LoggingMode.DEBUG);
            }
            else
            {
                var bundle = EmbeddedBundle.LoadFromAssembly(Assembly.GetExecutingAssembly(), "MediaPlayer.Resources.MediaPlayer.bundle");
                ModConsole.Msg($"Loaded Windows bundle: {bundle.name}", LoggingMode.DEBUG);
                Prefab = bundle.LoadPersistentAsset<GameObject>("Assets/MediaPlayer/MediaPlayer.prefab");
                ModConsole.Msg($"Loaded prefab: {Prefab.name}", LoggingMode.DEBUG);
                DummyIcon = bundle.LoadPersistentAsset<Texture2D>("Assets/MediaPlayer/Texture2D/dummy.png");
                ModConsole.Msg($"Loaded dummy icon: {DummyIcon.name}", LoggingMode.DEBUG);
            }
            return  Prefab && DummyIcon != null;
        }
        #endregion
        #region Audio
        public static readonly List<AudioClip> AudioClips = new List<AudioClip>();
        
        private static List<string> _filePaths = new List<string>();
        
        public static bool LoadAudio()
        {
            if (!Directory.Exists(Main.CustomMusicDirectory))
            {
                ModConsole.Msg("Creating custom music directory", LoggingMode.DEBUG);
                Directory.CreateDirectory(Main.CustomMusicDirectory);
            }
            if (Directory.GetFiles(Main.CustomMusicDirectory).Length == 0)
            {
                ModConsole.Msg("No audio files found, adding dummy audio", LoggingMode.DEBUG);
                var file = EmbeddedResource.GetResourceBytes(Main.CurrAssembly, "Michael Wyckoff - Pick It Up (Ima Say Ma Namowa).mp3");
                File.WriteAllBytes(Path.Combine(Main.CustomMusicDirectory, "Michael Wyckoff - Pick It Up (Ima Say Ma Namowa).mp3"), file);
            }
            _filePaths = GetFilesInFolder(Main.CustomMusicDirectory);
            ShuffleAudio();
            foreach (var clip in _filePaths.Select(filePath => AudioImportLib.API.LoadAudioClip(filePath)))
            {
                AudioClips.Add(clip);
                ModConsole.Msg($"Loaded audio clip: {clip.name}", LoggingMode.DEBUG);
            }
            
            return AudioClips != null;
        }
        
        private static void ShuffleAudio()
        {
            int n = _filePaths.Count;
            while (n > 1)
            {
                n--;
                int k = UnityEngine.Random.Range(0, n + 1);
                (_filePaths[k], _filePaths[n]) = (_filePaths[n], _filePaths[k]);
            }
        }
        
        private static List<string> GetFilesInFolder(string folderPath)
        {
            List<string> filePaths = new List<string>();

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
        
        public static Texture2D GrabCoverFromTags(int index)
        {
            var file = _filePaths[index];
            var tagLibFile = TagLib.File.Create(file);
            var picture = tagLibFile.Tag.Pictures[0];
            if (picture == null)
            {
                ModConsole.Error($"{file}'s album art field is null!");
                return null;
            }
            var texture = new Texture2D(2, 2);
            ImageConversion.LoadImage(texture, picture.Data.Data, false);
            return texture;
        }
        
        public static string GrabAuthorFromTags(int index)
        {
            var file = _filePaths[index];
            var tagLibFile = TagLib.File.Create(file);
            var author = tagLibFile.Tag.FirstPerformer;
            if (author == null)
            {
                MelonLogger.Error($"{file}'s author field is null!");
                return "";
            }
            return author;
        }
        
        public static string GrabTitleFromTags(int index)
        {
            var file = _filePaths[index];
            var tagLibFile = TagLib.File.Create(file);
            var title = tagLibFile.Tag.Title;
            if (title == null)
            {
                MelonLogger.Error($"{file}'s title field is null! Falling back to filename.");
                var fileName = Path.GetFileName(file);
                return fileName;
            }
            return title;
        }

        public static string QuestGrabTitle(int index)
        {
            var file = _filePaths[index];
            var title = Path.GetFileName(file);
            return title;
        }
        #endregion
        #region Assembly
        private static bool _assemblyLoaded;
        
        [DllImport("kernel32.dll")]
        private static extern IntPtr LoadLibrary(string dllToLoad);

        [DllImport("kernel32.dll")]
        private static extern bool FreeLibrary(IntPtr hModule);
        
        public static bool LoadAssembly()
        {
            if (!Directory.Exists(Main.UserDataDirectory))
            {
                Directory.CreateDirectory(Main.UserDataDirectory);
            }
            if (!File.Exists(Main.DLLPath))
            {
                ModConsole.Msg("Creating TagLibSharp.dll", LoggingMode.DEBUG);
                File.WriteAllBytes(Main.DLLPath, EmbeddedResource.GetResourceBytes(Assembly.GetExecutingAssembly(), "TagLibSharp.dll"));
            }
            if (!_assemblyLoaded)
            {
                ModConsole.Msg("Loading TagLibSharp.dll", LoggingMode.DEBUG);
                LoadLibrary(Main.DLLPath);
                _assemblyLoaded = true;
            }
            return _assemblyLoaded;
        }
        
        public static void UnloadAssembly()
        {
            if (_assemblyLoaded)
            {
                ModConsole.Msg("Unloading TagLibSharp.dll", LoggingMode.DEBUG);
                FreeLibrary(LoadLibrary(Main.DLLPath));
                _assemblyLoaded = false;
            }
        }
        #endregion
    }
}
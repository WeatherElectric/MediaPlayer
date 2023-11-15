using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using BoneLib;
using UnityEngine;
using MediaPlayer.Melon;

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
                var bundle = HelperMethods.LoadEmbeddedAssetBundle(Assembly.GetExecutingAssembly(), "MediaPlayer.Resources.MediaPlayer.Android.bundle");
                ModConsole.Msg($"Loaded Android bundle: {bundle.name}", LoggingMode.DEBUG);
                Prefab = bundle.LoadPersistentAsset<GameObject>("Assets/MediaPlayer/MediaPlayer.prefab");
                ModConsole.Msg($"Loaded prefab: {Prefab.name}", LoggingMode.DEBUG);
                DummyIcon = bundle.LoadPersistentAsset<Texture2D>("Assets/MediaPlayer/Texture2D/dummy.png");
                ModConsole.Msg($"Loaded dummy icon: {DummyIcon.name}", LoggingMode.DEBUG);
            }
            else
            {
                var bundle = HelperMethods.LoadEmbeddedAssetBundle(Assembly.GetExecutingAssembly(), "MediaPlayer.Resources.MediaPlayer.bundle");
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
        
        public static List<string> FilePaths = new List<string>();
        
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
                var file = HelperMethods.GetResourceBytes(Main.CurrAssembly, "Michael Wyckoff - Pick It Up (Ima Say Ma Namowa).mp3");
                File.WriteAllBytes(Path.Combine(Main.CustomMusicDirectory, "Michael Wyckoff - Pick It Up (Ima Say Ma Namowa).mp3"), file);
            }
            FilePaths = GetFilesInFolder(Main.CustomMusicDirectory);
            ShuffleAudio();
            foreach (var clip in FilePaths.Select(filePath => AudioImportLib.API.LoadAudioClip(filePath)))
            {
                AudioClips.Add(clip);
                ModConsole.Msg($"Loaded audio clip: {clip.name}", LoggingMode.DEBUG);
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
        
        public static bool LoadAssembly()
        {
            if (!Directory.Exists(Main.UserDataDirectory))
            {
                Directory.CreateDirectory(Main.UserDataDirectory);
            }
            if (!File.Exists(Main.DLLPath))
            {
                ModConsole.Msg("Creating TagLibSharp.dll", LoggingMode.DEBUG);
                File.WriteAllBytes(Main.DLLPath, HelperMethods.GetResourceBytes(Assembly.GetExecutingAssembly(), "TagLibSharp.dll"));
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
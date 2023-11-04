using System;
using System.IO;
using System.Reflection;
using MediaPlayer.Melon;
using MelonLoader;
using SLZ.Marrow.Warehouse;
using UnityEngine;

namespace MediaPlayer
{
    // ReSharper disable once InconsistentNaming
    public class Main : MelonMod
    {
        internal const string Name = "Media Player";
        internal const string Description = "Plays custom MP3 files in game";
        internal const string Author = "SoulWithMae";
        internal const string Company = "Weather Electric";
        internal const string Version = "1.0.0";
        internal const string DownloadLink = "null";
        
        public static readonly string UserDataDirectory = Path.Combine(MelonUtils.UserDataDirectory, "MediaPlayer");
        public static readonly string CustomMusicDirectory = Path.Combine(UserDataDirectory, "Custom Music");
        public static readonly string DLLPath = Path.Combine(MelonUtils.UserDataDirectory, "MediaPlayer", "TagLibSharp.dll");

        public static bool IsAndroid { get; private set; }
        public static Assembly CurrAssembly { get; private set; }
        public static int CurrentClipIndex { get; set; }

        public override void OnInitializeMelon()
        {
            ModConsole.Setup(LoggerInstance);
            Preferences.Setup();
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
            IsAndroid = Application.platform == RuntimePlatform.Android;
            if (!Assets.LoadAssembly() && !IsAndroid)
            {
                ModConsole.Error("Failed to load assembly!");
            }
        }

        public override void OnApplicationQuit()
        {
            Assets.UnloadAssembly();
        }
    }
}
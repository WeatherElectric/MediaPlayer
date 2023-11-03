﻿using System.IO;
using BoneLib;
using MediaPlayer.Melon;
using MelonLoader;

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

        public override void OnInitializeMelon()
        {
            ModConsole.Setup(LoggerInstance);
            Preferences.Setup();
            if (!Assets.LoadBundle())
            {
                MelonLogger.Error("Failed to load bundle!");
            }
            if (!Assets.LoadAudio())
            {
                MelonLogger.Error("Failed to load audio! You likely don't have any audio in the folder!");
            }
            if (!Assets.LoadAssembly() && !HelperMethods.IsAndroid())
            {
                MelonLogger.Error("Failed to load assembly!");
            }
            BoneMenu.CreateMenu();
        }

        public override void OnApplicationQuit()
        {
            Assets.UnloadAssembly();
        }
    }
}
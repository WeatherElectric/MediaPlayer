using BoneLib;
using BoneLib.BoneMenu;
using MediaPlayer.Melon;
using UnityEngine;

namespace MediaPlayer
{
    public static class BoneMenu
    {
        public static bool NotificationsEnabled { get; set; }
        public static void CreateMenu()
        {
            NotificationsEnabled = Preferences.NotificationsEnabled;
            var maincat = MenuManager.CreateCategory("MediaPlayer", Color.white);
            maincat.CreateFunctionElement("Spawn MediaPlayer", Color.green, Spawn);
            maincat.CreateFunctionElement("Despawn MediaPlayer", Color.red, Despawn);
            maincat.CreateBoolElement("Show Notifications", Color.white, NotificationsEnabled, OnSetEnabled);
        }

        private static void OnSetEnabled(bool value)
        {
            NotificationsEnabled = value;
            Preferences.NotificationsEnabled.entry.Value = value;
            Preferences.Category.SaveToFile(false);
        }
        
        private static bool _isSpawned;
        private static GameObject _prefab;
        private static void Spawn()
        {
            if (_isSpawned) return;
            var player = Player.playerHead;
            var location = player.position + player.forward * 1f;
            _prefab = Object.Instantiate(Assets.Prefab, location, player.rotation);
            _isSpawned = true;
        }

        private static void Despawn()
        {
            if (!_isSpawned) return;
            Object.Destroy(_prefab);
            _isSpawned = false;
        }
    }
}
using BoneLib;
using BoneLib.BoneMenu;
using BoneLib.BoneMenu.Elements;
using MediaPlayer.Melon;
using UnityEngine;

namespace MediaPlayer
{
    public static class BoneMenu
    {
        public static void CreateMenu()
        {
            MenuCategory mainCat = MenuManager.CreateCategory("Weather Electric", "#6FBDFF");
            MenuCategory menuCategory = mainCat.CreateCategory("Media Player", Color.white);
            menuCategory.CreateFunctionElement("Spawn Media Player", Color.green, Spawn);
            menuCategory.CreateFunctionElement("Despawn Media Player", Color.red, Despawn);
            menuCategory.CreateBoolElement("Show Playing Notifications", Color.white, Preferences.NotificationsEnabled.Value, OnBoolUpdate);
            menuCategory.CreateFloatElement("Notification Duration", Color.white, 2f, 0.1f, 0.5f, 5f, OnFloatUpdate);
        }

        private static void OnBoolUpdate(bool value)
        {
            Preferences.NotificationsEnabled.Value = value;
            Preferences.OwnCategory.SaveToFile(false);
        }

        private static void OnFloatUpdate(float value)
        {
            Preferences.NotificationDuration.Value = value;
            Preferences.OwnCategory.SaveToFile(false);
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
using Object = UnityEngine.Object;

namespace MediaPlayer;

internal static class BoneMenu
{
    public static void CreateMenu()
    {
        MenuCategory mainCat = MenuManager.CreateCategory("Weather Electric", "#6FBDFF");
        MenuCategory menuCategory = mainCat.CreateCategory("Media Player", "#ff21d2");
        menuCategory.CreateFunctionElement("Spawn Media Player", Color.green, Spawn);
        menuCategory.CreateFunctionElement("Despawn Media Player", Color.red, Despawn);
        MenuCategory settingsCategory = menuCategory.CreateCategory("Settings", "#B0B0B0");
        settingsCategory.CreateBoolPreference("Show Playing Notifications", Color.white, Preferences.NotificationsEnabled, Preferences.OwnCategory);
        settingsCategory.CreateFloatPreference("Notification Duration", Color.white, 0.1f, 0.5f, 5f, Preferences.NotificationDuration, Preferences.OwnCategory);
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
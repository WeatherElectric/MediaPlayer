#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
namespace MediaPlayer.Patching;

[HarmonyPatch(typeof(ZoneMusic), "PlayMusic")]
public class ZoneMusicPlayMusic
{
    public static void Postfix(ZoneMusic __instance, float fadeTime)
    {
        if (!Preferences.DisableBaseGameMusic.Value) return;
        __instance.StopMusic(0f);
    }
}

[HarmonyPatch(typeof(ZoneMusic), "Play")]
public class ZoneMusicPlay
{
    public static void Postfix(ZoneMusic __instance, MusicAmbience2dSFX headSFX)
    {
        if (!Preferences.DisableBaseGameMusic.Value) return;
        __instance.StopMusic(0f);
    }
}

[HarmonyPatch(typeof(ZoneMusic), "OnPrimaryZoneEntered")]
public class ZoneMusicOnPrimaryZoneEntered
{
    public static void Postfix(ZoneMusic __instance, GameObject playerObject)
    {
        if (!Preferences.DisableBaseGameMusic.Value) return;
        __instance.StopMusic(0f);
    }
}
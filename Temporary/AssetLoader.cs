#if PRERELEASE
using System.IO;
using System.Linq;
using System.Reflection;
using MediaPlayer.Melon;
using SLZ.Marrow.SceneStreaming;
using UnityEngine;

namespace MediaPlayer
{
    public static class HelperMethods
    {
        /// <summary>
        /// Loads an embedded assetbundle
        /// </summary>
        public static AssetBundle LoadEmbeddedAssetBundle(Assembly assembly, string name)
        {
            string[] manifestResources = assembly.GetManifestResourceNames();
            AssetBundle bundle = null;
            if (manifestResources.Contains(name))
            {
                ModConsole.Msg($"Loading embedded resource data {name}...", 1);
                using Stream str = assembly.GetManifestResourceStream(name);
                using MemoryStream memoryStream = new MemoryStream();

                str.CopyTo(memoryStream);
                ModConsole.Msg("Done!", 1);
                byte[] resource = memoryStream.ToArray();

                ModConsole.Msg($"Loading assetBundle from data {name}, please be patient...", 1);
                bundle = AssetBundle.LoadFromMemory(resource);
                ModConsole.Msg("Done!", 1);
            }
            return bundle;
        }

        /// <summary>
        /// Loads an asset from an assetbundle
        /// </summary>
        public static T LoadPersistentAsset<T>(this AssetBundle assetBundle, string name) where T : UnityEngine.Object
        {
            UnityEngine.Object asset = assetBundle.LoadAsset(name);

            if (asset != null)
            {
                asset.hideFlags = HideFlags.DontUnloadUnusedAsset;
                return asset.TryCast<T>();
            }

            return null;
        }

        /// <summary>
        /// Gets the raw bytes of an embedded resource
        /// </summary>
        public static byte[] GetResourceBytes(Assembly assembly, string name)
        {
            foreach (string resource in assembly.GetManifestResourceNames())
            {
                if (resource.Contains(name))
                {
                    using (Stream resFilestream = assembly.GetManifestResourceStream(resource))
                    {
                        if (resFilestream == null) return null;
                        byte[] byteArr = new byte[resFilestream.Length];
                        resFilestream.Read(byteArr, 0, byteArr.Length);
                        return byteArr;
                    }
                }
            }
            return null;
        }
        
        public static bool IsLoading() => SceneStreamer.Session.Status == StreamStatus.LOADING;
    }
}
#endif
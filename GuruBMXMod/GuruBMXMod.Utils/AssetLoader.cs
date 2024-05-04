using System.Reflection;
using UnityEngine;
using System.IO;
using System;
using Il2CppMG_Gameplay;
using MelonLoader;
using UnityEngine.InputSystem.XR;
using Il2CppSystem.Collections;

namespace GuruBMXMod.Utils
{
    internal class AssetLoader
    {
        public static AssetBundle assetBundle;
        public static GameObject ScriptManager;
        public static GameObject snowPrefab;
        public static GameObject rainPrefab;
        public static bool assetsLoaded { get; private set; } = false;

        public static void LoadBundles()
        {
            if (typeof(UnityEngine.Object) != null)
            {
                //GameWorld.GetInstance().StartCoroutine_Auto(LoadAssetBundle());
                LoadAssetBundle();
            }
            else
            {
                MelonLogger.Msg("No UnityEngine Type Found");
            }
        }

        private static void LoadAssetBundle()
        {
            byte[] assetBundleData = ResourceExtractor.ExtractResources("GuruBMXMod.Resources.bmxweatherdata");

            if (assetBundleData == null)
            {
                MelonLogger.Msg("Failed to EXTRACT Asset Bundle");
                assetsLoaded = false;
                return;
                //yield break;
            }

            //AssetBundleCreateRequest abCreateRequest = AssetBundle.LoadFromMemoryAsync(assetBundleData);
            //assetBundle = abCreateRequest.assetBundle;

            assetBundle = AssetBundle.LoadFromMemory(assetBundleData);

            if (assetBundle == null)
            {
                MelonLogger.Msg("Failed to LOAD Asset Bundle");
                assetsLoaded = false;
                return;
                //yield break;
            }

            //snowPrefab = assetBundle.LoadAsset("snowV3") as GameObject;
            //rainPrefab = assetBundle.LoadAsset("RainV4") as GameObject;
            //snowPrefab = assetBundle.LoadAsset<GameObject>("snowV3");
            //rainPrefab = assetBundle.LoadAsset<GameObject>("RainV4");
            snowPrefab = assetBundle.LoadAsset("snowV3").Cast<GameObject>();
            rainPrefab = assetBundle.LoadAsset("RainV4").Cast<GameObject>();

            if (snowPrefab != null && rainPrefab != null)
            {
                assetsLoaded = true;
                MelonLogger.Msg("All Assets Loaded");
            }
            else
            {
                assetsLoaded = false;
                MelonLogger.Msg("Assets Failed to Load");
            }
            //yield return null;
        }


        public static void UnloadAssetBundle()
        {
            if (assetBundle != null)
            {
                assetBundle.Unload(true);
                assetBundle = null;
                assetsLoaded = false;
            }
        }

        private static void OnDestroy()
        {
            UnloadAssetBundle();
        }
    }
}
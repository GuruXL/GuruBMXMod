using System.Reflection;
using UnityEngine;
using System.IO;
using System;
using Il2CppMG_Gameplay;
using MelonLoader;
using UnityEngine.InputSystem.XR;
using Il2CppSystem.Collections;
using Il2Cpp;

namespace GuruBMXMod.Utils
{
    internal class AssetLoader
    {
        public static AssetBundle assetBundle;
        public static GameObject ScriptManager;
        public static GameObject snowPrefab;
        public static GameObject snowPrefab_PS;
        public static GameObject rainPrefab;
        public static GameObject rainPrefab_PS;

        public static bool assetsLoaded { get; private set; } = false;

        public static void LoadBundles()
        {
            if (typeof(UnityEngine.Object) != null)
            {
                //GameWorld.GetInstance().StartCoroutineManaged2(LoadAssetBundle());
                //GameWorld.GetInstance().StartCoroutine_Auto(LoadAssetBundle());
                LoadAssetBundle();
            }
            else
            {
                MelonLogger.Msg("No UnityEngine Type Found");
            }
        }
        /*
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

            LoadPrefabs();

            //yield return null;
        }
        */
        private static void LoadAssetBundle()
        {
            MelonLogger.Msg("Extracting Resources...");
            try
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
            }
            catch (Exception ex)
            {
                MelonLogger.Msg("Exception Extracting Resources: " + ex.Message);
            }
            finally
            {
                LoadPrefabs();
            }
        }

        private static void LoadPrefabs()
        {
            MelonLogger.Msg("Loading Asset Prefabs...");
            try
            {
                snowPrefab = assetBundle.LoadAsset("snowV3").Cast<GameObject>();
                rainPrefab = assetBundle.LoadAsset("RainV4").Cast<GameObject>();
                snowPrefab_PS = assetBundle.LoadAsset("Snow_PS").Cast<GameObject>();
                rainPrefab_PS = assetBundle.LoadAsset("Rain_PS").Cast<GameObject>();
            }
            catch (Exception ex)
            {
                MelonLogger.Msg("Loading Asset Exception: " + ex.Message);
            }
            finally
            {
                CheckLoadedComponents();
            }
        }

        private static void CheckLoadedComponents()
        {
            // Creating a dictionary for dynamic checking
            Dictionary<string, object> components = new Dictionary<string, object>
            {
            {"snowPrefab", snowPrefab},
            {"rainPrefab", rainPrefab},
            {"snowPrefab_PS", snowPrefab_PS},
            {"rainPrefab_PS", rainPrefab_PS}
            };

            if (ComponentCheck.CheckComponents(components, "VFX"))
            {
                assetsLoaded = true;
            }
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
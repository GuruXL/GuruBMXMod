using Il2Cpp;
using MelonLoader;
using HarmonyLib;
using UnityEngine;
using Il2CppMG_Gameplay;
using GuruBMXMod.UI;
using GuruBMXMod.Multi;
using GuruBMXMod.Utils;
using GuruBMXMod.Patches;
using GuruBMXMod.Gameplay;

namespace GuruBMXMod
{
    public static class BuildInfo
    {
        public const string Name = "Guru BMX Mod"; // Name of the Mod.  (MUST BE SET)
        public const string Description = "Mod for BMX Streets"; // Description for the Mod.  (Set as null if none)
        public const string Author = "Guru"; // Author of the Mod.  (MUST BE SET)
        public const string Company = null; // Company that made the Mod.  (Set as null if none)
        public const string Version = "0.0.4"; // Version of the Mod.  (MUST BE SET)
        public const string DownloadLink = null; // Download Link for the Mod.  (Set as null if none)
    }

    public class BMXMod : MelonMod
    {
        private HarmonyLib.Harmony harmonyInstance;

        //public GameObject ScriptManager;

        private UIcontroller uiController;
        //private VFXController vfxController;

        public override void OnInitializeMelon()
        {
            InitHarmony();
            //MelonLogger.Msg("OnInitializeMelon Success");
        }
        public override void OnLateInitializeMelon() // Runs after OnApplicationStart.
        {
            try
            {
                LoadAssetBundles();
                CreateScriptManager();
                LoadUI();
                //LoadVFX();
                VFXController.Instance.LoadVFXAssets();
            }
            catch (Exception ex)
            {
                MelonLogger.Msg("Failed Load Exception: " + ex.Message);
            }

            //MelonLogger.Msg("OnApplicationLateStart");
        }
        public override void OnSceneWasLoaded(int buildindex, string sceneName) // Runs when a Scene has Loaded and is passed the Scene's Build Index and Name.
        {
            CheckForModdedMap(buildindex);
            //MelonLogger.Msg("OnSceneWasLoaded: " + buildindex.ToString() + " | " + sceneName);
        }
        public override void OnSceneWasInitialized(int buildindex, string sceneName) // Runs when a Scene has Initialized and is passed the Scene's Build Index and Name.
        {
            GetModComponents(buildindex, sceneName);
            //MelonLogger.Msg("OnSceneWasInitialized: " + buildindex.ToString() + " | " + sceneName);
        }
        public override void OnSceneWasUnloaded(int buildIndex, string sceneName)
        {
            // MelonLogger.Msg("OnSceneWasUnloaded: " + buildIndex.ToString() + " | " + sceneName);
        }
        public override void OnUpdate() // Runs once per frame.
        {
            if (!SettingsManager.CurrentSettings.ModEnabled)
                return;

            if (uiController != null)
            {
                uiController.WaitForInput();
            }

            VFXController.Instance.RunUpdate(CameraController.Instance.mainCam);
        }
        public override void OnFixedUpdate()
        {
        }

        public override void OnLateUpdate()
        {
        }
        public override void OnGUI()
        {
            if (uiController != null)
            {
                uiController.CustomOnGUI();
            }  
        }
        public override void OnApplicationQuit()
        {
            UnloadAssetBundles();
            UnpatchHarmony();
        }
        public override void OnPreferencesSaved()
        {
            //MelonLogger.Msg("OnPreferencesSaved");
        }
        public override void OnPreferencesLoaded()
        {
            //MelonLogger.Msg("OnPreferencesLoaded");
        }

        private void InitHarmony()
        {
            try
            {
                if (harmonyInstance == null)
                {
                    harmonyInstance = new HarmonyLib.Harmony(BuildInfo.Name);
                    harmonyInstance.PatchAll();
                }
            }
            catch (Exception ex)
            {
                MelonLogger.Msg("Exception Creating Harmony Instance: " + ex.Message);
            }
            finally
            {
                if (harmonyInstance != null)
                {
                    MelonLogger.Msg("Harmony Instance Created");
                }
            }
        }
        private void UnpatchHarmony()
        {
            try
            {
                if (harmonyInstance != null)
                {
                    harmonyInstance.UnpatchSelf();
                }
            }
            catch (Exception ex)
            {
                MelonLogger.Msg("Exception Unpatching Hamony: " + ex.Message);
            }
        }
        private void GetModComponents(int buildindex, string sceneName)
        {
            try
            {
                if (buildindex == 1 || sceneName == "Bridging Physics PIPE Style")
                {
                    BMXModController.Instance.GetBikeComponents();
                    PlayerController.Instance.GetPlayerComponents();
                    CameraController.Instance.GetCameraComponents();
                    //SessionMarkerSwap.Instance.GetInputComponents();
                }
                else if (buildindex == 8 || sceneName == "BMXS_WorldLighting")
                {
                    TimeController.Instance.GetTimeOfDayComponents();
                }
                else if (buildindex == 2 || sceneName == "Smart Data Features")
                {
                    RewardUnlocks.Instance.GetSmartDataComponents();
                }
                else if (buildindex == 4 || sceneName == "PlatformManager")
                {
                    BMXModNetworkController.Instance.GetNetworkComponenets();
                }
                else if (buildindex == -1)
                {
                    TimeController.Instance.GetModMapComponents(sceneName);

                    if (SettingsManager.CurrentSettings.EnableCycle)
                    {
                        TimeController.Instance.EnableDayNightCycle(SettingsManager.CurrentSettings.EnableCycle);
                    }
                }
            }
            catch (Exception ex)
            {
                MelonLogger.Msg("OnSceneWasLoaded exception: " + ex.Message);
            }
        }
        private void CheckForModdedMap(int buildindex)
        {
            if (buildindex == -1)
            {
                SettingsManager.CurrentSettings.IsModMap = true;
                MelonLogger.Msg($"IsModded Map: {SettingsManager.CurrentSettings.IsModMap}");
            }
            else
            {
                if (SettingsManager.CurrentSettings.IsModMap)
                {
                    SettingsManager.CurrentSettings.IsModMap = false;
                }
            }
        }
        private void LoadAssetBundles()
        {
            AssetLoader.LoadBundles();
        }
        private void UnloadAssetBundles()
        {
            AssetLoader.UnloadAssetBundle();
        }

        private void LoadUI()
        {
            uiController = new UIcontroller();

            if (uiController != null)
            {
                MelonLogger.Msg("UI Loaded");
            }
            else
            {
                if (uiController == null)
                {
                    MelonLogger.Msg("UI Failed to Load");
                }
            }
        } 
        /*
        private void LoadVFX()
        {
            vfxController = new VFXController();

            if (vfxController != null)
            {
                vfxController.LoadVFXAssets();
                MelonLogger.Msg("VFX controller Loaded");
            }
            else
            {
                if (vfxController == null)
                {
                    MelonLogger.Msg("VFX controller Failed to Load");
                }
            }

        }
        */
        private void CreateScriptManager()
        {
            if (AssetLoader.ScriptManager == null)
            {
                AssetLoader.ScriptManager = new GameObject("Guru BMX Mod");
                UnityEngine.Object.DontDestroyOnLoad(AssetLoader.ScriptManager);
                MelonLogger.Msg("ScriptManager Created");
            }
        }
    }
}
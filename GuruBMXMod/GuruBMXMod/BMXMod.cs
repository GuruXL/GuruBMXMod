using Il2Cpp;
using MelonLoader;
using HarmonyLib;
using UnityEngine;
using Il2CppMG_Gameplay;
using GuruBMXMod.UI;
using GuruBMXMod.Multi;
using GuruBMXMod.Utils;
using GuruBMXMod.Patches;

namespace GuruBMXMod
{
    public static class BuildInfo
    {
        public const string Name = "Guru BMX Mod"; // Name of the Mod.  (MUST BE SET)
        public const string Description = "Mod for BMX Streets"; // Description for the Mod.  (Set as null if none)
        public const string Author = "Guru"; // Author of the Mod.  (MUST BE SET)
        public const string Company = null; // Company that made the Mod.  (Set as null if none)
        public const string Version = "0.0.2"; // Version of the Mod.  (MUST BE SET)
        public const string DownloadLink = null; // Download Link for the Mod.  (Set as null if none)
    }

    public class BMXMod : MelonMod
    {
        private HarmonyLib.Harmony harmonyInstance;

        private GameObject ScriptManager;

        private UIcontroller uiController;

        public override void OnInitializeMelon()
        {
            InitHarmony();

            //MelonLogger.Msg("OnInitializeMelon Success");
        }
        public override void OnLateInitializeMelon() // Runs after OnApplicationStart.
        {
            try
            {
                CreateScriptManager();
                LoadUI();
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
            if (uiController != null)
            {
                uiController.WaitForInput();
            }
            //MelonLogger.Msg("OnUpdate");
        }
        public override void OnFixedUpdate() // Can run multiple times per frame. Mostly used for Physics.
        {
            //MelonLogger.Msg("OnFixedUpdate");
        }

        public override void OnLateUpdate() // Runs once per frame after OnUpdate and OnFixedUpdate have finished.
        {
            //MelonLogger.Msg("OnLateUpdate");
        }
        public override void OnGUI() // Can run multiple times per frame. Mostly used for Unity's IMGUI.
        {
            if (uiController != null)
            {
                uiController.CustomOnGUI();
            }  
        }
        public override void OnApplicationQuit() // Runs when the Game is told to Close.
        {
            UnpatchHarmony();
            //MelonLogger.Msg("OnApplicationQuit");
        }
        public override void OnPreferencesSaved() // Runs when Melon Preferences get saved.
        {
            //MelonLogger.Msg("OnPreferencesSaved");
        }
        public override void OnPreferencesLoaded() // Runs when Melon Preferences get loaded.
        {
            //MelonLogger.Msg("OnPreferencesLoaded");
        }

        private void LoadUI()
        {
            uiController = new UIcontroller();

            if (uiController != null)
            {
                MelonLogger.Msg("Loaded");
            }
            else
            {
                if (uiController == null)
                {
                    MelonLogger.Msg("UI Failed to Load");
                }
            }
        }

        private void CreateScriptManager()
        {
            if (ScriptManager == null)
            {
                ScriptManager = new GameObject("Guru BMX Mod");
                UnityEngine.Object.DontDestroyOnLoad(ScriptManager);
                MelonLogger.Msg("ScriptManager Created");
            }
        }
        private void CheckForModdedMap(int buildindex)
        {
            if (buildindex == -1)
            {
                Settings.IsModMap = true;
                MelonLogger.Msg($"IsModded Map: {Settings.IsModMap}");
            }
            else
            {
                if (Settings.IsModMap)
                {
                    Settings.IsModMap = false;
                }
            }
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
                MelonLogger.Msg("Exception Creating Hamony Instance: " + ex.Message);
            }
            finally
            {
                if (harmonyInstance != null)
                {
                    MelonLogger.Msg("Hamony Instance Created");
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
                    VehicleController.Instance.GetBikeComponents();
                    //CameraController.Instance.GetCameraComponents();
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

                    if (Settings.EnableCycle)
                    {
                        TimeController.Instance.EnableDayNightCycle(Settings.EnableCycle);
                    }
                }
            }
            catch (Exception ex)
            {
                MelonLogger.Msg("OnSceneWasLoaded exception: " + ex.Message);
            }

        }
    }
}
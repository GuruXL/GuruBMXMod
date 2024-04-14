using Il2Cpp;
using MelonLoader;
using HarmonyLib;
using UnityEngine;
using Il2CppMG_Gameplay;
using GuruBMXMod.UI;
using GuruBMXMod.Multi;

namespace GuruBMXMod
{
    public static class BuildInfo
    {
        public const string Name = "Guru BMX Mod"; // Name of the Mod.  (MUST BE SET)
        public const string Description = "Mod for Testing BMX Streets"; // Description for the Mod.  (Set as null if none)
        public const string Author = "Guru"; // Author of the Mod.  (MUST BE SET)
        public const string Company = null; // Company that made the Mod.  (Set as null if none)
        public const string Version = "0.0.1"; // Version of the Mod.  (MUST BE SET)
        public const string DownloadLink = null; // Download Link for the Mod.  (Set as null if none)
    }

    public class BMXMod : MelonMod
    {
        private UIcontroller uiController;

        public override void OnInitializeMelon()
        {
            try
            {
                LoadUI();
            }
            catch (Exception ex)
            {
                MelonLogger.Msg("Failed Load: " + ex.Message);
            }
            //MelonLogger.Msg("OnInitializeMelon Success");
        }
        public override void OnLateInitializeMelon() // Runs after OnApplicationStart.
        {
            //LoadUI();
            //MelonLogger.Msg("OnApplicationLateStart");
        }
        public override void OnSceneWasLoaded(int buildindex, string sceneName) // Runs when a Scene has Loaded and is passed the Scene's Build Index and Name.
        {
            /*
            try
            {
                if (sceneName == "Bridging Physics PIPE Style" || buildindex == 1)
                {
                    BMXModController.Instance.GetBikeComponents();
                }
                else if (sceneName == "BMXS_WorldLighting" || buildindex == 8)
                {
                    BMXModController.Instance.GetTimeOfDayComponents();
                }
                else if (sceneName == "Smart Data Features" || buildindex == 2)
                {
                    BMXModController.Instance.GetSmartDataComponents();
                }
            }
            catch (Exception ex)
            {
                MelonLogger.Msg("OnSceneWasLoaded exception: " + ex.Message);
            }
            */
            //MelonLogger.Msg("OnSceneWasLoaded: " + buildindex.ToString() + " | " + sceneName);
        }
        public override void OnSceneWasInitialized(int buildindex, string sceneName) // Runs when a Scene has Initialized and is passed the Scene's Build Index and Name.
        {
            try
            {
                if (sceneName == "Bridging Physics PIPE Style" || buildindex == 1)
                {
                    BMXModController.Instance.GetBikeComponents();
                }
                else if (sceneName == "BMXS_WorldLighting" || buildindex == 8)
                {
                    TimeController.Instance.GetTimeOfDayComponents();
                }
                else if (sceneName == "Smart Data Features" || buildindex == 2)
                {
                    RewardUnlocks.Instance.GetSmartDataComponents();
                }
                else if (sceneName == "PlatformManager" || buildindex == 4)
                {
                    BMXModNetworkController.Instance.GetNetworkComponenets();
                }
            }
            catch (Exception ex)
            {
                MelonLogger.Msg("OnSceneWasLoaded exception: " + ex.Message);
            }

            //MelonLogger.Msg("OnSceneWasInitialized: " + buildindex.ToString() + " | " + sceneName);
        }
        public override void OnSceneWasUnloaded(int buildIndex, string sceneName)
        {
            // MelonLogger.Msg("OnSceneWasUnloaded: " + buildIndex.ToString() + " | " + sceneName);
        }
        public override void OnUpdate() // Runs once per frame.
        {
            uiController.WaitForInput();
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
            uiController.CustomOnGUI();
        }
        public override void OnApplicationQuit() // Runs when the Game is told to Close.
        {
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
                MelonLogger.Msg("UI Loaded");
            }
        }
    }
}
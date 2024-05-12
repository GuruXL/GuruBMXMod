using GuruBMXMod.UI;
using Il2CppNewtonsoft.Json;
using MelonLoader;
using UnityEngine;
using System.IO;
using System.Xml.Serialization;
using Il2Cpp;
using Il2CppSystem.Collections;

namespace GuruBMXMod
{
    public static class SettingsManager
    {
        public static Settings CurrentSettings { get; set; }
        public static Settings DefaultSettings { get; private set; }

        public static bool IsModMap { get; set; } = false;
        public static string mainPath{ get; private set; }

        static SettingsManager()
        {
            CurrentSettings = new Settings();
            DefaultSettings = new Settings { ModEnabled = true };
        }

        private static void ResetToDefault()
        {
            CurrentSettings = DefaultSettings.Clone();
        }

        public static void ResetAllSettings()
        {
            ResetToDefault();
            ApplyButtons();
            ApplySliders();
        }

        public static void CreateSettingsFolder()
        {
            mainPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "BMX Streets", "GuruBMXMod");

            // Using Path.Combine here to correctly handle the "Settings" subfolder
            string settingsPath = Path.Combine(mainPath, "Settings");

            if (Directory.Exists(settingsPath))
            {
                MelonLogger.Msg("Settings folder exists");
            }
            else
            {
                Directory.CreateDirectory(settingsPath);
                MelonLogger.Msg("Settings folder created");
            }
        }

        public static void SaveSettings()
        {
            SaveSettingsToXML();
        }
        public static void LoadSettings()
        {
            LoadSettingsFromXML();
        }
        public static void ApplySettings()
        {
            ApplyButtons();
            ApplySliders();
            MelonLogger.Msg("Settings Applied");
        }

        #region Save/Load Settings
        private static void SaveSettingsToXML()
        {
            string settingsFilePath = Path.Combine(mainPath, "Settings", "Settings.xml");

            XmlSerializer serializer = new XmlSerializer(typeof(Settings));
            using (StreamWriter writer = new StreamWriter(settingsFilePath))
            {
                serializer.Serialize(writer, CurrentSettings);
            }
            MelonLogger.Msg("Settings saved");
        }

        private static void LoadSettingsFromXML()
        {
            string settingsFilePath = Path.Combine(mainPath, "Settings", "Settings.xml");

            if (File.Exists(settingsFilePath))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Settings));
                using (StreamReader reader = new StreamReader(settingsFilePath))
                {
                    CurrentSettings = (Settings)serializer.Deserialize(reader);
                }
                MelonLogger.Msg("Settings loaded");
            }
            else
            {
                MelonLogger.Warning("No Settings file found, using default settings.");
                // Optionally reset to default settings if the file doesn't exist
                CurrentSettings = new Settings();
            }
        }
        #endregion

        #region Apply Settings
        private static void ApplyButtons()
        {
            UIActionManager.MainToggle(CurrentSettings.ModEnabled);

            UIActionManager.DisableBail(CurrentSettings.DisableBail);
            UIActionManager.ToggleSimplePedal(CurrentSettings.EnableSimplePedal);
            UIActionManager.ToggleMannyStability(CurrentSettings.MannyAutoStability);

            UIActionManager.UnlockStars(CurrentSettings.UnlockStars);
            UIActionManager.UnlockRewards(CurrentSettings.UnlockRewards);

            UIActionManager.ToggleRain(CurrentSettings.rainEnabled);
            UIActionManager.ToggleSnow(CurrentSettings.snowEnabled);

            UIActionManager.EnableCycle(CurrentSettings.EnableCycle);
        }
        private static void ApplySliders()
        {
            // Player Settings
            UIActionManager.UpdatePlayerAnimationSpeed(CurrentSettings.Player_AnimationSpeed);
            UIActionManager.UpdatePlayerJumpForce(CurrentSettings.Player_JumpForce);
            UIActionManager.UpdatePlayerMaxFallVelocity(CurrentSettings.Player_MaxVelocityToRagDoll);

            // Bike Physics
            UIActionManager.UpdateGravitySlider(CurrentSettings.Gravity);

            // BMX Hop Data
            UIActionManager.UpdateGroundOllie(CurrentSettings.BMX_Ground_OllieForce);
            UIActionManager.UpdateGroundNollie(CurrentSettings.BMX_Ground_NollieForce);
            UIActionManager.UpdateGroundQuickHop(CurrentSettings.BMX_Ground_QuickHopForce);
            UIActionManager.UpdateNoseyOllie(CurrentSettings.BMX_Nosey_OllieForce);
            UIActionManager.UpdateNoseyQuickHop(CurrentSettings.BMX_Nosey_QuickHopForce);
            UIActionManager.UpdateGrindOllie(CurrentSettings.BMX_Grind_OllieForce);
            UIActionManager.UpdateGrindNollie(CurrentSettings.BMX_Grind_NollieForce);
            UIActionManager.UpdateGrindQuickHop(CurrentSettings.BMX_Grind_QuickHopForce);

            // BMX Trick Data
            UIActionManager.UpdateTrickAnimationSpeed(CurrentSettings.BMX_TrickAnimationSpeed);
            UIActionManager.UpdatePerefectTweakThreshold(CurrentSettings.BMX_PerfectTweakThreshold);

            // Simple Pedal and Velocity
            UIActionManager.UpdatePedalForceSlider(CurrentSettings.SimpleBMX_PedalForce);
            UIActionManager.UpdatePedalVelocitySlider(CurrentSettings.SimpleBMX_MaxPedalVel);

            // Grind Mechanics
            UIActionManager.UpdateGrindHoldForce(CurrentSettings.SimpleBMX_GrindHoldForce);

            // Steering and Pumping
            UIActionManager.UpdateSteeringPumpMin(CurrentSettings.SimpleBMX_MinPumpForceMulti);
            UIActionManager.UpdateSteeringPumpMax(CurrentSettings.SimpleBMX_MaxPumpForceMulti);
            UIActionManager.UpdateSteeringPumpTime(CurrentSettings.SimpleBMX_PumpMinMaxCurveTime);

            // Manny and Nosey Balancing
            UIActionManager.UpdateMannyMaxAngle(CurrentSettings.BMX_MannyMaxBailAngle);
            UIActionManager.UpdateNoseyMaxAngle(CurrentSettings.BMX_NoseyMaxBailAngle);

            // Drift Bike
            UIActionManager.UpdateDriftJumpForce(CurrentSettings.DriftBike_JumpForce);
            UIActionManager.UpdateDriftMaxMotorTorque(CurrentSettings.DriftBike_MaxMotorTorque);
            UIActionManager.UpdateDriftMaxBrakeTorque(CurrentSettings.DriftBike_MaxBrakeTorque);
            UIActionManager.UpdateDriftAirFlipTorque(CurrentSettings.DriftBike_AirFlipTorque);
            UIActionManager.UpdateDriftAirSpinTorque(CurrentSettings.DriftBike_AirSpinTorque);
            UIActionManager.UpdateDriftAirUpRightTorque(CurrentSettings.DriftBike_AirUpRightTorque);
            UIActionManager.UpdateDriftAntiRoll(CurrentSettings.DriftBike_AntiRoll);
            UIActionManager.UpdateDriftCOMoffset(CurrentSettings.DriftBike_COMOffset);
            UIActionManager.UpdateDriftTurnTorque(CurrentSettings.DriftBike_TurnTorque);
            UIActionManager.UpdateDriftTurnResponse(CurrentSettings.DriftBike_TurnResponse);

            // Time of Day Settings
            UIActionManager.UpdateTimeOfDay(CurrentSettings.TimeOfDay);
            UIActionManager.UpdateCycleSpeed(CurrentSettings.CycleSpeed);
            UIActionManager.UpdateShadowTime(CurrentSettings.ShadowUpdateTime);
            UIActionManager.TimeBetweenSkyUpdates(CurrentSettings.TimeBetweenSkyUpdates);
        }
        #endregion
    }
}

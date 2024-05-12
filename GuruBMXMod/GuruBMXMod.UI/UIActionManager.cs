using GuruBMXMod.Gameplay;
using GuruBMXMod.Multi;
using GuruBMXMod.Utils;
using UnityEngine;

namespace GuruBMXMod.UI
{
    internal class UIActionManager
    {
        #region Buttons
        public static void MainToggle(bool enabled)
        {
            SettingsManager.CurrentSettings.ModEnabled = enabled;
        }
        // BMX
        public static void DisableBail(bool enabled)
        {
            SettingsManager.CurrentSettings.DisableBail = enabled;
        }
        public static void ToggleSimplePedal(bool enabled)
        {
            if (enabled == SettingsManager.CurrentSettings.EnableSimplePedal)
                return;

            SettingsManager.CurrentSettings.EnableSimplePedal = enabled;
            BMXModController.Instance.ToggleSimplePedal();
        }
        public static void ToggleMannyStability(bool enabled)
        {
            SettingsManager.CurrentSettings.MannyAutoStability = enabled;
        }
        // Rewards
        public static void UnlockStars(bool enabled)
        {
            if (enabled == SettingsManager.CurrentSettings.UnlockStars)
                return;

            SettingsManager.CurrentSettings.UnlockStars = enabled;
            RewardUnlocks.Instance.UnlockStars("All", SettingsManager.CurrentSettings.UnlockStars);
        }
        public static void UnlockRewards(bool enabled)
        {
            if (enabled == SettingsManager.CurrentSettings.UnlockRewards)
                return;

            SettingsManager.CurrentSettings.UnlockRewards = enabled;
            RewardUnlocks.Instance.UnlockRewards(SettingsManager.CurrentSettings.UnlockRewards);
        }         
        // VFX
        public static void ToggleRain(bool enabled)
        {
            if (enabled == SettingsManager.CurrentSettings.rainEnabled)
                return;

            SettingsManager.CurrentSettings.rainEnabled = enabled;
            VFXController.Instance.ToggleRain(SettingsManager.CurrentSettings.rainEnabled);
        }
        public static void ToggleSnow(bool enabled)
        {
            if (enabled == SettingsManager.CurrentSettings.snowEnabled)
                return;

            SettingsManager.CurrentSettings.snowEnabled = enabled;
            VFXController.Instance.ToggleSnow(SettingsManager.CurrentSettings.snowEnabled);
        }
        // Time of Day
        public static void EnableCycle(bool enabled)
        {
            if (enabled == SettingsManager.CurrentSettings.EnableCycle)
                return;

            SettingsManager.CurrentSettings.EnableCycle = enabled;
            TimeController.Instance.EnableDayNightCycle(SettingsManager.CurrentSettings.EnableCycle);
        }
        #endregion

        #region Player Slider
        public static void UpdatePlayerAnimationSpeed(float newValue)
        {
            SettingsManager.CurrentSettings.Player_AnimationSpeed = newValue;
            PlayerController.Instance.UpdatePlayerAnimationSpeed();
        }
        public static void UpdatePlayerJumpForce(float newValue)
        {
            SettingsManager.CurrentSettings.Player_JumpForce = newValue;
            PlayerController.Instance.UpdatePlayerJumpForce();
        }
        public static void UpdatePlayerMaxFallVelocity(float newValue)
        {
            SettingsManager.CurrentSettings.Player_MaxVelocityToRagDoll = newValue;
            PlayerController.Instance.UpdatePlayerMaxFallVelocity();
        }
        #endregion

        #region Bike Stat Sliders
        // Physics
        public static void UpdateGravitySlider(float newValue)
        {
            SettingsManager.CurrentSettings.Gravity = newValue;
            BMXModController.Instance.UpdateGravity();
        }
        #region Hop Data
        //Hop Data
        public static void UpdateGroundOllie(float newValue)
        {
            SettingsManager.CurrentSettings.BMX_Ground_OllieForce = newValue;
            BMXModController.Instance.UpdateGroundHopData();
        }
        public static void UpdateGroundNollie(float newValue)
        {
            SettingsManager.CurrentSettings.BMX_Ground_NollieForce = newValue;
            BMXModController.Instance.UpdateGroundHopData();
        }
        public static void UpdateGroundQuickHop(float newValue)
        {
            SettingsManager.CurrentSettings.BMX_Ground_QuickHopForce = newValue;
            BMXModController.Instance.UpdateGroundHopData();
        }
        public static void UpdateNoseyOllie(float newValue)
        {
            SettingsManager.CurrentSettings.BMX_Nosey_OllieForce = newValue;
            BMXModController.Instance.UpdateNoseyHopData();
        }
        public static void UpdateNoseyQuickHop(float newValue)
        {
            SettingsManager.CurrentSettings.BMX_Nosey_QuickHopForce = newValue;
            BMXModController.Instance.UpdateNoseyHopData();
        }
        public static void UpdateGrindOllie(float newValue)
        {
            SettingsManager.CurrentSettings.BMX_Grind_OllieForce = newValue;
            BMXModController.Instance.UpdateGrindHopData();
        }
        public static void UpdateGrindNollie(float newValue)
        {
            SettingsManager.CurrentSettings.BMX_Grind_NollieForce = newValue;
            BMXModController.Instance.UpdateGrindHopData();
        }
        public static void UpdateGrindQuickHop(float newValue)
        {
            SettingsManager.CurrentSettings.BMX_Grind_QuickHopForce = newValue;
            BMXModController.Instance.UpdateGrindHopData();
        }
        #endregion

        #region Tricks
        //Tricks
        public static void UpdateTrickAnimationSpeed(float newValue)
        {
            SettingsManager.CurrentSettings.BMX_TrickAnimationSpeed = newValue;
            BMXModController.Instance.UpdateTrickAnimationSpeed();
        }
        public static void UpdatePerefectTweakThreshold(float newValue)
        {
            SettingsManager.CurrentSettings.BMX_PerfectTweakThreshold = newValue;
            BMXModController.Instance.UpdatePerfectTweakThreshold();
        }
        // Peddle
        public static void UpdatePedalForceSlider(float newValue)
        {
            SettingsManager.CurrentSettings.SimpleBMX_PedalForce = newValue;
            BMXModController.Instance.UpdateSimplePedalForce();
        }
        public static void UpdatePedalVelocitySlider(float newValue)
        {
            SettingsManager.CurrentSettings.SimpleBMX_MaxPedalVel = newValue;
            BMXModController.Instance.UpdateSimplePedalVelocity();
        }
        #endregion

        #region Grind
        // Grind
        public static void UpdateGrindHoldForce(float newValue)
        {
            SettingsManager.CurrentSettings.SimpleBMX_GrindHoldForce = newValue;
            BMXModController.Instance.UpdateSimpleGrindHoldForce();
        }
        #endregion

        #region Pumping
        // Pumping
        public static void UpdateSteeringPumpMin(float newValue)
        {
            SettingsManager.CurrentSettings.SimpleBMX_MinPumpForceMulti = newValue;
            BMXModController.Instance.UpdateSteeringPumpForce();
        }
        public static void UpdateSteeringPumpMax(float newValue)
        {
            SettingsManager.CurrentSettings.SimpleBMX_MaxPumpForceMulti = newValue;
            BMXModController.Instance.UpdateSteeringPumpForce();
        }
        public static void UpdateSteeringPumpTime(float newValue)
        {
            SettingsManager.CurrentSettings.SimpleBMX_PumpMinMaxCurveTime = newValue;
            BMXModController.Instance.UpdateSteeringPumpForce();
        }
        #endregion

        #region Manny
        // Manny
        public static void UpdateMannyMaxAngle(float newValue)
        {
            SettingsManager.CurrentSettings.BMX_MannyMaxBailAngle = newValue;
            BMXModController.Instance.UpdateMannyMaxBailAngle();
        }
        public static void UpdateNoseyMaxAngle(float newValue)
        {
            SettingsManager.CurrentSettings.BMX_NoseyMaxBailAngle = newValue;
            BMXModController.Instance.UpdateNoseyMaxBailAngle();
        }
        #endregion

        #endregion

        #region DriftBike Stats Sliders
        public static void UpdateDriftJumpForce(float newValue)
        {
            SettingsManager.CurrentSettings.DriftBike_JumpForce = newValue;
            BMXModController.Instance.UpdateDriftJumpForce();
        }
        public static void UpdateDriftMaxMotorTorque(float newValue)
        {
            SettingsManager.CurrentSettings.DriftBike_MaxMotorTorque = newValue;
            BMXModController.Instance.UpdateDriftMotorTorque();
        }
        public static void UpdateDriftMaxBrakeTorque(float newValue)
        {
            SettingsManager.CurrentSettings.DriftBike_MaxBrakeTorque = newValue;
            BMXModController.Instance.UpdateDriftBrakeTorque();
        }
        public static void UpdateDriftAirFlipTorque(float newValue)
        {
            SettingsManager.CurrentSettings.DriftBike_AirFlipTorque = newValue;
            BMXModController.Instance.UpdateDriftAirFlipTorque();
        }
        public static void UpdateDriftAirSpinTorque(float newValue)
        {
            SettingsManager.CurrentSettings.DriftBike_AirSpinTorque = newValue;
            BMXModController.Instance.UpdateDriftAirSpinTorque();
        }
        public static void UpdateDriftAirUpRightTorque(float newValue)
        {
            SettingsManager.CurrentSettings.DriftBike_AirUpRightTorque = newValue;
            BMXModController.Instance.UpdateDriftAirUpRightTorque();
        }
        public static void UpdateDriftAntiRoll(float newValue)
        {
            SettingsManager.CurrentSettings.DriftBike_AntiRoll = newValue;
            BMXModController.Instance.UpdateDriftAntiRoll();
        }
        public static void UpdateDriftCOMoffset(float newValue)
        {
            SettingsManager.CurrentSettings.DriftBike_COMOffset = newValue;
            BMXModController.Instance.UpdateDriftCOMoffset();
        }
        public static void UpdateDriftTurnTorque(float newValue)
        {
            SettingsManager.CurrentSettings.DriftBike_TurnTorque = newValue;
            BMXModController.Instance.UpdateDriftTurnTorque();
        }
        public static void UpdateDriftTurnResponse(float newValue)
        {
            SettingsManager.CurrentSettings.DriftBike_TurnResponse = newValue;
            BMXModController.Instance.UpdateDriftTurnResponse();
        }
        #endregion

        #region NetworkSliders
        // Network Sliders
        
        public static void UpdateLobbySlider(float newValue)
        {
            int value = Mathf.RoundToInt(newValue);

            SettingsManager.CurrentSettings.MultiRoomSize = value;
            BMXModNetworkController.Instance.UpdateRoomSize();
        }

        #endregion

        #region TimeOfDay Sliders
        // Time Sliders
        public static void UpdateTimeOfDay(float newValue)
        {
            SettingsManager.CurrentSettings.TimeOfDay = newValue;
            TimeController.Instance.UpdateTimeOfDay(); // can't run in upadte so invoking here instead.
        }
        public static void UpdateCycleSpeed(float newValue)
        {
            SettingsManager.CurrentSettings.CycleSpeed = newValue;
            TimeController.Instance.UpdateCycleSpeed();
        }
        public static void UpdateShadowTime(float newValue)
        {
            SettingsManager.CurrentSettings.ShadowUpdateTime = newValue;
            TimeController.Instance.ShadowUpdateTime();
        }
        public static void TimeBetweenSkyUpdates(float newValue)
        {
            SettingsManager.CurrentSettings.TimeBetweenSkyUpdates = newValue;
            TimeController.Instance.UpdateTimeBetweenSkyUpdates();
        }
        #endregion

    }
}

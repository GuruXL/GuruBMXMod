using GuruBMXMod.Gameplay;
using GuruBMXMod.Multi;
using GuruBMXMod.Utils;
using UnityEngine;

namespace GuruBMXMod.UI
{
    internal class UIActionManager
    {
        #region Buttons
        // Buttons
        public static void MainToggle()
        {
            SettingsManager.CurrentSettings.ModEnabled = !SettingsManager.CurrentSettings.ModEnabled;
        }
        public static void ResetToDefaults()
        {
            SettingsManager.ResetToDefault();
        }
        public static void ToggleSimplePedal()
        {
            SettingsManager.CurrentSettings.EnableSimplePedal = !SettingsManager.CurrentSettings.EnableSimplePedal;
            BMXModController.Instance.ToggleSimplePedal();
        }
        public static void UnlockStars()
        {
            SettingsManager.CurrentSettings.UnlockStars = !SettingsManager.CurrentSettings.UnlockStars;
            RewardUnlocks.Instance.UnlockStars("All", SettingsManager.CurrentSettings.UnlockStars);
        }
        public static void UnlockRewards()
        {
            SettingsManager.CurrentSettings.UnlockRewards = !SettingsManager.CurrentSettings.UnlockRewards;
            RewardUnlocks.Instance.UnlockRewards(SettingsManager.CurrentSettings.UnlockRewards);
        }
        public static void SpawnVehicle()
        {
            BMXModController.Instance.SpawnVehicle();
        }
        public static void EnableCycle()
        {
            SettingsManager.CurrentSettings.EnableCycle = !SettingsManager.CurrentSettings.EnableCycle;

            TimeController.Instance.EnableDayNightCycle(SettingsManager.CurrentSettings.EnableCycle);
        }
        public static void SwapSessionMarker()
        {
            SettingsManager.CurrentSettings.SessionMarkerSwapped = !SettingsManager.CurrentSettings.SessionMarkerSwapped;
            //SessionMarkerSwap.Instance.SwapUpAndDownActions();
        }
        public static void ToggleMannyStability()
        {
            SettingsManager.CurrentSettings.MannyAutoStability = !SettingsManager.CurrentSettings.MannyAutoStability;
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
        // Grind
        public static void UpdateGrindHoldForce(float newValue)
        {
            SettingsManager.CurrentSettings.SimpleBMX_GrindHoldForce = newValue;
            BMXModController.Instance.UpdateSimpleGrindHoldForce();
        }
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
        // Manny
        public static void UpdateMannyMaxAngle(float newValue)
        {
            SettingsManager.CurrentSettings.BMX_MannyMaxBailAngle = newValue;
            BMXModController.Instance.UpdateMannyMaxBailAngle();
        }
        public static void UpdateNoseyMaxAngle(float newValue)
        {
            SettingsManager.CurrentSettings.BMX_NoseyMaxBailAngle = newValue;
            BMXModController.Instance.updateNoseyMaxBailAngle();
        }
        #endregion

        #region DriftBike Stats Sliders
        public static void UpdateDriftJumpForce(float newValue)
        {
            SettingsManager.CurrentSettings.DriftBike_JumpForce = newValue;
            BMXModController.Instance.SetDriftJumpForce();
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
            byte bytevalue = (byte)newValue;

            SettingsManager.CurrentSettings.MultiRoomSize = bytevalue;
            BMXModNetworkController.Instance.UpdateRoomSize();
        }
        #endregion

        #region TimeOfDay Sliders
        // Time Sliders
        public static void UpdateTimeOfDay(float newValue)
        {
            SettingsManager.CurrentSettings.TimeOfDay= newValue;
            TimeController.Instance.UpdateTimeOfDay();
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

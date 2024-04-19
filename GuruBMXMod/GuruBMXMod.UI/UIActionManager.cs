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
            Settings.ModEnabled = !Settings.ModEnabled;
        }
        public static void ToggleSimplePedal()
        {
            Settings.EnableSimplePedal = !Settings.EnableSimplePedal;
            BMXModController.Instance.ToggleSimplePedal();
        }
        public static void UnlockStars()
        {
            Settings.UnlockStars = !Settings.UnlockStars;
            RewardUnlocks.Instance.UnlockStars("All", Settings.UnlockStars);
        }
        public static void UnlockRewards()
        {
            Settings.UnlockRewards = !Settings.UnlockRewards;
            RewardUnlocks.Instance.UnlockRewards(Settings.UnlockRewards);
        }
        public static void SpawnVehicle()
        {
            BMXModController.Instance.SpawnVehicle();
        }
        public static void EnableCycle()
        {
            Settings.EnableCycle = !Settings.EnableCycle;

            TimeController.Instance.EnableDayNightCycle(Settings.EnableCycle);
        }
        public static void SwapSessionMarker()
        {
            Settings.SessionMarkerSwapped = !Settings.SessionMarkerSwapped;
            SessionMarkerSwap.Instance.SwapUpAndDownActions();
        }
        #endregion

        #region Bike Stat Sliders
        // Stat Slider
        public static void UpdateGravitySlider(float newValue)
        {
            Settings.Gravity = newValue;
            BMXModController.Instance.UpdateGravity();
        }
        public static void UpdatePedalForceSlider(float newValue)
        {
            Settings.SimpleBMX_PedalForce = newValue;
            BMXModController.Instance.UpdateSimplePedalForce();
        }
        public static void UpdatePedalVelocitySlider(float newValue)
        {
            Settings.SimpleBMX_MaxPedalVel = newValue;
            BMXModController.Instance.UpdateSimplePedalVelocity();
        }
        public static void UpdateGrindHoldForce(float newValue)
        {
            Settings.SimpleBMX_GrindHoldForce = newValue;
            BMXModController.Instance.UpdateSimpleGrindHoldForce();
        }
        #endregion

        #region DriftBike Stats SLiders
        public static void UpdateDriftJumpForce(float newValue)
        {
            Settings.DriftBike_JumpForce = newValue;
            BMXModController.Instance.SetDriftJumpForce();
        }
        public static void UpdateDriftMaxMotorTorque(float newValue)
        {
            Settings.DriftBike_MaxMotorTorque = newValue;
            BMXModController.Instance.UpdateDriftMotorTorque();
        }
        public static void UpdateDriftMaxBrakeTorque(float newValue)
        {
            Settings.DriftBike_MaxBrakeTorque = newValue;
            BMXModController.Instance.UpdateDriftBrakeTorque();
        }
        public static void UpdateDriftAirFlipTorque(float newValue)
        {
            Settings.DriftBike_AirFlipTorque = newValue;
            BMXModController.Instance.UpdateDriftAirFlipTorque();
        }
        public static void UpdateDriftAirSpinTorque(float newValue)
        {
            Settings.DriftBike_AirSpinTorque = newValue;
            BMXModController.Instance.UpdateDriftAirSpinTorque();
        }
        public static void UpdateDriftAirUpRightTorque(float newValue)
        {
            Settings.DriftBike_AirUpRightTorque = newValue;
            BMXModController.Instance.UpdateDriftAirUpRightTorque();
        }
        public static void UpdateDriftAntiRoll(float newValue)
        {
            Settings.DriftBike_AntiRoll = newValue;
            BMXModController.Instance.UpdateDriftAntiRoll();
        }
        public static void UpdateDriftCOMoffset(float newValue)
        {
            Settings.DriftBike_COMOffset = newValue;
            BMXModController.Instance.UpdateDriftCOMoffset();
        }
        public static void UpdateDriftTurnTorque(float newValue)
        {
            Settings.DriftBike_TurnTorque = newValue;
            BMXModController.Instance.UpdateDriftTurnTorque();
        }
        public static void UpdateDriftTurnResponse(float newValue)
        {
            Settings.DriftBike_TurnResponse = newValue;
            BMXModController.Instance.UpdateDriftTurnResponse();
        }
        #endregion

        #region NetworkSliders
        // Network Sliders
        public static void UpdateLobbySlider(float newValue)
        {
            byte bytevalue = (byte)newValue;

            Settings.PlayerLobbySize = bytevalue;
            BMXModNetworkController.Instance.UpdateLobbySize();
        }
        #endregion

        #region TimeOfDay Sliders
        // Time Sliders
        public static void UpdateTimeOfDay(float newValue)
        {
            Settings.TimeOfDay= newValue;
            TimeController.Instance.UpdateTimeOfDay();
        }
        public static void UpdateCycleSpeed(float newValue)
        {
            Settings.CycleSpeed = newValue;
            TimeController.Instance.UpdateCycleSpeed();
        }
        public static void UpdateShadowTime(float newValue)
        {
            Settings.ShadowUpdateTime = newValue;
            TimeController.Instance.ShadowUpdateTime();
        }
        public static void TimeBetweenSkyUpdates(float newValue)
        {
            Settings.TimeBetweenSkyUpdates = newValue;
            TimeController.Instance.UpdateTimeBetweenSkyUpdates();
        }
        #endregion

    }
}

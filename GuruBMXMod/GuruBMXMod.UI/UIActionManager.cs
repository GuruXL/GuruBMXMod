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
            VehicleController.Instance.ToggleSimplePedal();
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
            VehicleController.Instance.SpawnVehicle();
        }
        public static void EnableCycle()
        {
            Settings.EnableCycle = !Settings.EnableCycle;

            TimeController.Instance.EnableDayNightCycle(Settings.EnableCycle);
        }
        public static void SwapSessionMarker()
        {
            Settings.SessionMarkerSwapped = !Settings.SessionMarkerSwapped;
            //SessionMarkerSwap.Instance.SwapUpAndDownActions();
        }
        public static void ToggleMannyStability()
        {
            Settings.MannyAutoStability = !Settings.MannyAutoStability;
        }
        #endregion

        #region Bike Stat Sliders
        // Stat Slider
        public static void UpdateGravitySlider(float newValue)
        {
            Settings.Gravity = newValue;
            VehicleController.Instance.UpdateGravity();
        }
        public static void UpdatePedalForceSlider(float newValue)
        {
            Settings.SimpleBMX_PedalForce = newValue;
            VehicleController.Instance.UpdateSimplePedalForce();
        }
        public static void UpdatePedalVelocitySlider(float newValue)
        {
            Settings.SimpleBMX_MaxPedalVel = newValue;
            VehicleController.Instance.UpdateSimplePedalVelocity();
        }
        public static void UpdateGrindHoldForce(float newValue)
        {
            Settings.SimpleBMX_GrindHoldForce = newValue;
            VehicleController.Instance.UpdateSimpleGrindHoldForce();
        }
        public static void UpdateSteeringPumpMin(float newValue)
        {
            Settings.SimpleBMX_MinPumpForceMulti = newValue;
            VehicleController.Instance.UpdateSteeringPumpForce();
        }
        public static void UpdateSteeringPumpMax(float newValue)
        {
            Settings.SimpleBMX_MaxPumpForceMulti = newValue;
            VehicleController.Instance.UpdateSteeringPumpForce();
        }
        public static void UpdateSteeringPumpTime(float newValue)
        {
            Settings.SimpleBMX_PumpMinMaxCurveTime = newValue;
            VehicleController.Instance.UpdateSteeringPumpForce();
        }
        public static void UpdateMannyMaxAngle(float newValue)
        {
            Settings.BMX_MannyMaxBailAngle = newValue;
            VehicleController.Instance.UpdateMannyMaxBailAngle();
        }
        public static void UpdateNoseyMaxAngle(float newValue)
        {
            Settings.BMX_NoseyMaxBailAngle = newValue;
            VehicleController.Instance.updateNoseyMaxBailAngle();
        }
        #endregion

        #region DriftBike Stats Sliders
        public static void UpdateDriftJumpForce(float newValue)
        {
            Settings.DriftBike_JumpForce = newValue;
            VehicleController.Instance.SetDriftJumpForce();
        }
        public static void UpdateDriftMaxMotorTorque(float newValue)
        {
            Settings.DriftBike_MaxMotorTorque = newValue;
            VehicleController.Instance.UpdateDriftMotorTorque();
        }
        public static void UpdateDriftMaxBrakeTorque(float newValue)
        {
            Settings.DriftBike_MaxBrakeTorque = newValue;
            VehicleController.Instance.UpdateDriftBrakeTorque();
        }
        public static void UpdateDriftAirFlipTorque(float newValue)
        {
            Settings.DriftBike_AirFlipTorque = newValue;
            VehicleController.Instance.UpdateDriftAirFlipTorque();
        }
        public static void UpdateDriftAirSpinTorque(float newValue)
        {
            Settings.DriftBike_AirSpinTorque = newValue;
            VehicleController.Instance.UpdateDriftAirSpinTorque();
        }
        public static void UpdateDriftAirUpRightTorque(float newValue)
        {
            Settings.DriftBike_AirUpRightTorque = newValue;
            VehicleController.Instance.UpdateDriftAirUpRightTorque();
        }
        public static void UpdateDriftAntiRoll(float newValue)
        {
            Settings.DriftBike_AntiRoll = newValue;
            VehicleController.Instance.UpdateDriftAntiRoll();
        }
        public static void UpdateDriftCOMoffset(float newValue)
        {
            Settings.DriftBike_COMOffset = newValue;
            VehicleController.Instance.UpdateDriftCOMoffset();
        }
        public static void UpdateDriftTurnTorque(float newValue)
        {
            Settings.DriftBike_TurnTorque = newValue;
            VehicleController.Instance.UpdateDriftTurnTorque();
        }
        public static void UpdateDriftTurnResponse(float newValue)
        {
            Settings.DriftBike_TurnResponse = newValue;
            VehicleController.Instance.UpdateDriftTurnResponse();
        }
        #endregion

        #region NetworkSliders
        // Network Sliders
        public static void UpdateLobbySlider(float newValue)
        {
            byte bytevalue = (byte)newValue;

            Settings.MultiRoomSize = bytevalue;
            BMXModNetworkController.Instance.UpdateRoomSize();
            BMXModNetworkController.Instance.UpdateRoomInfo();
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

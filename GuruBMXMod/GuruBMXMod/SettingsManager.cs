using GuruBMXMod.UI;

namespace GuruBMXMod
{
    public static class SettingsManager
    {
        public static Settings CurrentSettings { get; set; }
        public static Settings DefaultSettings { get; private set; }

        public static bool IsModMap { get; set; } = false;

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
            ResetButtons();
            ResetSliders();
        }

        #region Reset Default Settings
        private static void ResetButtons()
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
        private static void ResetSliders()
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

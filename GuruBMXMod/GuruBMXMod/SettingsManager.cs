using GuruBMXMod.UI;

namespace GuruBMXMod
{
    public static class SettingsManager
    {
        public static Settings CurrentSettings { get; set; }
        public static Settings DefaultSettings { get; private set; }

        static SettingsManager()
        {
            CurrentSettings = new Settings();
            DefaultSettings = new Settings { ModEnabled = true };
        }

        public static void ResetToDefault()
        {
            CurrentSettings = DefaultSettings.Clone();
        }

        public static void ResetAllSettings()
        {
            ResetToDefault();
            //ResetButtonsToDefault();
            ResetSlidersToDefault();
        }

        private static void ResetButtonsToDefault()
        {
           
        }
        #region Reset Default Settings
        public static void ResetSlidersToDefault()
        {
            // Player Settings
            UIActionManager.UpdatePlayerAnimationSpeed(DefaultSettings.Player_AnimationSpeed);
            UIActionManager.UpdatePlayerJumpForce(DefaultSettings.Player_JumpForce);
            UIActionManager.UpdatePlayerMaxFallVelocity(DefaultSettings.Player_MaxVelocityToRagDoll);

            // Bike Physics
            UIActionManager.UpdateGravitySlider(DefaultSettings.Gravity);

            // BMX Hop Data
            UIActionManager.UpdateGroundOllie(DefaultSettings.BMX_Ground_OllieForce);
            UIActionManager.UpdateGroundNollie(DefaultSettings.BMX_Ground_NollieForce);
            UIActionManager.UpdateGroundQuickHop(DefaultSettings.BMX_Ground_QuickHopForce);
            UIActionManager.UpdateNoseyOllie(DefaultSettings.BMX_Nosey_OllieForce);
            UIActionManager.UpdateNoseyQuickHop(DefaultSettings.BMX_Nosey_QuickHopForce);
            UIActionManager.UpdateGrindOllie(DefaultSettings.BMX_Grind_OllieForce);
            UIActionManager.UpdateGrindNollie(DefaultSettings.BMX_Grind_NollieForce);
            UIActionManager.UpdateGrindQuickHop(DefaultSettings.BMX_Grind_QuickHopForce);

            // BMX Trick Data
            UIActionManager.UpdateTrickAnimationSpeed(DefaultSettings.BMX_TrickAnimationSpeed);
            UIActionManager.UpdatePerefectTweakThreshold(DefaultSettings.BMX_PerfectTweakThreshold);

            // Simple Pedal and Velocity
            UIActionManager.UpdatePedalForceSlider(DefaultSettings.SimpleBMX_PedalForce);
            UIActionManager.UpdatePedalVelocitySlider(DefaultSettings.SimpleBMX_MaxPedalVel);

            // Grind Mechanics
            UIActionManager.UpdateGrindHoldForce(DefaultSettings.SimpleBMX_GrindHoldForce);

            // Steering and Pumping
            UIActionManager.UpdateSteeringPumpMin(DefaultSettings.SimpleBMX_MinPumpForceMulti);
            UIActionManager.UpdateSteeringPumpMax(DefaultSettings.SimpleBMX_MaxPumpForceMulti);
            UIActionManager.UpdateSteeringPumpTime(DefaultSettings.SimpleBMX_PumpMinMaxCurveTime);

            // Manny and Nosey Balancing
            UIActionManager.UpdateMannyMaxAngle(DefaultSettings.BMX_MannyMaxBailAngle);
            UIActionManager.UpdateNoseyMaxAngle(DefaultSettings.BMX_NoseyMaxBailAngle);

            // Drift Bike
            UIActionManager.UpdateDriftJumpForce(DefaultSettings.DriftBike_JumpForce);
            UIActionManager.UpdateDriftMaxMotorTorque(DefaultSettings.DriftBike_MaxMotorTorque);
            UIActionManager.UpdateDriftMaxBrakeTorque(DefaultSettings.DriftBike_MaxBrakeTorque);
            UIActionManager.UpdateDriftAirFlipTorque(DefaultSettings.DriftBike_AirFlipTorque);
            UIActionManager.UpdateDriftAirSpinTorque(DefaultSettings.DriftBike_AirSpinTorque);
            UIActionManager.UpdateDriftAirUpRightTorque(DefaultSettings.DriftBike_AirUpRightTorque);
            UIActionManager.UpdateDriftAntiRoll(DefaultSettings.DriftBike_AntiRoll);
            UIActionManager.UpdateDriftCOMoffset(DefaultSettings.DriftBike_COMOffset);
            UIActionManager.UpdateDriftTurnTorque(DefaultSettings.DriftBike_TurnTorque);
            UIActionManager.UpdateDriftTurnResponse(DefaultSettings.DriftBike_TurnResponse);

            // Time of Day Settings
            UIActionManager.UpdateTimeOfDay(DefaultSettings.TimeOfDay);
            UIActionManager.UpdateCycleSpeed(DefaultSettings.CycleSpeed);
            UIActionManager.UpdateShadowTime(DefaultSettings.ShadowUpdateTime);
            UIActionManager.TimeBetweenSkyUpdates(DefaultSettings.TimeBetweenSkyUpdates);
        }
        #endregion
    }
}

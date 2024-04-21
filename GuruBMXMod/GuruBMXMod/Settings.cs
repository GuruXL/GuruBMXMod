using UnityEngine;

namespace GuruBMXMod
{
    internal class Settings
    {
        public static Color BGColor = new Color(0.85f, 0.90f, 1.0f);

        public static bool ModEnabled = false;

        public static bool IsModMap = false;

        public static bool SessionMarkerSwapped = false;

        public static float Gravity = -12.5f;

        #region Multiplayer
        public static byte MultiRoomSize = 4;
        #endregion

        #region Rewards
        public static bool UnlockStars = false;
        public static bool UnlockRewards = false;
        #endregion

        #region Time Of Day
        // Time of Day
        public static bool EnableCycle = false;
        public static bool ToggleModMapLights = false;
        public static float TimeBetweenSkyUpdates = 2.0f;
        public static float TimeOfDay = 15.0f;
        public static float CycleSpeed = 0.01f;
        public static float ShadowUpdateTime = 0.1f;
        public static float SunIntensity = 20000.0f;
        #endregion

        #region BMX
        public static bool EnableSimplePedal = false;
        public static bool MannyAutoStability = false;
        public static float SimpleBMX_MaxMotorTorque = 1000f;
        public static float SimpleBMX_MaxPedalVel = 9f;
        public static float SimpleBMX_PedalForce = 100f;
        public static float SimpleBMX_GrindHoldForce = 0f;
        public static float SimpleBMX_MinPumpForceMulti = 0f;
        public static float SimpleBMX_MaxPumpForceMulti = 15f;
        public static float SimpleBMX_PumpMinMaxCurveTime = 50f;

        #endregion

        #region Drift Bike
        public static float DriftBike_JumpForce = 500f;
        public static float DriftBike_MaxMotorTorque = 700f;
        public static float DriftBike_MaxBrakeTorque = 1000f;
        public static float DriftBike_AirFlipTorque = 1500f;
        public static float DriftBike_AirSpinTorque = 0f;
        public static float DriftBike_AntiRoll = 0f;
        public static float DriftBike_AirUpRightTorque = 5f;
        public static float DriftBike_COMOffset = -0.12f;
        public static float DriftBike_TurnTorque = 2000f;
        public static float DriftBike_TurnResponse = 5f;
        #endregion

    }
}

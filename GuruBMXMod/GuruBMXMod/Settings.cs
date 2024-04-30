using Il2CppHellTap.MeshDecimator.Unity;
using UnityEngine;

namespace GuruBMXMod
{
    public class Settings
    {
        public Settings Clone()
        {
            return (Settings)MemberwiseClone();
        }

        public Color BGColor = new Color(0.85f, 0.90f, 1.0f);

        public bool ModEnabled = false;

        public bool IsModMap = false;

        public bool SessionMarkerSwapped = false;

        public float Gravity = -12.5f;

        #region Multiplayer
        public byte MultiRoomSize = 4;
        #endregion

        #region Rewards
        public bool UnlockStars = false;
        public bool UnlockRewards = false;
        #endregion

        #region Time Of Day
        // Time of Day
        public bool EnableCycle = false;
        public bool ToggleModMapLights = false;
        public float TimeBetweenSkyUpdates = 2.0f;
        public float TimeOfDay = 15.0f;
        public float CycleSpeed = 0.01f;
        public float ShadowUpdateTime = 0.1f;

        public float SunIntensity = 20000.0f;
        #endregion

        #region Player
        public float Player_AnimationSpeed = 1f;
        public float Player_JumpForce = 8.0f;
        public float Player_MaxVelocityToRagDoll = -13.0f;
        #endregion

        #region HopForces
        public float BMX_Ground_OllieForce = 4.0f;
        public float BMX_Ground_NollieForce = 3.0f;
        public float BMX_Ground_QuickHopForce = 2.5f;
        public float BMX_Nosey_OllieForce = 4.2f;
        public float BMX_Nosey_QuickHopForce = 3.2f;
        public float BMX_Grind_OllieForce = 3.3f;
        public float BMX_Grind_NollieForce = 3.0f;
        public float BMX_Grind_QuickHopForce = 2.6f;
        #endregion

        #region BMX
        public bool EnableSimplePedal = false;
        public bool MannyAutoStability = false;
        public float SimpleBMX_MaxMotorTorque = 1000f;
        public float SimpleBMX_MaxPedalVel = 9f;
        public float SimpleBMX_PedalForce = 100f;
        public float SimpleBMX_GrindHoldForce = 0f;
        public float SimpleBMX_MinPumpForceMulti = 0f;
        public float SimpleBMX_MaxPumpForceMulti = 15f;
        public float SimpleBMX_PumpMinMaxCurveTime = 50f;
        public float BMX_MannyMaxBailAngle = 60f;
        public float BMX_NoseyMaxBailAngle = 60f;
        public float BMX_TrickAnimationSpeed = 1f;
        public float BMX_PerfectTweakThreshold = 0.2f;

        #endregion

        #region Drift Bike
        public float DriftBike_JumpForce = 500f;
        public float DriftBike_MaxMotorTorque = 700f;
        public float DriftBike_MaxBrakeTorque = 1000f;
        public float DriftBike_AirFlipTorque = 1500f;
        public float DriftBike_AirSpinTorque = 0f;
        public float DriftBike_AntiRoll = 0f;
        public float DriftBike_AirUpRightTorque = 5f;
        public float DriftBike_COMOffset = -0.12f;
        public float DriftBike_TurnTorque = 2000f;
        public float DriftBike_TurnResponse = 5f;
        #endregion

    }
}

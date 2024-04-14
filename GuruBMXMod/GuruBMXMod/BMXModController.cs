using UnityEngine;
using MelonLoader;
using Il2Cpp;
using HarmonyLib;
using Il2CppMG_Gameplay;
using System.Collections.Generic;
using System.Collections;

namespace GuruBMXMod
{
    public class BMXModController
    {
        public static BMXModController __instance { get; private set; }
        public static BMXModController Instance => __instance ?? (__instance = new BMXModController());

        public SimplePedalForce simplePedalForce;
        public SimpleGrindForce simpleGrindForce;

        public DriftTrikeController driftBike;
        public BikeController bike; // find reference for this in game

        public VehicleSpawner vehicleSpawner;

        public void GetBikeComponents()
        {
            MelonLogger.Msg("Getting Bike Componenets...");
            try
            {
                simplePedalForce = PlayerComponents.m_Instance.gameObject.GetComponentInChildren<SimplePedalForce>(true);
                simpleGrindForce = PlayerComponents.m_Instance.gameObject.GetComponentInChildren<SimpleGrindForce>();
                vehicleSpawner = PlayerComponents.m_Instance.gameObject.GetComponentInChildren<VehicleSpawner>();
                driftBike = vehicleSpawner.gameObject.GetComponentInChildren<DriftTrikeController>(true);
            }
            catch (Exception ex)
            {
                MelonLogger.Msg("Bike Components Exception: " + ex.Message);
            }
            finally
            {
                if (simplePedalForce != null && vehicleSpawner != null && driftBike != null)
                {
                    MelonLogger.Msg("All Bike Components Found");
                }
                if (simplePedalForce == null)
                {
                    MelonLogger.Msg("simplePedalForce NOT found");
                }
                if (vehicleSpawner == null)
                {
                    MelonLogger.Msg("vehicleSpawner NOT found");
                }
                if (driftBike == null)
                {
                    MelonLogger.Msg("Drift Bike NOT found");
                }        
            }
        }
      
        public void UpdateGravity()
        {
            if (Physics.gravity.y == Settings.Gravity)
                return;

            Physics.gravity = new Vector3(Physics.gravity.x, Settings.Gravity, Physics.gravity.z);
        }

        #region Simple BMX
        public void ToggleSimplePedal()
        {
            simplePedalForce.enabled = Settings.EnableSimplePedal;
        }
        public void UpdateSimplePedalForce()
        {
            if (simplePedalForce.pedalForce == Settings.SimpleBMX_PedalForce)
                return;

            simplePedalForce.pedalForce = Settings.SimpleBMX_PedalForce;
        }
        public void UpdateSimplePedalVelocity()
        {
            if (simplePedalForce.maxPedalVel == Settings.SimpleBMX_MaxPedalVel)
                return;

            simplePedalForce.maxPedalVel = Settings.SimpleBMX_MaxPedalVel;
        }
        public void UpdateSimpleGrindHoldForce()
        {
            if (simpleGrindForce.holdForce == Settings.SimpleBMX_GrindHoldForce)
                return;

            simpleGrindForce.holdForce = Settings.SimpleBMX_GrindHoldForce;
        }
        #endregion

        #region Drift Bike
        public void SpawnVehicle() // spawns driftbike
        {
            if (!Settings.UnlockStars)
            {
                RewardUnlocks.Instance.UnlockStars("All", true);
                vehicleSpawner.SpawnVehicle();
                RewardUnlocks.Instance.UnlockStars("All", false);
            }
            vehicleSpawner.SpawnVehicle();
        }
        public void SetDriftJumpForce()
        {
            if (driftBike.jumpForce == Settings.DriftBike_JumpForce)
                return;

            driftBike.jumpForce = Settings.DriftBike_JumpForce;
        }
        public void UpdateDriftMotorTorque()
        {
            if (driftBike.maxMotorTorque == Settings.DriftBike_MaxMotorTorque)
                return;

            driftBike.maxMotorTorque = Settings.DriftBike_MaxMotorTorque;
        }
        public void UpdateDriftBrakeTorque()
        {
            if (driftBike.maxBrakeTorque == Settings.DriftBike_MaxBrakeTorque)
                return;

            driftBike.maxBrakeTorque = Settings.DriftBike_MaxBrakeTorque;
        }
        public void UpdateDriftAirFlipTorque()
        {
            if (driftBike.airFlipTorqueBody == Settings.DriftBike_AirFlipTorque)
                return;

            driftBike.airFlipTorqueBody = Settings.DriftBike_AirFlipTorque;
        }
        public void UpdateDriftAirSpinTorque()
        {
            if (driftBike.airSpinTorqueBody == Settings.DriftBike_AirSpinTorque)
                return;

            driftBike.airSpinTorqueBody = Settings.DriftBike_AirSpinTorque;
        }
        public void UpdateDriftAirUpRightTorque()
        {
            if (driftBike.airUpRightTorque == Settings.DriftBike_AirUpRightTorque)
                return;

            driftBike.airUpRightTorque = Settings.DriftBike_AirUpRightTorque;
        }
        public void UpdateDriftAntiRoll()
        {
            if (driftBike.AntiRoll == Settings.DriftBike_AntiRoll)
                return;
        }
        public void UpdateDriftCOMoffset()
        {
            Vector3 COMoffset = new Vector3 (0, Settings.DriftBike_COMOffset, 0);
            if (driftBike.centerOfMassOffset == COMoffset)
                return;

            driftBike.centerOfMassOffset = COMoffset;
        }
        public void UpdateDriftTurnTorque()
        {
            if (driftBike.yawTorque == Settings.DriftBike_TurnTorque)
                return;

            driftBike.yawTorque = Settings.DriftBike_TurnTorque;
        }
        public void UpdateDriftTurnResponse()
        {
            if (driftBike.steeringLerpSpeed == Settings.DriftBike_TurnResponse)
                return;

            driftBike.steeringLerpSpeed = Settings.DriftBike_TurnResponse;
        }
        #endregion
    }
}

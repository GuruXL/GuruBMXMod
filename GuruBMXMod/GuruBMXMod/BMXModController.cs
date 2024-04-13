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
        //public SimpleGrindForce simpleGrindForce;

        public DriftTrikeController driftBike;
        public BikeController bike; // find reference for this in game

        public VehicleSpawner vehicleSpawner;

        public void GetBikeComponents()
        {
            MelonLogger.Msg("Getting Bike Componenets...");
            try
            {
                simplePedalForce = PlayerComponents.m_Instance.gameObject.GetComponentInChildren<SimplePedalForce>(true);
                //simpleGrindForce = PlayerComponents.m_Instance.gameObject.GetComponentInChildren<SimpleGrindForce>();
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
            float gravity = Physics.gravity.y;

            if (gravity != Settings.Gravity)
            {
                Physics.gravity = new Vector3(Physics.gravity.x, Settings.Gravity, Physics.gravity.z);
            }
        }

        // BMX
        public void ToggleSimplePedal()
        {
            simplePedalForce.enabled = Settings.EnableSimplePedal;
        }
        public void UpdatePedalForces()
        {
            if (simplePedalForce.pedalForce != Settings.PedalForce)
            {
                simplePedalForce.pedalForce = Settings.PedalForce;
            }
            else if (simplePedalForce.maxPedalVel != Settings.MaxPedalVel)
            {
                simplePedalForce.maxPedalVel = Settings.MaxPedalVel;
            }
        }
        /*
        public void UpdateGrindHoldForce()
        {
            if (simpleGrindForce.holdForce != Settings.GrindHoldForce)
            {
                simpleGrindForce.holdForce = Settings.GrindHoldForce;
            }
        }
        */

        // Drift Bike 
        public void SpawnVehicle() // spawns driftbike
        {
            RewardUnlocks.Instance.UnlockStars("All", true);
            vehicleSpawner.SpawnVehicle();
            RewardUnlocks.Instance.UnlockStars("All", false);
        }
    }
}

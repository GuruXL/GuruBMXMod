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

        //public TimeOfDayController todController; // find reference
        public TimeOfDayManager todManager;

        public RewardNotificatonBehaviour rewardsBehavior;
        public UnityGameEventListener unlockRewardListener;
        public UnityGameEventListener lockRewardListener;

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
        public void GetSmartDataComponents()
        {
            MelonLogger.Msg("Getting Smart Data Componenets...");
            try
            {
               rewardsBehavior = UnityEngine.Object.FindObjectOfType<RewardNotificatonBehaviour>();

                if (rewardsBehavior != null)
                {
                    GetRewardListeners();
                }
            }
            catch (Exception ex)
            {
                MelonLogger.Msg("Smart Data Components NOT Found: " + ex.Message);
            }
            finally
            {
                if (rewardsBehavior != null)
                {
                    MelonLogger.Msg("Smart Data Components Found");
                }
                else
                {
                    MelonLogger.Msg("Smart Data Components NOT found");
                }
            }
        }
        private void GetRewardListeners()
        {
            Transform smartDataObj = rewardsBehavior.gameObject.transform.Find("Smart Data Features");
            Transform unlockObj = smartDataObj.Find("UnlockAllRewards_GameEvent");
            Transform lockObj = smartDataObj.Find("LockAllRewards_GameEvent");

            unlockRewardListener = unlockObj.gameObject.GetComponent<UnityGameEventListener>();
            lockRewardListener = lockObj.gameObject.GetComponent<UnityGameEventListener>();
        }
        public void GetTimeOfDayComponents()
        {
            MelonLogger.Msg("Getting Time Of Day Components...");
            try
            {
                todManager = UnityEngine.Object.FindObjectOfType<TimeOfDayManager>();
            }
            catch (Exception ex)
            {
                MelonLogger.Msg("Time of Day Exception: " + ex.Message);
            }
            finally
            {
                if (todManager != null)
                {
                    MelonLogger.Msg("Time of Day Components Found");
                }
                else
                {
                    MelonLogger.Msg("Time of Day Components NOT found");
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
        public void UnlockStars(string value, bool state)
        {
            if (value == "All")
            {
                vehicleSpawner._starSystemManagerData.overrideReturnAllStars = state;
            }
            else if (value == "Zero")
            {
                vehicleSpawner._starSystemManagerData.overrideReturnZEROStars = state;
            }
        }

        public void SpawnVehicle()
        {
            UnlockStars("All", true);
            vehicleSpawner.SpawnVehicle();
            UnlockStars("All", false);
        }
    }
}

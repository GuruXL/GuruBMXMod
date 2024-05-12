using UnityEngine;
using MelonLoader;
using Il2Cpp;
using HarmonyLib;
using Il2CppMG_Gameplay;
using System.Collections.Generic;
using System.Collections;
using GuruBMXMod.Utils;
using Il2CppMG_StateMachine;
using Il2CppDiasGames.ThirdPersonSystem;

namespace GuruBMXMod.Gameplay
{
    public class BMXModController
    {
        public static BMXModController __instance { get; private set; }
        public static BMXModController Instance => __instance ?? (__instance = new BMXModController());

        public static bool bmxComponentsLoaded { get; private set; } = false;

        // BMX
        private PlayerAbilityDataBehaviour playerAbilityDataBehaviour;
        private BMXAnimationControl animationControl;
        private SimplePedalForce simplePedalForce;
        private SimpleGrindForce simpleGrindForce;
        private SimpleSteeringPumpForce simpleSteeringPumpForce;
        private MannyStateBehaviour mannyStateBehaviour;
        private NoseyStateBehaviour noseyStateBehaviour;

        private HopBehaviour hopBehaviour;

        private HopDataSet Grounded_HopData;
        private HopDataSet Nosey_HopData;
        private HopDataSet Grind_HopData;

        //private TestBalance testBalance;

        private DriftTrikeController driftTrike;
        public VehicleSpawner vehicleSpawner;

        public void GetBikeComponents()
        {
            MelonLogger.Msg("Getting Bike Components...");
            try
            {
                simplePedalForce = PlayerComponents.GetInstance().gameObject.GetComponentInChildren<SimplePedalForce>(true);
                simpleGrindForce = PlayerComponents.GetInstance().gameObject.GetComponentInChildren<SimpleGrindForce>();
                vehicleSpawner = PlayerComponents.GetInstance().gameObject.GetComponentInChildren<VehicleSpawner>();
                simpleSteeringPumpForce = PlayerComponents.GetInstance().gameObject.GetComponentInChildren<SimpleSteeringPumpForce>();
                driftTrike = vehicleSpawner.gameObject.GetComponentInChildren<DriftTrikeController>(true);
                animationControl = PlayerComponents.GetInstance().gameObject.GetComponentInChildren<BMXAnimationControl>();
                mannyStateBehaviour = UnityEngine.Object.FindObjectOfType<MannyStateBehaviour>();
                noseyStateBehaviour = UnityEngine.Object.FindObjectOfType<NoseyStateBehaviour>();
                playerAbilityDataBehaviour = GameWorld.GetInstance().gameObject.GetComponentInChildren<PlayerAbilityDataBehaviour>();
                GetHopData();

            }
            catch (Exception ex)
            {
                MelonLogger.Msg("Bike Components Exception: " + ex.Message);
            }
            finally
            {
                CheckBikeComponents();
            }
        }

        private void GetHopData()
        {
            //HopDataSet[] hopDataSets = UnityEngine.Object.FindObjectsOfType<HopDataSet>();
            HopDataSet[] hopDataSets = Resources.FindObjectsOfTypeAll<HopDataSet>();

            if (hopDataSets.Length == 0)
                return;

            foreach (HopDataSet dataSet in hopDataSets)
            {
                switch (dataSet.name)
                {
                    case "Grounded_HopDataSet":
                        Grounded_HopData = dataSet;
                        break;
                    case "Nosey_HopDataSet":
                        Nosey_HopData = dataSet;
                        break;
                    case "Grind_HopDataSet":
                        Grind_HopData = dataSet;
                        break;
                }
            }
        }

        private void CheckBikeComponents()
        {
            // Creating a dictionary for dynamic checking
            Dictionary<string, object> components = new Dictionary<string, object>
            {
            {"simplePedalForce", simplePedalForce},
            {"simpleGrindForce", simpleGrindForce},
            {"vehicleSpawner", vehicleSpawner},
            {"simpleSteeringPumpForce", simpleSteeringPumpForce},
            {"driftTrike", driftTrike},
            {"animationControl", animationControl},
            {"mannyStateBehaviour", mannyStateBehaviour},
            {"noseyStateBehaviour", noseyStateBehaviour},
            {"playerAbilityDataBehaviour", playerAbilityDataBehaviour},
            {"Grounded_HopData", Grounded_HopData},
            {"Nosey_HopData", Nosey_HopData},
            {"Grind_HopData", Grind_HopData}
            };

            if (ComponentCheck.CheckComponents(components, "Bike"))
            {
                bmxComponentsLoaded = true;
            }
        }


        public void UpdateGravity()
        {
            if (Physics.gravity.y == SettingsManager.CurrentSettings.Gravity)
                return;

            Physics.gravity = new Vector3(Physics.gravity.x, SettingsManager.CurrentSettings.Gravity, Physics.gravity.z);
        }

        #region BMX

        #region Hop Data
        public void UpdateGroundHopData()
        {
            if (Grounded_HopData == null)
                return;

            if (Grounded_HopData._olliehopDataLarge._hopForce != SettingsManager.CurrentSettings.BMX_Ground_OllieForce)
            {
                Grounded_HopData._olliehopDataLarge._hopForce = SettingsManager.CurrentSettings.BMX_Ground_OllieForce;
            }
            if (Grounded_HopData._nolliehopDataLarge._hopForce != SettingsManager.CurrentSettings.BMX_Ground_NollieForce)
            {
                Grounded_HopData._nolliehopDataLarge._hopForce = SettingsManager.CurrentSettings.BMX_Ground_NollieForce;
            }
            if (Grounded_HopData._quickHopData._hopForce != SettingsManager.CurrentSettings.BMX_Ground_QuickHopForce)
            {
                Grounded_HopData._quickHopData._hopForce = SettingsManager.CurrentSettings.BMX_Ground_QuickHopForce;
            }
        }
        public void UpdateNoseyHopData()
        {
            if (Nosey_HopData == null)
                return;

            if (Nosey_HopData._olliehopDataLarge._hopForce != SettingsManager.CurrentSettings.BMX_Nosey_OllieForce)
            {
                Nosey_HopData._olliehopDataLarge._hopForce = SettingsManager.CurrentSettings.BMX_Nosey_OllieForce;
            }
            if (Nosey_HopData._quickHopData._hopForce != SettingsManager.CurrentSettings.BMX_Nosey_QuickHopForce)
            {
                Nosey_HopData._quickHopData._hopForce = SettingsManager.CurrentSettings.BMX_Nosey_QuickHopForce;
            }
        }
        public void UpdateGrindHopData()
        {
            if (Grind_HopData == null)
                return;

            if (Grind_HopData._olliehopDataLarge._hopForce != SettingsManager.CurrentSettings.BMX_Grind_OllieForce)
            {
                Grind_HopData._olliehopDataLarge._hopForce = SettingsManager.CurrentSettings.BMX_Grind_OllieForce;
            }
            if (Grind_HopData._nolliehopDataLarge._hopForce != SettingsManager.CurrentSettings.BMX_Grind_NollieForce)
            {
                Grind_HopData._nolliehopDataLarge._hopForce = SettingsManager.CurrentSettings.BMX_Grind_NollieForce;
            }
            if (Grind_HopData._quickHopData._hopForce != SettingsManager.CurrentSettings.BMX_Grind_QuickHopForce)
            {
                Grind_HopData._quickHopData._hopForce = SettingsManager.CurrentSettings.BMX_Grind_QuickHopForce;
            }
        }
        #endregion

        // Tricks
        public void UpdateTrickAnimationSpeed()
        {
            if (animationControl.bmxAnimator.speed == SettingsManager.CurrentSettings.BMX_TrickAnimationSpeed)
                return;

            animationControl.bmxAnimator.speed = SettingsManager.CurrentSettings.BMX_TrickAnimationSpeed;
        }
        public void UpdatePerfectTweakThreshold()
        {
            if (playerAbilityDataBehaviour._playerAbilityData.perfectTweakThreshold == SettingsManager.CurrentSettings.BMX_PerfectTweakThreshold)
                return;

            playerAbilityDataBehaviour._playerAbilityData.perfectTweakThreshold = SettingsManager.CurrentSettings.BMX_PerfectTweakThreshold;
        }
        // Peddle
        public void ToggleSimplePedal()
        {
            if (simplePedalForce.enabled == SettingsManager.CurrentSettings.EnableSimplePedal)
                return;

            simplePedalForce.enabled = SettingsManager.CurrentSettings.EnableSimplePedal;
        }
        public void UpdateSimplePedalForce()
        {
            if (simplePedalForce.pedalForce == SettingsManager.CurrentSettings.SimpleBMX_PedalForce)
                return;

            simplePedalForce.pedalForce = SettingsManager.CurrentSettings.SimpleBMX_PedalForce;
        }
        public void UpdateSimplePedalVelocity()
        {
            if (simplePedalForce.maxPedalVel == SettingsManager.CurrentSettings.SimpleBMX_MaxPedalVel)
                return;

            simplePedalForce.maxPedalVel = SettingsManager.CurrentSettings.SimpleBMX_MaxPedalVel;
        }
        public void UpdateBrakeForce()
        {
        }
        // Grinds
        public void UpdateSimpleGrindHoldForce()
        {
            if (simpleGrindForce.holdForce == SettingsManager.CurrentSettings.SimpleBMX_GrindHoldForce)
                return;

            simpleGrindForce.holdForce = SettingsManager.CurrentSettings.SimpleBMX_GrindHoldForce;
        }
        // Pumping
        public void UpdateSteeringPumpForce()
        {
            if(simpleSteeringPumpForce.pumpForcePerVelocityMagMutlipler.GetKey(0).value == SettingsManager.CurrentSettings.SimpleBMX_MinPumpForceMulti ||
            simpleSteeringPumpForce.pumpForcePerVelocityMagMutlipler.GetKey(1).value == SettingsManager.CurrentSettings.SimpleBMX_MaxPumpForceMulti ||
            simpleSteeringPumpForce.pumpForcePerVelocityMagMutlipler.GetKey(1).time == SettingsManager.CurrentSettings.SimpleBMX_PumpMinMaxCurveTime)
                return;

            AnimationCurveModifier.ModifyMinMaxCurve(simpleSteeringPumpForce.pumpForcePerVelocityMagMutlipler,
                SettingsManager.CurrentSettings.SimpleBMX_MinPumpForceMulti,
                SettingsManager.CurrentSettings.SimpleBMX_MaxPumpForceMulti,
                SettingsManager.CurrentSettings.SimpleBMX_PumpMinMaxCurveTime);
        }
        // Manny
        public void UpdateMannyMaxBailAngle()
        {
            if (mannyStateBehaviour.maxBailAngle == SettingsManager.CurrentSettings.BMX_MannyMaxBailAngle)
                return;

            mannyStateBehaviour.maxBailAngle = SettingsManager.CurrentSettings.BMX_MannyMaxBailAngle;
        }
        public void UpdateNoseyMaxBailAngle()
        {
            if (noseyStateBehaviour.maxBailAngle == SettingsManager.CurrentSettings.BMX_NoseyMaxBailAngle)
                return;

            noseyStateBehaviour.maxBailAngle = SettingsManager.CurrentSettings.BMX_NoseyMaxBailAngle;
        }
        #endregion

        #region Drift Bike
        public void SpawnVehicle() // spawns driftbike
        {
            if (!SettingsManager.CurrentSettings.UnlockStars)
            {
                RewardUnlocks.Instance.UnlockStars("All", true);
                vehicleSpawner.SpawnVehicle();
                RewardUnlocks.Instance.UnlockStars("All", false);
            }
            vehicleSpawner.SpawnVehicle();
        }
        public void UpdateDriftJumpForce()
        {
            if (driftTrike.jumpForce == SettingsManager.CurrentSettings.DriftBike_JumpForce)
                return;

            driftTrike.jumpForce = SettingsManager.CurrentSettings.DriftBike_JumpForce;
        }
        public void UpdateDriftMotorTorque()
        {
            if (driftTrike.maxMotorTorque == SettingsManager.CurrentSettings.DriftBike_MaxMotorTorque)
                return;

            driftTrike.maxMotorTorque = SettingsManager.CurrentSettings.DriftBike_MaxMotorTorque;
        }
        public void UpdateDriftBrakeTorque()
        {
            if (driftTrike.maxBrakeTorque == SettingsManager.CurrentSettings.DriftBike_MaxBrakeTorque)
                return;

            driftTrike.maxBrakeTorque = SettingsManager.CurrentSettings.DriftBike_MaxBrakeTorque;
        }
        public void UpdateDriftAirFlipTorque()
        {
            if (driftTrike.airFlipTorqueBody == SettingsManager.CurrentSettings.DriftBike_AirFlipTorque)
                return;

            driftTrike.airFlipTorqueBody = SettingsManager.CurrentSettings.DriftBike_AirFlipTorque;
        }
        public void UpdateDriftAirSpinTorque()
        {
            if (driftTrike.airSpinTorqueBody == SettingsManager.CurrentSettings.DriftBike_AirSpinTorque)
                return;

            driftTrike.airSpinTorqueBody = SettingsManager.CurrentSettings.DriftBike_AirSpinTorque;
        }
        public void UpdateDriftAirUpRightTorque()
        {
            if (driftTrike.airUpRightTorque == SettingsManager.CurrentSettings.DriftBike_AirUpRightTorque)
                return;

            driftTrike.airUpRightTorque = SettingsManager.CurrentSettings.DriftBike_AirUpRightTorque;
        }
        public void UpdateDriftAntiRoll()
        {
            if (driftTrike.AntiRoll == SettingsManager.CurrentSettings.DriftBike_AntiRoll)
                return;
        }
        public void UpdateDriftCOMoffset()
        {
            Vector3 COMoffset = new Vector3(0, SettingsManager.CurrentSettings.DriftBike_COMOffset, 0);
            if (driftTrike.centerOfMassOffset == COMoffset)
                return;

            driftTrike.centerOfMassOffset = COMoffset;
        }
        public void UpdateDriftTurnTorque()
        {
            if (driftTrike.yawTorque == SettingsManager.CurrentSettings.DriftBike_TurnTorque)
                return;

            driftTrike.yawTorque = SettingsManager.CurrentSettings.DriftBike_TurnTorque;
        }
        public void UpdateDriftTurnResponse()
        {
            if (driftTrike.steeringLerpSpeed == SettingsManager.CurrentSettings.DriftBike_TurnResponse)
                return;

            driftTrike.steeringLerpSpeed = SettingsManager.CurrentSettings.DriftBike_TurnResponse;
        }
        #endregion
    } 
}

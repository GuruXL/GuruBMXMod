﻿using UnityEngine;
using MelonLoader;
using Il2Cpp;
using HarmonyLib;
using Il2CppMG_Gameplay;
using System.Collections.Generic;
using System.Collections;
using GuruBMXMod.Utils;
using UnityEngine.UIElements.UIR;

namespace GuruBMXMod.Gameplay
{
    public class RewardUnlocks
    {
        public static RewardUnlocks __instance { get; private set; }
        public static RewardUnlocks Instance => __instance ?? (__instance = new RewardUnlocks());

        public static bool smartComponentsLoaded { get; private set; } = false;

        public static bool rewardsUnlocked { get; private set; } = false;

        //public RewardNotificatonBehaviour rewardsBehavior;
        public RewardContainerBehaviour rewardsBehavior;
        public UnityGameEventListener unlockRewardListener;
        public UnityGameEventListener lockRewardListener;

        public void GetSmartDataComponents()
        {
            MelonLogger.Msg("Getting Smart Data Components...");
            try
            {
                //rewardsBehavior = UnityEngine.Object.FindObjectOfType<RewardNotificatonBehaviour>();
                rewardsBehavior = UnityEngine.Object.FindObjectOfType<RewardContainerBehaviour>();

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
                CheckRewardComponents();
            }
        }
        private void CheckRewardComponents()
        {
            // Creating a dictionary for dynamic checking
            Dictionary<string, object> components = new Dictionary<string, object>
            {
            {"rewardsBehavior", rewardsBehavior},
            {"unlockRewardListener", unlockRewardListener},
            {"lockRewardListener", lockRewardListener},
            };

            if (ComponentCheck.CheckComponents(components, "Smart Data"))
            {
                smartComponentsLoaded = true;
            }
        }
        private void GetRewardListeners()
        {
            //Transform smartDataObj = rewardsBehavior.gameObject.transform.Find("Smart Data Features");
            Transform smartDataObj = rewardsBehavior.transform.parent;
            if (smartDataObj != null)
            {
                MelonLogger.Msg("Smart Data Features obj Found");
            }

            UnityGameEventListener[] events = new UnityGameEventListener[smartDataObj.childCount];
            events = smartDataObj.GetComponentsInChildren<UnityGameEventListener>();
            MelonLogger.Msg($"Listeners found: {events.Length}");

            foreach (UnityGameEventListener listner in events)
            {
                if (listner.gameObject.name == "UnlockAllRewards_GameEvent")
                {
                    unlockRewardListener = listner;
                }
                else if (listner.gameObject.name == "LockAllRewards_GameEvent")
                {
                    lockRewardListener = listner;
                }
            }
        }

        public void UnlockStars(string value, bool state)
        {
            if (value == "All")
            {
                BMXModController.Instance.vehicleSpawner._starSystemManagerData.overrideReturnAllStars = state;
            }
            else if (value == "Zero")
            {
                BMXModController.Instance.vehicleSpawner._starSystemManagerData.overrideReturnZEROStars = state;
            }
        }
        public void UnlockRewards(bool unlock)
        {
            if (unlock)
            {
                unlockRewardListener.RaiseEvent();
                rewardsUnlocked = true;
            }
            else
            {
                lockRewardListener.RaiseEvent();
                rewardsUnlocked = false;
            }
        }
    }
}

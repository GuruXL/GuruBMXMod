using UnityEngine;
using MelonLoader;
using Il2Cpp;
using HarmonyLib;
using Il2CppMG_Gameplay;
using System.Collections.Generic;
using System.Collections;

namespace GuruBMXMod
{
    public class RewardUnlocks
    {
        public static RewardUnlocks __instance { get; private set; }
        public static RewardUnlocks Instance => __instance ?? (__instance = new RewardUnlocks());

        //public RewardNotificatonBehaviour rewardsBehavior;
        public RewardContainerBehaviour rewardsBehavior;
        public UnityGameEventListener unlockRewardListener;
        public UnityGameEventListener lockRewardListener;

        public void GetSmartDataComponents()
        {
            MelonLogger.Msg("Getting Smart Data Componenets...");
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
                if (rewardsBehavior != null && unlockRewardListener && lockRewardListener != null)
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

            if (unlockRewardListener != null && lockRewardListener != null)
            {
                MelonLogger.Msg("Reward Components Found");
            }
            else
            {
                if (unlockRewardListener == null)
                    MelonLogger.Msg("UnlockAllRewards_GameEvent Listener not found");

                if (lockRewardListener == null)
                    MelonLogger.Msg("LockAllRewards_GameEvent Listener not found");
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
            }
            else
            {
                lockRewardListener.RaiseEvent();
            }
        }
    }
}

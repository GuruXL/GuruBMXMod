using UnityEngine;
using MelonLoader;
using Il2Cpp;
using HarmonyLib;
using Il2CppMG_Gameplay;
using System.Collections.Generic;
using System.Collections;

namespace GuruBMXMod
{
    public class TimeController
    {
        public static TimeController __instance { get; private set; }
        public static TimeController Instance => __instance ?? (__instance = new TimeController());

       
        public TimeOfDayManager todManager;

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

        public void EnableCycle(bool enabled)
        {
            todManager.isPlaying = enabled;
        }

        public void UpdateTimeOfDay()
        {
            if (todManager.timeOfDay != Settings.TimeOfDay)
            {
                //todManager.timeOfDay = Settings.TimeOfDay;
                todManager.SetTimeOfDay(Settings.TimeOfDay);
            }
        }
        public void UpdateTimeBetweenSkyUpdates()
        {
            if (todManager.timeBetweenSkyUpdates != Settings.TimeBetweenSkyUpdates)
            {
                todManager.timeBetweenSkyUpdates = Settings.TimeBetweenSkyUpdates;
            }
        }

        public void UpdateCycleSpeed()
        {
            if (todManager.timeOfDayMoveSpeed != Settings.CycleSpeed)
            {
                todManager.timeOfDayMoveSpeed = Settings.CycleSpeed;
            }
        }

        public void ShadowUpdateTime()
        {
            if (todManager._updateShadowsTime != Settings.ShadowUpdateTime)
            {
                todManager._updateShadowsTime = Settings.ShadowUpdateTime;
            }   
        }

        /*
        public void SetSunIntensity()
        {
            todManager.sunLight.intensity = Settings.SunIntensity;
        }
        */
    }
}

﻿using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;
using MelonLoader;
using Il2Cpp;
using HarmonyLib;
using Il2CppMG_Gameplay;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using System.ComponentModel;
using UnityEngine.Profiling;
using GuruBMXMod.Utils;

namespace GuruBMXMod.Gameplay
{
    public class TimeController
    {
        public static TimeController __instance { get; private set; }
        public static TimeController Instance => __instance ?? (__instance = new TimeController());

        public static bool timeComponentsLoaded { get; private set; } = false;

        public TimeOfDayManager todManager;

        public MGModMapManager modMapManger;

        //private Volume todVolume;
        public Bloom todBloom;
        public IndirectLightingController todIndirectLight;

        public void GetTimeOfDayComponents()
        {
            MelonLogger.Msg("Getting Time Of Day Components...");
            try
            {
                todManager = UnityEngine.Object.FindObjectOfType<TimeOfDayManager>();

                //todVolume = GetTODVolume();

                /*
                if (todVolume != null)
                {
                    GetVolumeComponents();
                }
                */

            }
            catch (Exception ex)
            {
                MelonLogger.Msg("Time of Day Exception: " + ex.Message);
            }
            finally
            {
                CheckTimeComponents();
            }
        }
        private void CheckTimeComponents()
        {
            // Creating a dictionary for dynamic checking
            Dictionary<string, object> components = new Dictionary<string, object>
            {
            {"todManager", todManager}
            //{"todVolume", todVolume}
            };

            if (ComponentCheck.CheckComponents(components, "Time"))
            {
                timeComponentsLoaded = true;
            }
        }
        private Volume GetTODVolume()
        {
            Transform extraPost = todManager.transform.parent.transform.Find("ExtraPost");
            Volume volume = extraPost.gameObject.GetComponent<Volume>();

            if (volume == null)
            {
                MelonLogger.Msg($" Unable to Find TOD volume Component");
            }
            return volume;
        }

        public void GetModMapComponents(string scenename)
        {
            try
            {
                modMapManger = UnityEngine.Object.FindObjectOfType<MGModMapManager>();
            }
            catch (Exception ex)
            {
                MelonLogger.Msg("Mod Map Exception: " + ex.Message);
            }
            finally
            {
                if (modMapManger != null)
                {
                    MelonLogger.Msg($"Mod Map Components Found for {scenename}");
                }
            }
        }

        private void PlayCycle(bool enabled)
        {
            todManager.isPlaying = enabled;
        }
        private void ToggleModMapLighting(bool enabled)
        {
            modMapManger.EnableDisableLightingObjects(!enabled);
            todManager.transform.parent.gameObject.SetActive(enabled);
        }
        private void RemoveMenuListeners()
        {
            modMapManger.OnClosePauseMenu.OnRaise.RemoveAllListeners();
        }

        public void EnableDayNightCycle(bool enabled)
        {
            PlayCycle(enabled);

            if (!SettingsManager.IsModMap)
                return;

            if (modMapManger == null)
                return;

            ToggleModMapLighting(enabled);

            if (enabled)
            {
                // need to remove listners so the modded map lighting stays off after exiting pause menu.
                RemoveMenuListeners();
            }
            else if (!enabled)
            {
                // this will re add the menu listeners once the cycle is off.
                modMapManger.enabled = false;
                modMapManger.enabled = true;
            }
        }


        #region TOD Updates
        public void UpdateTimeOfDay()
        {
            if (todManager.timeOfDay == SettingsManager.CurrentSettings.TimeOfDay)
                return;

            todManager.SetTimeOfDay(SettingsManager.CurrentSettings.TimeOfDay);
        }

        public void UpdateTimeBetweenSkyUpdates()
        {
            if (todManager.timeBetweenSkyUpdates == SettingsManager.CurrentSettings.TimeBetweenSkyUpdates)
                return;

            todManager.timeBetweenSkyUpdates = SettingsManager.CurrentSettings.TimeBetweenSkyUpdates;
        }

        public void UpdateCycleSpeed()
        {
            if (todManager.timeOfDayMoveSpeed == SettingsManager.CurrentSettings.CycleSpeed)
                return;

            todManager.timeOfDayMoveSpeed = SettingsManager.CurrentSettings.CycleSpeed;
        }

        public void ShadowUpdateTime()
        {
            if (todManager._updateShadowsTime == SettingsManager.CurrentSettings.ShadowUpdateTime)
                return;

            todManager._updateShadowsTime = SettingsManager.CurrentSettings.ShadowUpdateTime;
        }
        #endregion

        /*
        public void SetSunIntensity()
        {
            todManager.sunLight.intensity = SettingsManager.CurrentSettings.SunIntensity;
        }
        */
    }
}

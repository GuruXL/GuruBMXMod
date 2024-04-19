using UnityEngine;
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

namespace GuruBMXMod
{
    public class TimeController
    {
        public static TimeController __instance { get; private set; }
        public static TimeController Instance => __instance ?? (__instance = new TimeController());

       
        public TimeOfDayManager todManager;

        public MGModMapManager modMapManger;

        private Volume todVolume;
        public Bloom todBloom;
        public IndirectLightingController todIndirectLight;

        public void GetTimeOfDayComponents()
        {
            MelonLogger.Msg("Getting Time Of Day Components...");
            try
            {
                todManager = UnityEngine.Object.FindObjectOfType<TimeOfDayManager>();

                todVolume = GetTODVolume();

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
                if (todManager != null && todVolume != null)
                {
                    MelonLogger.Msg("Time of Day Components Found");
                }
                else
                {
                    if (todManager == null)
                    {
                        MelonLogger.Msg($"TOD Manager NOT Found");
                    }
                    if (todVolume == null)
                    {
                        MelonLogger.Msg($"TOD Volume NOT Found");
                    }
                }
                
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

        
        private void GetVolumeComponents()
        {
            try
            {
                //todVolume.profile.TryGet(todBloom);
                //todVolume.profile.TryGet(todIndirectLight);

            }
            catch (Exception ex)
            {
                MelonLogger.Msg("Exception while Getting Volume Components: " + ex.Message);
            }
            finally
            {
                if (todBloom != null && todIndirectLight != null)
                {
                    MelonLogger.Msg("All Volume profile components found.");
                }
                else
                {
                    if (todBloom == null)
                    {
                        MelonLogger.Msg("Bloom Not Found.");
                    }
                    if (todIndirectLight == null)
                    {
                        MelonLogger.Msg("Indirect Light Not Found.");
                    }
                }
            }
            /*
            for (int i = 0; i < todVolume.profile.components.Count; i++)
            {
                if (todVolume.profile.components[i] is Bloom bloom)
                {
                    //todBloom = bloom;
                    todVolume.profile.TryGet(todBloom);
                }
                else if (todVolume.profile.components[i] is IndirectLightingController light)
                {
                    //todIndirectLight = light;
                    todVolume.profile.TryGet(todIndirectLight);
                }
            }
            */
            /*
            foreach (VolumeComponent comp in todVolume.profile.components)
            {
                if (comp.GetType() == typeof(Bloom))
                {
                    todBloom = (Bloom)comp;
                }
                else if (comp.GetType() == typeof(IndirectLightingController))
                {
                    todIndirectLight = (IndirectLightingController)comp;
                }
            }
            */
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

        public void PlayCycle(bool enabled)
        {
            todManager.isPlaying = enabled;
        }
        public void ToggleModMapLighting(bool enabled)
        {
            modMapManger.EnableDisableLightingObjects(!enabled);
            todManager.transform.parent.gameObject.SetActive(enabled);
        }
        public void RemoveMenuListeners()
        {
            modMapManger.OnClosePauseMenu.OnRaise.RemoveAllListeners();
        }
        public void EnableDayNightCycle(bool enabled)
        {
            PlayCycle(enabled);

            if (!Settings.IsModMap)
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
        public void UpdateTimeOfDay()
        {
            if (todManager.timeOfDay == Settings.TimeOfDay)
                return;

            todManager.SetTimeOfDay(Settings.TimeOfDay);
        }
        public void UpdateTimeBetweenSkyUpdates()
        {
            if (todManager.timeBetweenSkyUpdates == Settings.TimeBetweenSkyUpdates)
                return;

            todManager.timeBetweenSkyUpdates = Settings.TimeBetweenSkyUpdates;
        }

        public void UpdateCycleSpeed()
        {
            if (todManager.timeOfDayMoveSpeed == Settings.CycleSpeed)
                return;

            todManager.timeOfDayMoveSpeed = Settings.CycleSpeed;
        }

        public void ShadowUpdateTime()
        {
            if (todManager._updateShadowsTime == Settings.ShadowUpdateTime)
                return;

            todManager._updateShadowsTime = Settings.ShadowUpdateTime;
        }
        /*
        public void SetSunIntensity()
        {
            todManager.sunLight.intensity = Settings.SunIntensity;
        }
        */
    }
}

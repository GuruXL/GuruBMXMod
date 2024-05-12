using GuruBMXMod.Utils;
using Il2Cpp;
using Il2CppMG_Gameplay;
using Il2CppMG_Gameplay.Player;
using Il2CppCinemachine;
using Il2CppSystem.Reflection;
using MelonLoader;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.VFX;
using System.Reflection;

namespace GuruBMXMod.Gameplay
{
    public class VFXController
    {
        public static VFXController __instance { get; private set; }
        public static VFXController Instance => __instance ?? (__instance = new VFXController());

        public static bool VFXComponentsLoaded { get; private set; } = false;

        //public GameObject snowObj;
        //public GameObject rainObj;
        private GameObject snowObj_PS;
        private GameObject rainObj_PS;

        private ParticleSystem snowPS;
        private ParticleSystem rainPS;

        private bool AssetsLoaded()
        {
            return AssetLoader.assetsLoaded;
        }

        public void RunUpdate(Camera cam)
        {
            if (SettingsManager.CurrentSettings.rainEnabled)
            {
                AttachToCamera(cam, rainObj_PS);
            }
            if (SettingsManager.CurrentSettings.snowEnabled)
            {
                AttachToCamera(cam, snowObj_PS);
            }
        }

        private void GetVFXComponents()
        {
            MelonLogger.Msg("Getting VFX Components...");
            try
            {
                snowPS = snowObj_PS.GetComponent<ParticleSystem>();
                rainPS = rainObj_PS.GetComponent<ParticleSystem>();

            }
            catch (Exception ex)
            {
                MelonLogger.Msg("VFX Components Exception: " + ex.Message);
            }
            finally
            {
                CheckVFXComponents();
            }
        }
        private void CheckVFXComponents()
        {
            // Creating a dictionary for dynamic checking
            Dictionary<string, object> components = new Dictionary<string, object>
            {
            {"snowPS", snowPS},
            {"rainPS", rainPS}
            };

            if (ComponentCheck.CheckComponents(components, "VFX"))
            {
                VFXComponentsLoaded = true;
            }
        }

        public void LoadVFXAssets()
        {
            if (!AssetsLoaded())
            {
                MelonLogger.Msg("Unable to Load VFX: Assets Not Loaded");
            }
            else
            {
                InitPrefabs();
            }
        }

        private void InitPrefabs()
        {
            rainObj_PS = UnityEngine.Object.Instantiate(AssetLoader.rainPrefab_PS);
            rainObj_PS.transform.SetParent(AssetLoader.ScriptManager.transform);
            rainObj_PS.SetActive(SettingsManager.CurrentSettings.rainEnabled);

            snowObj_PS = UnityEngine.Object.Instantiate(AssetLoader.snowPrefab_PS);
            snowObj_PS.transform.SetParent(AssetLoader.ScriptManager.transform);
            snowObj_PS.SetActive(SettingsManager.CurrentSettings.snowEnabled);

            GetVFXComponents();
        }

        public void ToggleRain(bool enabled)
        {
            if (rainObj_PS != null)
            {
                rainObj_PS.SetActive(enabled);
            }
        }
        public void ToggleSnow(bool enabled)
        {
            if (snowObj_PS != null)
            {
                snowObj_PS.SetActive(enabled);
            }
        }

        private void AttachToCamera(Camera cam, GameObject obj)
        {
            if (cam != null && obj.activeSelf)
            {
                obj.transform.position = cam.transform.position + new Vector3(0, 10, 0);
            }
        }
    }
}

using GuruBMXMod.Utils;
using Il2CppMG_Gameplay;
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

namespace GuruBMXMod.Gameplay
{
    public class VFXController
    {
        public static VFXController __instance { get; private set; }
        public static VFXController Instance => __instance ?? (__instance = new VFXController());

        public GameObject snowObj;
        public GameObject rainObj;
        public GameObject snowObj_PS;

        private bool AssetsLoaded()
        {
            return AssetLoader.assetsLoaded;
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
            snowObj = UnityEngine.Object.Instantiate(AssetLoader.snowPrefab);
            snowObj.transform.SetParent(AssetLoader.ScriptManager.transform);
            snowObj.SetActive(false);

            rainObj = UnityEngine.Object.Instantiate(AssetLoader.rainPrefab);
            rainObj.transform.SetParent(AssetLoader.ScriptManager.transform);
            rainObj.SetActive(false);

            snowObj_PS = UnityEngine.Object.Instantiate(AssetLoader.snowPrefab_PS);
            snowObj_PS.transform.SetParent(AssetLoader.ScriptManager.transform);
            snowObj_PS.SetActive(false);
        }
    }
}

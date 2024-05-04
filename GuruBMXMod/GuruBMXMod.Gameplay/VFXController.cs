using GuruBMXMod.Utils;
using MelonLoader;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem.XR;

namespace GuruBMXMod.Gameplay
{
    public class VFXController : MonoBehaviour
    {
        public GameObject snowObj;
        public GameObject rainObj;

        private void Awake()
        {
            InitPrefabs();
        }

        private void Start()
        {

        }

        private bool AssetsLoaded()
        {
            return AssetLoader.assetsLoaded;
        }

        private IEnumerator InitPrefabs()
        {
            yield return new WaitUntil((Il2CppSystem.Func<bool>)AssetsLoaded);

            snowObj = Instantiate(AssetLoader.snowPrefab);
            snowObj.transform.SetParent(AssetLoader.ScriptManager.transform);
            snowObj.SetActive(false);

            rainObj = Instantiate(AssetLoader.rainPrefab);
            rainObj.transform.SetParent(AssetLoader.ScriptManager.transform);
            rainObj.SetActive(false);
        }     
    }
}

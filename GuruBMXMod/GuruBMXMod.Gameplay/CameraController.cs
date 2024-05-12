using GuruBMXMod.Utils;
using Il2Cpp;
using MelonLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace GuruBMXMod.Gameplay
{
    public class CameraController
    {
        
        public static CameraController __instance { get; private set; }
        public static CameraController Instance => __instance ?? (__instance = new CameraController());

        public static bool CamComponentsLoaded { get; private set; } = false;

        public Camera mainCam;

        public void GetCameraComponents()
        {
            MelonLogger.Msg("Getting Camera Components...");
            try
            {
                mainCam = PlayerComponents.GetInstance().gameplayCamera.gameObject.GetComponent<Camera>();
            }
            catch (Exception ex)
            {
                MelonLogger.Msg("Camera Components Exception: " + ex.Message);
            }
            finally
            {
                CheckCamComponents();
            }
        }

        private void CheckCamComponents()
        {
            // Creating a dictionary for dynamic checking
            Dictionary<string, object> components = new Dictionary<string, object>
            {
            {"mainCam", mainCam}
            };

            if (ComponentCheck.CheckComponents(components, "Bike"))
            {
                CamComponentsLoaded = true;
            }
        }
    }
}

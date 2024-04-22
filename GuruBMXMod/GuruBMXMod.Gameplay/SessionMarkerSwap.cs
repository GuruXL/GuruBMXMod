using Il2Cpp;
using MelonLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GuruBMXMod.Gameplay
{
    public class SessionMarkerSwap
    {
        /*
        public static SessionMarkerSwap __instance { get; private set; }
        public static SessionMarkerSwap Instance => __instance ?? (__instance = new SessionMarkerSwap());

        private  SessionMarkerBasic sessionMarker;

        private  InputSystemEventCallback placeCallback;
        private  InputSystemEventCallback resetCallback;

       // private  InputActionAsset inputActionAsset;

        private  InputBinding originalUpBinding;
        private  InputBinding originalDownBinding;

        private  InputAction upAction;
        private  InputAction downAction;

       
        public  void GetInputComponents()
        {
            MelonLogger.Msg("Getting Input Components...");
            try
            {
                sessionMarker = PlayerComponents.GetInstance().gameObject.GetComponentInChildren<SessionMarkerBasic>();

                Transform placeOBJ = sessionMarker.transform.Find("Request Place Input Event");
                Transform ResetOBJ = sessionMarker.transform.Find("Request Reset At Marker");

                placeCallback = placeOBJ.GetComponent<InputSystemEventCallback>();
                resetCallback = ResetOBJ.GetComponent<InputSystemEventCallback>();

                GetInputBindings();
            }
            catch (Exception ex)
            {
                MelonLogger.Msg("Input Components Exception: " + ex.Message);
            }
            finally
            {
                if (sessionMarker != null && placeCallback != null && resetCallback != null)
                {
                    MelonLogger.Msg("Input Components Found");
                }
                else
                {
                    if (sessionMarker == null)
                    {
                        MelonLogger.Msg("sessionMarker NOT found");
                    }
                    if (placeCallback == null)
                    {
                        MelonLogger.Msg("placeCallback NOT found");
                    }
                    if (resetCallback == null)
                    {
                        MelonLogger.Msg("resetCallback NOT found");
                    }
                }
            }
        }
        public void GetInputBindings()
        {
            if (placeCallback != null && resetCallback != null)
            {
                upAction = placeCallback._inputAction;
                downAction = resetCallback._inputAction;

                originalUpBinding = upAction.bindings[0];
                originalDownBinding = downAction.bindings[0];
            }

            //InputActionMap actionMap = placeCallback.GetInputActionMap();
        }

        public void SwapUpAndDownActions()
        {
            if (upAction == null || downAction == null)
            {
                MelonLogger.Msg("Input actions have not been initialized.");
                return;
            }

            // Disable the actions if they are enabled
            if (upAction.enabled) upAction.Disable();
            if (downAction.enabled) downAction.Disable();

            if (!Settings.SessionMarkerSwapped)
            {
                // Swap the bindings
                upAction.ApplyBindingOverride(originalDownBinding);
                downAction.ApplyBindingOverride(originalUpBinding);
            }
            else
            {
                // Revert the bindings
                upAction.ApplyBindingOverride(originalUpBinding);
                downAction.ApplyBindingOverride(originalDownBinding);
            }

            // Toggle the swapped state
            Settings.SessionMarkerSwapped = !Settings.SessionMarkerSwapped;

            // Enable the actions again
            upAction.Enable();
            downAction.Enable();
        }
        */
    }
}

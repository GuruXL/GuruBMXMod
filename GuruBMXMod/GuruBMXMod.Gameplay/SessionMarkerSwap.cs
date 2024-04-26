using GuruBMXMod.Utils;
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
                CheckInputComponents();
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
        private void CheckInputComponents()
        {
            // Creating a dictionary for dynamic checking
            Dictionary<string, object> components = new Dictionary<string, object>
            {
            {"sessionMarker", sessionMarker},
            {"placeCallback", placeCallback},
            {"resetCallback", resetCallback},
            {"upAction", upAction},
            {"downAction", downAction},
            {"originalUpBinding", originalUpBinding},
            {"originalDownBinding", originalDownBinding},
            };

            ComponentCheck.CheckComponents(components, "Input");
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

            if (!SettingsManager.CurrentSettings.SessionMarkerSwapped)
            {
                // Swap the bindings
                //upAction.ApplyBindingOverride(originalDownBinding);
                //downAction.ApplyBindingOverride(originalUpBinding);

                // Swap the bindings
                upAction.ChangeBindingWithPath(upAction.name).WithPath(originalDownBinding.path);
                downAction.ChangeBindingWithPath(downAction.name).WithPath(originalUpBinding.path);
            }
            else
            {
                // Revert the bindings
                //upAction.ApplyBindingOverride(originalUpBinding);
                //downAction.ApplyBindingOverride(originalDownBinding);

                // Swap the bindings
                upAction.ChangeBindingWithPath(upAction.name).WithPath(originalUpBinding.path);
                downAction.ChangeBindingWithPath(downAction.name).WithPath(originalDownBinding.path);
            }

            // Toggle the swapped state
            //SettingsManager.CurrentSettings.SessionMarkerSwapped = !SettingsManager.CurrentSettings.SessionMarkerSwapped;

            // Enable the actions again
            upAction.Enable();
            downAction.Enable();
        }
        */
    }
}

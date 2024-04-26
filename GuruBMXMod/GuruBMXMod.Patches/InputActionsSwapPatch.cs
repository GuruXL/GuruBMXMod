using HarmonyLib;
using Il2Cpp;
using UnityEngine.InputSystem;

namespace GuruBMXMod.Patches
{
    /*
    [HarmonyPatch(typeof(MGStandardInputActions), "Enable")]
    public class InputActionsSwapPatch
    {
        
        static void Postfix(MGStandardInputActions __instance)
        {
            // Access the Player action map
            var playerActions = __instance.Player;

            // Swap bindings for "Place Marker" and "Request Marker"
            var placeMarkerAction = playerActions.RequestPlaceMarker;
            var requestMarkerAction = playerActions.RequestResetAtMarker;

            // Get the current bindings
            var placeBinding = placeMarkerAction.bindings[0]; // Assuming the first binding is what you want to swap
            var requestBinding = requestMarkerAction.bindings[0];

            // Swap the bindings
            placeMarkerAction.ChangeBindingWithPath(placeBinding.m_Name).WithPath(requestBinding.path);
            requestMarkerAction.ChangeBindingWithPath(requestBinding.m_Name).WithPath(placeBinding.path);

            // You might need to re-enable the actions if necessary
            playerActions.Enable();
        }
        
    }
    */
}

using HarmonyLib;
using Il2CppCom.MyCompany.MyGame;
using System.Reflection;
using Il2CppPhoton.Pun;
using UnityEngine;
using GuruBMXMod.Multi;
using MelonLoader;
using Il2Cpp;
using GuruBMXMod.Utils;

namespace GuruBMXMod.Patches
{
    [HarmonyPatch(typeof(NetworkingSessionScriptableObject), "SetMaxPlayers")]
    public static class NSSOPatch
    {
        // Patches a 2 - 16 clamp for SetMaxPlayers
        public static bool Prefix(NetworkingSessionScriptableObject __instance, ref int numPlayers)
        {
            if (numPlayers > 16)
            {
                __instance._maxPlayers = numPlayers;
                //MelonLogger.Msg($"SetMaxPlayers called with numPlayers: {numPlayers}");
                return false;  // Skip the original method to prevent clamping in the original method
            }

            //MelonLogger.Msg($"SetMaxPlayers Origianl Method Run");
            return true;  // Continue with the original method if within limits
        }
    }
}

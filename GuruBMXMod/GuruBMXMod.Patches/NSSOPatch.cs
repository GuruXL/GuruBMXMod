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
        static bool Prefix(NetworkingSessionScriptableObject __instance, ref int numPlayers)
        {
            if (numPlayers <= 16)
            {
                return true;
            }
            else
            {
                __instance._maxPlayers = numPlayers;
                MelonLogger.Msg($"NSSOPatch Run: Max Players update: {__instance._maxPlayers}");
                return false;
            }
            
        }
    }
}

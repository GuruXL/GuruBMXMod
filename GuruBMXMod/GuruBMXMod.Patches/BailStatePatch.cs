using HarmonyLib;
using Il2CppCom.MyCompany.MyGame;
using System.Reflection;
using Il2CppPhoton.Pun;
using UnityEngine;
using GuruBMXMod.Multi;
using MelonLoader;
using Il2Cpp;
using GuruBMXMod.Utils;
using Il2CppMG_StateMachine;

namespace GuruBMXMod.Patches
{
    [HarmonyPatch(typeof(StateMachine), "SetState", new Type[] { typeof(int), typeof(bool) })]
    static class BailStatePatch
    {
        static bool Prefix(StateMachine __instance, int index, bool forceChange = false)
        {
            if (SettingsManager.CurrentSettings.DisableBail && index == 5)
            {
                return false;
            }
            return true;
        }
    }

    [HarmonyPatch(typeof(DrivableGameplayVehicle), "ExitVehicle", new Type[] { typeof(bool) })]
    static class ExitVehiclePatch
    {
        static bool Prefix(DrivableGameplayVehicle __instance, bool exitToRagdoll)
        {
            if (SettingsManager.CurrentSettings.DisableBail && exitToRagdoll == true)
            {
                return false;
            }
            return true;
        }
    }
}

﻿using HarmonyLib;
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

    [HarmonyPatch(typeof(MannyStateBehaviour), "OnStateEnter")]
    public static class MannyOnStateEnterPatch
    {
        static void Postfix(int lastState, MannyStateBehaviour __instance)
        {
            if (SettingsManager.CurrentSettings.MannyAutoStability)
            {
                __instance.testBalance.forceUpNormal = true;
                //MelonLogger.Msg($"On Enter Manny Stability: {__instance.testBalance.forceUpNormal}");
            }
            else if (!SettingsManager.CurrentSettings.MannyAutoStability && __instance.testBalance.forceUpNormal)
            {
                __instance.testBalance.forceUpNormal = false;
                //MelonLogger.Msg($"On Enter Manny Stability: {__instance.testBalance.forceUpNormal}");
            }
        }
    }

    [HarmonyPatch(typeof(MannyStateBehaviour), "OnStateExit")]
    public static class MannyOnStateExitPatch
    {
        static void Postfix(int nextState, MannyStateBehaviour __instance)
        {
            __instance.testBalance.forceUpNormal = false;
            //MelonLogger.Msg($"On Exit Manny Stability: {__instance.testBalance.forceUpNormal}");
        }
    }

    [HarmonyPatch(typeof(NoseyStateBehaviour), "OnStateEnter")]
    public static class NoseyOnStateEnterPatch
    {
        static void Postfix(int lastState, NoseyStateBehaviour __instance)
        {
            if (SettingsManager.CurrentSettings.MannyAutoStability)
            {
                __instance.testBalance.forceUpNormal = true;
                //MelonLogger.Msg($"On Enter Nosey Stability: {__instance.testBalance.forceUpNormal}");
            }
            else if (!SettingsManager.CurrentSettings.MannyAutoStability && __instance.testBalance.forceUpNormal)
            {
                __instance.testBalance.forceUpNormal = false;
                //MelonLogger.Msg($"On Enter Nosey Stability: {__instance.testBalance.forceUpNormal}");
            }
        }
    }

    [HarmonyPatch(typeof(NoseyStateBehaviour), "OnStateExit")]
    public static class NoseyOnStateExitPatch
    {
        static void Postfix(int nextState, NoseyStateBehaviour __instance)
        {
            __instance.testBalance.forceUpNormal = false;
            //MelonLogger.Msg($"On Exit Manny Stability: {__instance.testBalance.forceUpNormal}");
        }
    }
}

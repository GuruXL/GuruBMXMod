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
    [HarmonyPatch(typeof(PUNManager), "OnJoinedRoom")]
    public static class OnJoinedRoomPatch
    {
        public static void Postfix(PUNManager __instance)
        {
            if (PhotonNetwork.CurrentRoom == null || PhotonNetwork.IsMasterClient)
                return;

            if (PhotonNetwork.CurrentRoom.MaxPlayers > (int)__instance.maxPlayersPerRoom)
            {
                SettingsManager.CurrentSettings.MultiRoomSize = (byte)PhotonNetwork.CurrentRoom.MaxPlayers;
                BMXModNetworkController.Instance.UpdateRoomSize();

                MelonLogger.Msg($"OnJoinRoomPatch Run: Max Players update: {__instance.maxPlayersPerRoom}");
            }
        }
    }
}

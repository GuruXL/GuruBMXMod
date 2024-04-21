﻿using Il2Cpp;
using Il2CppCom.MyCompany.MyGame;
using Il2CppPhoton.Pun;
using MelonLoader;
using System.Reflection;
using System.Security.AccessControl;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace GuruBMXMod.Multi
{
    public class BMXModNetworkController
    {
        public static BMXModNetworkController __instance { get; private set; }
        public static BMXModNetworkController Instance => __instance ?? (__instance = new BMXModNetworkController());

        private NetworkRoomInfo roomInfo;

        //private NetworkingSessionScriptableObject netWorkSession;

        public void GetNetworkComponenets()
        {
            MelonLogger.Msg("Getting NetWork Componenets...");
            try
            {
                roomInfo = PUNManager.Instance.transform.parent.gameObject.GetComponentInChildren<NetworkRoomInfo>();

                //netWorkSession.SetMaxPlayers(Settings.PlayerLobbySize);

            }
            catch (Exception ex)
            {
                MelonLogger.Msg("Network Components Exception: " + ex.Message);
            }
            finally
            {
                if (roomInfo != null)
                {
                    MelonLogger.Msg("All Network Components Found");
                }
                else if (roomInfo == null)
                {
                    MelonLogger.Msg("Room Info NOT found");
                }
            }
        }

        public void UpdatePUNRoomSize()
        {
            /*
            if (netWorkSession != null)
            {
                netWorkSession.SetMaxPlayers(Settings.PlayerLobbySize);
            }
            */
            if (PUNManager.Instance.maxPlayersPerRoom != Settings.MultiRoomSize)
            {
                PUNManager.Instance.maxPlayersPerRoom = Settings.MultiRoomSize;
            }
        }
        public void UpdateRoomInfo()
        {
            if (roomInfo.currentSessionInfo != null)
            {
                roomInfo.currentSessionInfo.SetMaxPlayers(Settings.MultiRoomSize);
                //MelonLogger.Msg($"Room Info Updated: Max Players:{roomInfo.currentSessionInfo._maxPlayers}");
            }
        }
    }
}

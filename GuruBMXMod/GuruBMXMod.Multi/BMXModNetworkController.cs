using Il2Cpp;
using Il2CppCom.MyCompany.MyGame;
using Il2CppPhoton.Pun;
using MelonLoader;
using System.Reflection;
using System.Security.AccessControl;
using UnityEngine;

namespace GuruBMXMod.Multi
{
    public class BMXModNetworkController
    {
        public static BMXModNetworkController __instance { get; private set; }
        public static BMXModNetworkController Instance => __instance ?? (__instance = new BMXModNetworkController());

        private NetworkRoomInfo roomInfo;

        public void GetNetworkComponenets()
        {
            MelonLogger.Msg("Getting NetWork Componenets...");
            try
            {
                roomInfo = PUNManager.Instance.transform.parent.gameObject.GetComponentInChildren<NetworkRoomInfo>();
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

        public void UpdateLobbySize()
        {
            int lobbysize = Settings.PlayerLobbySize;

            if (PUNManager.Instance.maxPlayersPerRoom != Settings.PlayerLobbySize)
            {
                PUNManager.Instance.maxPlayersPerRoom = Settings.PlayerLobbySize;
            }
            if (roomInfo != null && roomInfo.currentSessionInfo._maxPlayers != lobbysize)
            {
                //roomInfo.currentSessionInfo.SetMaxPlayers(lobbysize);
                roomInfo.currentSessionInfo._maxPlayers = lobbysize;
            }
            if (roomInfo != null && roomInfo._clientNetworkingPlayerData._playerGameStatusInfo._maxSessionPlayers != lobbysize)
            {
                roomInfo._clientNetworkingPlayerData._playerGameStatusInfo._maxSessionPlayers = lobbysize;
            }
        }
    }
}

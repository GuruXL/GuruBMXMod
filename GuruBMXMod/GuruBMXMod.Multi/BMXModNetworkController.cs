using Il2CppCom.MyCompany.MyGame;
using Il2CppPhoton.Pun;
using System.Reflection;
using UnityEngine;

namespace GuruBMXMod.Multi
{
    public class BMXModNetworkController
    {
        public static BMXModNetworkController __instance { get; private set; }
        public static BMXModNetworkController Instance => __instance ?? (__instance = new BMXModNetworkController());

        public void UpdateLobbySize()
        {
            if (PUNManager.Instance.maxPlayersPerRoom != Settings.PlayerLobbySize)
            {
                PUNManager.Instance.maxPlayersPerRoom = Settings.PlayerLobbySize;
            }
        }
    }
}

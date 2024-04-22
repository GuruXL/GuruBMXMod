using GuruBMXMod.Utils;
using Il2Cpp;
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

                //netWorkSession.SetMaxPlayers(SettingsManager.CurrentSettings.PlayerLobbySize);

            }
            catch (Exception ex)
            {
                MelonLogger.Msg("Network Components Exception: " + ex.Message);
            }
            finally
            {
                CheckNetworkComponents();
            }
        }
        private void CheckNetworkComponents()
        {
            // Creating a dictionary for dynamic checking
            Dictionary<string, object> components = new Dictionary<string, object>
            {
            {"roomInfo", roomInfo},
            };

            ComponentCheck.CheckComponents(components, "Network");
        }
        public void UpdateRoomSize()
        {
            /*
            if (netWorkSession != null)
            {
                netWorkSession.SetMaxPlayers(SettingsManager.CurrentSettings.PlayerLobbySize);
            }
            */
            if (PUNManager.Instance.maxPlayersPerRoom != SettingsManager.CurrentSettings.MultiRoomSize)
            {
                PUNManager.Instance.maxPlayersPerRoom = SettingsManager.CurrentSettings.MultiRoomSize;
            }
            if (Launcher.Instance.maxPlayersPerRoom != SettingsManager.CurrentSettings.MultiRoomSize)
            {
                Launcher.Instance.maxPlayersPerRoom = SettingsManager.CurrentSettings.MultiRoomSize;
            }
        }
        public void UpdateRoomInfo()
        {
            if (roomInfo.currentSessionInfo != null)
            {
                roomInfo.currentSessionInfo.SetMaxPlayers(SettingsManager.CurrentSettings.MultiRoomSize);
                //MelonLogger.Msg($"Room Info Updated: Max Players:{roomInfo.currentSessionInfo._maxPlayers}");
            }
        }
    }
}

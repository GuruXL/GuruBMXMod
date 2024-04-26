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
        /*
        public static BMXModNetworkController __instance { get; private set; }
        public static BMXModNetworkController Instance => __instance ?? (__instance = new BMXModNetworkController());

        private NetworkRoomInfo roomInfo;

        public void GetNetworkComponenets()
        {
            MelonLogger.Msg("Getting Network Components...");
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
            try
            {
                if (PUNManager.Instance != null)
                {
                    if (PUNManager.Instance.maxPlayersPerRoom != SettingsManager.CurrentSettings.MultiRoomSize)
                    {
                        PUNManager.Instance.maxPlayersPerRoom = SettingsManager.CurrentSettings.MultiRoomSize;
                    }
                    if (Launcher.Instance.maxPlayersPerRoom != SettingsManager.CurrentSettings.MultiRoomSize)
                    {
                        Launcher.Instance.maxPlayersPerRoom = SettingsManager.CurrentSettings.MultiRoomSize;
                    }
                    if (PUNManager.Instance.isConnected && roomInfo.currentSessionInfo != null)
                    {
                        roomInfo.currentSessionInfo.SetMaxPlayers(SettingsManager.CurrentSettings.MultiRoomSize);
                        //MelonLogger.Msg($"Room Info Updated: Max Players:{roomInfo.currentSessionInfo._maxPlayers}");
                    }
                    
                    //if (PUNManager.Instance._clientNetworkingPlayerData._currentSession._maxPlayers != SettingsManager.CurrentSettings.MultiRoomSize)
                    //{
                    //    PUNManager.Instance._clientNetworkingPlayerData._currentSession.SetMaxPlayers(SettingsManager.CurrentSettings.MultiRoomSize);
                    //}
                    
                }
            }
            catch (Exception ex)
            {
                MelonLogger.Msg("Exception Updating Room Size: " + ex.Message + ex.Source + ex.Data);
            }

        }
        */
    }
}

using GuruBMXMod.Utils;
using Il2Cpp;
using Il2CppCom.MyCompany.MyGame;
using Il2CppPhoton.Pun;
using Il2CppPhoton.Realtime;
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

        public static bool networkComponentsLoaded { get; private set; } = false;

        private NetworkRoomInfo roomInfo;
        //private NetworkingSessionScriptableObject networkSession;

        public void GetNetworkComponenets()
        {
            MelonLogger.Msg("Getting Network Components...");
            try
            {
                roomInfo = PUNManager.Instance.transform.parent.gameObject.GetComponentInChildren<NetworkRoomInfo>();
                //networkSession = UnityEngine.Object.FindObjectOfType<NetworkingSessionScriptableObject>();

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
            //{"networkSession", networkSession}
            };

            if (ComponentCheck.CheckComponents(components, "Network"))
            {
                networkComponentsLoaded = true;
            }
        }
        public void UpdateRoomSize()
        {
            try
            {
                if (PUNManager.Instance != null)
                {
                    if (PUNManager.Instance.maxPlayersPerRoom != SettingsManager.CurrentSettings.MultiRoomSize)
                    {
                        byte newSize = (byte)SettingsManager.CurrentSettings.MultiRoomSize;
                        PUNManager.Instance.maxPlayersPerRoom = newSize;
                    }
                    if (roomInfo.currentSessionInfo._maxPlayers != SettingsManager.CurrentSettings.MultiRoomSize)
                    {
                        roomInfo.currentSessionInfo.SetMaxPlayers((byte)SettingsManager.CurrentSettings.MultiRoomSize);
                        //MelonLogger.Msg($"Room Info Updated: Max Players:{roomInfo.currentSessionInfo._maxPlayers}");
                    }
                    //if (networkSession._maxPlayers != SettingsManager.CurrentSettings.MultiRoomSize)
                    //{
                    //    networkSession.SetMaxPlayers(SettingsManager.CurrentSettings.MultiRoomSize);
                    //    MelonLogger.Msg($"Network Session Updated: Max Players:{networkSession._maxPlayers}");
                    //}

                }
            }
            catch (Exception ex)
            {
                MelonLogger.Msg("Exception Updating Room Size: " + ex.Message + ex.Source + ex.TargetSite);
            }

        }
    }
}

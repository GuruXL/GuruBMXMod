using GuruBMXMod.Multi;
using UnityEngine;

namespace GuruBMXMod.UI
{
    public static class UIActionManager
    {
        #region Buttons
        // Buttons
        public static void MainToggle()
        {
            Settings.ModEnabled = !Settings.ModEnabled;
        }
        public static void ToggleSimplePedal()
        {
            Settings.EnableSimplePedal = !Settings.EnableSimplePedal;
            BMXModController.Instance.ToggleSimplePedal();
        }
        public static void UnlockStars()
        {
            Settings.UnlockStars = !Settings.UnlockStars;
            RewardUnlocks.Instance.UnlockStars("All", Settings.UnlockStars);
        }
        public static void UnlockRewards()
        {
            Settings.UnlockRewards = !Settings.UnlockRewards;
            RewardUnlocks.Instance.UnlockRewards(Settings.UnlockRewards);
        }
        public static void SpawnVehicle()
        {
            BMXModController.Instance.SpawnVehicle();
        }
        public static void EnableCycle()
        {
            Settings.EnableCycle = !Settings.EnableCycle;
            TimeController.Instance.EnableCycle(Settings.EnableCycle);
        }
        #endregion

        #region Stat Sliders
        // Stat Slider
        public static void UpdateGravitySlider(float newValue)
        {
            Settings.Gravity = newValue;
            BMXModController.Instance.UpdateGravity();
        }
        public static void UpdatePedalForceSlider(float newValue)
        {
            Settings.PedalForce = newValue;
            BMXModController.Instance.UpdatePedalForces();
        }
        public static void UpdatePedalVelocitySlider(float newValue)
        {
            Settings.MaxPedalVel = newValue;
            BMXModController.Instance.UpdatePedalForces();
        }
        #endregion

        #region NetworkSliders
        // Network Sliders
        public static void UpdateLobbySlider(float newValue)
        {
            byte bytevalue = (byte)newValue;

            Settings.PlayerLobbySize = bytevalue;
            BMXModNetworkController.Instance.UpdateLobbySize();
        }
        #endregion
        #region TimeOfDay Sliders
        // Time Sliders
        
        #endregion

    }
}

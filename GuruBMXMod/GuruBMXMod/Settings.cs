using UnityEngine;

namespace GuruBMXMod
{
    public static class Settings
    {
        public static Color BGColor = new Color(0.85f, 0.90f, 1.0f);

        public static bool ModEnabled = false;

        public static bool UnlockStars = false;
        public static bool UnlockRewards = false;

        public static bool EnableCycle = false;

        public static float Gravity = -12.5f;

        public static float MaxMotorTorque = 1000f;
        public static float MaxPedalVel = 9f;
        public static float PedalForce = 100f;
        public static bool EnableSimplePedal = false;

        public static float GrindHoldForce = 0f;

        public static byte PlayerLobbySize = 4;

    }
}

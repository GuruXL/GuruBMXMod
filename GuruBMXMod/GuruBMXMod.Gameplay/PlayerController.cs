using GuruBMXMod.Utils;
using Il2Cpp;
using Il2CppDiasGames.ThirdPersonSystem;
using MelonLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuruBMXMod.Gameplay
{
    public class PlayerController
    {
        public static PlayerController __instance { get; private set; }
        public static PlayerController Instance => __instance ?? (__instance = new PlayerController());

        // Player
        private FreeRunningPlayerManager freeRunPlayerManager;
        private JumpAbility jumpAbility;
        private FallAbility fallAbility;
        private GetUpAbility getUpAbility;

        public void GetPlayerComponents()
        {
            MelonLogger.Msg("Getting Player Components...");
            try
            {
                freeRunPlayerManager = PlayerComponents.GetInstance().GetComponentInParent<FreeRunningPlayerManager>();
                jumpAbility = freeRunPlayerManager.gameObject.GetComponentInParent<JumpAbility>();
                fallAbility = freeRunPlayerManager.gameObject.GetComponentInParent<FallAbility>();
                getUpAbility = freeRunPlayerManager.gameObject.GetComponentInParent<GetUpAbility>();
            }
            catch (Exception ex)
            {
                MelonLogger.Msg("Player Components Exception: " + ex.Message);
            }
            finally
            {
                CheckPlayerComponents();
            }
        }
        private void CheckPlayerComponents()
        {
            // Creating a dictionary for dynamic checking
            Dictionary<string, object> components = new Dictionary<string, object>
            {
            {"freeRunPlayerManager", freeRunPlayerManager},
            {"jumpAbility", jumpAbility},
            {"fallAbility", fallAbility},
            {"getUpAbility", getUpAbility}
            };

            ComponentCheck.CheckComponents(components, "Player");
        }

        public void UpdatePlayerAnimationSpeed()
        {
            if (freeRunPlayerManager.freeRunningCharacterManager.animator.speed == SettingsManager.CurrentSettings.Player_AnimationSpeed)
                return;

            freeRunPlayerManager.freeRunningCharacterManager.animator.speed = SettingsManager.CurrentSettings.Player_AnimationSpeed;
        }

        public void UpdatePlayerJumpForce()
        {
            if (jumpAbility.jumpPower == SettingsManager.CurrentSettings.Player_MaxVelocityToRagDoll)
                return;

            jumpAbility.jumpPower = SettingsManager.CurrentSettings.Player_MaxVelocityToRagDoll;
        }
        public void UpdatePlayerMaxFallVelocity()
        {
            if (fallAbility.maxFallVelToRagdoll == SettingsManager.CurrentSettings.Player_MaxVelocityToRagDoll)
                return;

            fallAbility.maxFallVelToRagdoll = SettingsManager.CurrentSettings.Player_MaxVelocityToRagDoll;
        }
    }
}

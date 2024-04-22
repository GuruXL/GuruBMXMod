using GuruBMXMod.Gameplay;
using GuruBMXMod.Multi;
using GuruBMXMod.Utils;
using MelonLoader;
using UnityEngine;

namespace GuruBMXMod.UI
{
    public class UItab // UI dropdown tabs class
    {
        public bool isClosed;
        public string text;
        public int font;

        public UItab(bool isClosed, string text, int font)
        {
            this.isClosed = isClosed;
            this.text = text;
            this.font = font;
        }
    }

    public class UIcontroller
    {
        public bool showUI;
        public bool setUp;
        public Rect MainWindowRect = new Rect(20, 20, Screen.width / 6, 20);
        //public static GUI.WindowFunction windowFunction;

        //readonly UItab Test_Tab = new UItab(true, "Test Stuff", 14);

        readonly UItab Unlocks_Tab = new UItab(true, "Unlocks", 16);
        readonly UItab Stats_Tab = new UItab(true, "Gameplay", 16);
        readonly UItab Multi_Tab = new UItab(true, "Multiplayer", 16);
        readonly UItab Camera_Tab = new UItab(true, "Camera", 16);
        readonly UItab Cycle_Tab = new UItab(true, "Time Of Day", 16);

        readonly UItab Player_Tab = new UItab(true, "Player", 14);
        readonly UItab BMX_Tab = new UItab(true, "BMX", 14);
        readonly UItab DriftBike_Tab = new UItab(true, "Drift Bike", 14);

        readonly UItab Peddle_Tab = new UItab(true, "Peddle", 13);
        readonly UItab Pumping_Tab = new UItab(true, "Pumping", 13);
        readonly UItab Manny_Tab = new UItab(true, "Manny", 13);
        readonly UItab Grind_Tab = new UItab(true, "Grinds", 13);

        private readonly string white = "#e6ebe8";
        private readonly string grey = "#969696";
        private readonly string cyan = "#00ffff";
        private readonly string green = "#7CFC00";
        private readonly string red = "#b71540";

        // ----- Start Set KeyBindings ------

        //public KeyBinding Hotkey = new KeyBinding { keyCode = KeyCode.W };
        public KeyCode Hotkey = KeyCode.G;

        private readonly KeyCode[] keyCodes = Enum.GetValues(typeof(KeyCode)).Cast<KeyCode>().Where(k => (int)k < (int)KeyCode.Mouse0).ToArray();

        public bool ctrlToggle = true;
        public bool altToggle = true;
        public bool noneToggle = false;

        // Get Key on KeyPress
        public KeyCode? GetCurrentKeyDown()
        {
            if (!Input.anyKeyDown)
            {
                return null;
            }

            for (int i = 0; i < keyCodes.Length; i++)
            {
                KeyCode keyCode = keyCodes[i];

                if (keyCode == KeyCode.LeftControl ||
                    keyCode == KeyCode.RightControl ||
                    keyCode == KeyCode.LeftAlt ||
                    keyCode == KeyCode.RightAlt ||
                    keyCode == KeyCode.AltGr ||
                    keyCode == KeyCode.LeftCommand ||
                    keyCode == KeyCode.RightCommand)
                {
                    continue;
                }

                if (Input.GetKey(keyCode))
                {
                    return keyCode;
                }
            }

            return null;
        }
        /*
        public KeyCode GetAltKey()
        {
            if (ctrlToggle)
            {
                return KeyCode.LeftControl;
            }
            else if (altToggle)
            {
                return KeyCode.LeftAlt;
            }
            return KeyCode.None;
        }
        */
        public bool IsModifierKeyPressed()
        {
            if (ctrlToggle)
            {
                // Checks if either left or right Ctrl is pressed
                if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
                {
                    return true;
                }
            }
            else if (altToggle)
            {
                // Checks if either left or right Alt is pressed
                if (Input.GetKey(KeyCode.LeftAlt) || Input.GetKey(KeyCode.RightAlt))
                {
                    return true;
                }
            }
            return false;
        }
        public void WaitForInput()
        {
            if (IsModifierKeyPressed() && Input.GetKeyDown(Hotkey))
            {
                ToggleUI();
            }
        }
        private void ToggleUI()
        {
            if (!showUI)
            {
                Open();
            }
            else
            {
                Close();
            }
        }
        private void Open()
        {
            showUI = true;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

        private void Close()
        {
            showUI = false;
            Cursor.visible = false;
        }

        public void CustomOnGUI()
        {
            if (!setUp)
            {
                setUp = true;
            }
            if (!showUI)
                return;
            GUI.backgroundColor = SettingsManager.CurrentSettings.BGColor;
            MainWindowRect = GUILayout.Window(387456, MainWindowRect, (GUI.WindowFunction)MainWindow, "<b> Guru BMX Mod </b>");
        }

        // Creates the GUI window
        public void MainWindow(int windowID)
        {
            GUI.backgroundColor = SettingsManager.CurrentSettings.BGColor;
            GUI.DragWindow(new Rect(0, 0, 10000, 20));

            MainUI();
            if (!SettingsManager.CurrentSettings.ModEnabled)
                return;

            UnlocksUI();
            //CameraUI();
            StatsUI();
            MultiUI();
            CycleUI();
        }

       
        private void MainUI()
        {
            GUILayout.BeginHorizontal();
            UIextensions.FlexableButton(SettingsManager.CurrentSettings.ModEnabled ? "<b> Enabled </b>" : "<b><color=#171717> Disabled </color></b>", UIActionManager.MainToggle, UIextensions.ButtonColorSwitch(SettingsManager.CurrentSettings.ModEnabled));
            GUILayout.EndHorizontal();
        }

        private void Tabs(UItab obj, string color = "#e6ebe8")
        {
            if (GUILayout.Button($"<size={obj.font}><color={color}>" + (obj.isClosed ? "○" : "●") + obj.text + "</color>" + "</size>", "Label"))
            {
                obj.isClosed = !obj.isClosed;
                MainWindowRect.height = 20;
                MainWindowRect.width = Screen.width / 5;
                UIextensions.TabFontSwitch(obj);
            }
        }
        private void UnlocksUI()
        {
            Tabs(Unlocks_Tab, UIextensions.TabColorSwitch(Unlocks_Tab));
            if (Unlocks_Tab.isClosed)
                return;

            GUILayout.BeginVertical("Box");

            GUILayout.BeginHorizontal();
            GUILayout.Label($"Unlock All Stars", GUILayout.ExpandWidth(true));
            GUILayout.FlexibleSpace();
            UIextensions.StandardButton(SettingsManager.CurrentSettings.UnlockStars ? "<b> On </b>" : "<b><color=#171717> Off </color></b>", UIActionManager.UnlockStars, UIextensions.ButtonColorSwitch(SettingsManager.CurrentSettings.UnlockStars), 72);
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            GUILayout.Label($"Unlock All Rewards", GUILayout.ExpandWidth(true));
            GUILayout.FlexibleSpace();
            UIextensions.StandardButton(SettingsManager.CurrentSettings.UnlockRewards ? "<b> On </b>" : "<b><color=#171717> Off </color></b>", UIActionManager.UnlockRewards, UIextensions.ButtonColorSwitch(SettingsManager.CurrentSettings.UnlockRewards), 72);
            GUILayout.EndHorizontal();

            GUILayout.EndVertical();

        }
        private void CameraUI()
        {
            Tabs(Camera_Tab, UIextensions.TabColorSwitch(Camera_Tab));
            if (Camera_Tab.isClosed)
                return;

        }
        private void StatsUI()
        {
            Tabs(Stats_Tab, UIextensions.TabColorSwitch(Stats_Tab));
            if (Stats_Tab.isClosed)
                return;

            GUILayout.BeginVertical("Box");
            UIextensions.Slider("Gravity", UIActionManager.UpdateGravitySlider, Color.white, SettingsManager.CurrentSettings.Gravity, -50.0f, 50.0f, SettingsManager.DefaultSettings.Gravity);
            GUILayout.EndVertical();

            GUILayout.BeginVertical("Box");
            Tabs(Player_Tab, UIextensions.TabColorSwitch(Player_Tab));
            if (!Player_Tab.isClosed)
            {
                /*
                GUILayout.BeginHorizontal();
                GUILayout.Label($"Swap Session Marker Input", GUILayout.ExpandWidth(true));
                GUILayout.FlexibleSpace();
                UIextensions.StandardButton(SettingsManager.CurrentSettings.SessionMarkerSwapped ? "<b> On </b>" : "<b><color=#171717> Off </color></b>", UIActionManager.SwapSessionMarker, UIextensions.ButtonColorSwitch(SettingsManager.CurrentSettings.SessionMarkerSwapped), 72);
                GUILayout.EndHorizontal();
                */

            }
            Tabs(BMX_Tab, UIextensions.TabColorSwitch(BMX_Tab));
            if (!BMX_Tab.isClosed)
            {
                GUILayout.BeginVertical("Box"); // start BMX tabs

                Tabs(Peddle_Tab, UIextensions.TabColorSwitch(Peddle_Tab));
                if (!Peddle_Tab.isClosed)
                {
                    GUILayout.BeginHorizontal();
                    GUILayout.Label($"Enable Simple Pedal", GUILayout.ExpandWidth(true));
                    GUILayout.FlexibleSpace();
                    UIextensions.StandardButton(SettingsManager.CurrentSettings.EnableSimplePedal ? "<b> On </b>" : "<b><color=#171717> Off </color></b>", UIActionManager.ToggleSimplePedal, UIextensions.ButtonColorSwitch(SettingsManager.CurrentSettings.EnableSimplePedal), 72);
                    GUILayout.EndHorizontal();
                    if (SettingsManager.CurrentSettings.EnableSimplePedal)
                    {
                        GUILayout.BeginVertical("Box");
                        UIextensions.Slider("Pedal Force", UIActionManager.UpdatePedalForceSlider, Color.white, SettingsManager.CurrentSettings.SimpleBMX_PedalForce, 0f, 10000f, SettingsManager.DefaultSettings.SimpleBMX_PedalForce);
                        GUILayout.EndVertical();

                        GUILayout.BeginVertical("Box");
                        UIextensions.Slider("Max Pedal Velocity", UIActionManager.UpdatePedalVelocitySlider, Color.white, SettingsManager.CurrentSettings.SimpleBMX_MaxPedalVel, 0f, 800f, SettingsManager.DefaultSettings.SimpleBMX_MaxPedalVel);
                        GUILayout.EndVertical();
                    }
                }
                Tabs(Pumping_Tab, UIextensions.TabColorSwitch(Pumping_Tab));
                if (!Pumping_Tab.isClosed)
                {
                    GUILayout.BeginVertical("Box");
                    UIextensions.Slider("Steering Pump Force MIN", UIActionManager.UpdateSteeringPumpMin, Color.white, SettingsManager.CurrentSettings.SimpleBMX_MinPumpForceMulti, 0f, 20f, SettingsManager.DefaultSettings.SimpleBMX_MinPumpForceMulti);
                    GUILayout.EndVertical();

                    GUILayout.BeginVertical("Box");
                    UIextensions.Slider("Steering Pump Force MAX", UIActionManager.UpdateSteeringPumpMax, Color.white, SettingsManager.CurrentSettings.SimpleBMX_MaxPumpForceMulti, 0f, 20f, SettingsManager.DefaultSettings.SimpleBMX_MaxPumpForceMulti);
                    GUILayout.EndVertical();

                    GUILayout.BeginVertical("Box");
                    UIextensions.Slider("Time from Min to Max", UIActionManager.UpdateSteeringPumpTime, Color.white, SettingsManager.CurrentSettings.SimpleBMX_PumpMinMaxCurveTime, 0f, 100f, SettingsManager.DefaultSettings.SimpleBMX_PumpMinMaxCurveTime);
                    GUILayout.EndVertical();
                }
                Tabs(Manny_Tab, UIextensions.TabColorSwitch(Manny_Tab));
                if (!Manny_Tab.isClosed)
                {
                    GUILayout.BeginHorizontal();
                    GUILayout.Label($"Auto Sideways Stability", GUILayout.ExpandWidth(true));
                    GUILayout.FlexibleSpace();
                    UIextensions.StandardButton(SettingsManager.CurrentSettings.MannyAutoStability ? "<b> On </b>" : "<b><color=#171717> Off </color></b>", UIActionManager.ToggleMannyStability, UIextensions.ButtonColorSwitch(SettingsManager.CurrentSettings.MannyAutoStability), 72);
                    GUILayout.EndHorizontal();

                    GUILayout.BeginVertical("Box");
                    UIextensions.Slider("Manny Max Bail Angle", UIActionManager.UpdateMannyMaxAngle, Color.white, SettingsManager.CurrentSettings.BMX_MannyMaxBailAngle, 0f, 90f, SettingsManager.DefaultSettings.BMX_MannyMaxBailAngle);
                    GUILayout.EndVertical();

                    GUILayout.BeginVertical("Box");
                    UIextensions.Slider("Nosey Max Bail Angle", UIActionManager.UpdateNoseyMaxAngle, Color.white, SettingsManager.CurrentSettings.BMX_NoseyMaxBailAngle, 0f, 90f, SettingsManager.DefaultSettings.BMX_NoseyMaxBailAngle);
                    GUILayout.EndVertical();

                }
                Tabs(Grind_Tab, UIextensions.TabColorSwitch(Grind_Tab));
                if (!Grind_Tab.isClosed)
                {
                    GUILayout.BeginVertical("Box");
                    UIextensions.Slider("Grind Hold Force", UIActionManager.UpdateGrindHoldForce, Color.white, SettingsManager.CurrentSettings.SimpleBMX_GrindHoldForce, -20000f, 20000f, SettingsManager.DefaultSettings.SimpleBMX_GrindHoldForce);
                    GUILayout.EndVertical();
                }

                GUILayout.EndVertical(); // end Bmx Tabs
            } 
            Tabs(DriftBike_Tab, UIextensions.TabColorSwitch(DriftBike_Tab));
            if (!DriftBike_Tab.isClosed)
            {
                GUILayout.BeginHorizontal();
                UIextensions.StandardButton("<b> Spawn Drift Bike </b>", UIActionManager.SpawnVehicle, Color.cyan, 128);
                GUILayout.EndHorizontal();

                GUILayout.BeginVertical("Box");
                UIextensions.Slider("Jump Force", UIActionManager.UpdateDriftJumpForce, Color.white, SettingsManager.CurrentSettings.DriftBike_JumpForce, 0f, 4000f, SettingsManager.DefaultSettings.DriftBike_JumpForce);
                GUILayout.EndVertical();

                GUILayout.BeginVertical("Box");
                UIextensions.Slider("Max Motor Torque", UIActionManager.UpdateDriftMaxMotorTorque, Color.white, SettingsManager.CurrentSettings.DriftBike_MaxMotorTorque, 0f, 5000f, SettingsManager.DefaultSettings.DriftBike_MaxMotorTorque);
                GUILayout.EndVertical();

                GUILayout.BeginVertical("Box");
                UIextensions.Slider("Max Brake Torque", UIActionManager.UpdateDriftMaxBrakeTorque, Color.white, SettingsManager.CurrentSettings.DriftBike_MaxBrakeTorque, 0f, 8000f, SettingsManager.DefaultSettings.DriftBike_MaxBrakeTorque);
                GUILayout.EndVertical();

                GUILayout.BeginVertical("Box");
                UIextensions.Slider("Air Flip Torque", UIActionManager.UpdateDriftAirFlipTorque, Color.white, SettingsManager.CurrentSettings.DriftBike_AirFlipTorque, 0f, 2500f, SettingsManager.DefaultSettings.DriftBike_AirFlipTorque);
                GUILayout.EndVertical();

                GUILayout.BeginVertical("Box");
                UIextensions.Slider("Air Spin Torque", UIActionManager.UpdateDriftAirSpinTorque, Color.white, SettingsManager.CurrentSettings.DriftBike_AirSpinTorque, -1000f, 1000f, SettingsManager.DefaultSettings.DriftBike_AirSpinTorque);
                GUILayout.EndVertical();

                GUILayout.BeginVertical("Box");
                UIextensions.Slider("Air Up Right Torque", UIActionManager.UpdateDriftAirUpRightTorque, Color.white, SettingsManager.CurrentSettings.DriftBike_AirUpRightTorque, 0f, 20f, SettingsManager.DefaultSettings.DriftBike_AirUpRightTorque);
                GUILayout.EndVertical();

                GUILayout.BeginVertical("Box");
                UIextensions.Slider("Anti Roll", UIActionManager.UpdateDriftAntiRoll, Color.white, SettingsManager.CurrentSettings.DriftBike_AntiRoll, 0f, 1000f, SettingsManager.DefaultSettings.DriftBike_AntiRoll);
                GUILayout.EndVertical();

                GUILayout.BeginVertical("Box");
                UIextensions.Slider("Center Of Mass Offset", UIActionManager.UpdateDriftCOMoffset, Color.white, SettingsManager.CurrentSettings.DriftBike_COMOffset, -0.2f, 0.2f, SettingsManager.DefaultSettings.DriftBike_COMOffset);
                GUILayout.EndVertical();

                GUILayout.BeginVertical("Box");
                UIextensions.Slider("Turn Torque", UIActionManager.UpdateDriftTurnTorque, Color.white, SettingsManager.CurrentSettings.DriftBike_TurnTorque, 0f, 8000f, SettingsManager.DefaultSettings.DriftBike_TurnTorque);
                GUILayout.EndVertical();

                GUILayout.BeginVertical("Box");
                UIextensions.Slider("Turn Responsiveness", UIActionManager.UpdateDriftTurnResponse, Color.white, SettingsManager.CurrentSettings.DriftBike_TurnResponse, 0f, 20f, SettingsManager.DefaultSettings.DriftBike_TurnResponse);
                GUILayout.EndVertical();
            }
            GUILayout.EndVertical();
        }

        private void MultiUI()
        {
            Tabs(Multi_Tab, UIextensions.TabColorSwitch(Multi_Tab));
            if (Multi_Tab.isClosed)
                return;

            GUILayout.BeginVertical("Box");
            UIextensions.Slider("Lobby Size", UIActionManager.UpdateLobbySlider, Color.white, SettingsManager.CurrentSettings.MultiRoomSize, 2, 16, SettingsManager.DefaultSettings.MultiRoomSize);
            GUILayout.EndVertical();


        }
        private void CycleUI()
        {
            Tabs(Cycle_Tab, UIextensions.TabColorSwitch(Cycle_Tab));
            if (Cycle_Tab.isClosed)
                return;

            GUILayout.BeginVertical(); // start

            GUILayout.BeginVertical();
            GUILayout.Label($"Enable Day/Night Cycle", GUILayout.ExpandWidth(true));
            UIextensions.StandardButton(SettingsManager.CurrentSettings.EnableCycle ? "<b> On </b>" : "<b><color=#171717> Off </color></b>", UIActionManager.EnableCycle, UIextensions.ButtonColorSwitch(SettingsManager.CurrentSettings.EnableCycle), 72);
            GUILayout.EndVertical();
            /*
            GUILayout.BeginVertical();
            GUILayout.Label($"Enable For Mod Maps", GUILayout.ExpandWidth(true));
            UIextensions.StandardButton(SettingsManager.CurrentSettings.ToggleModMapLights ? "<b> On </b>" : "<b><color=#171717> Off </color></b>", UIActionManager.ToggleModMapLights, UIextensions.ButtonColorSwitch(SettingsManager.CurrentSettings.ToggleModMapLights), 72);
            GUILayout.EndVertical();
            */
            if (SettingsManager.CurrentSettings.EnableCycle)
            {
                try
                {
                    float time = TimeController.Instance.todManager.GetTimeOfDay();
                    string formattedTime = TimeFormatter.ConvertTimeTo12HourFormat(time);
                    GUILayout.Label($"Time Of Day: {formattedTime}", GUILayout.ExpandWidth(true));
                }
                catch (Exception e)
                {
                    GUILayout.Label("Failed to retrieve time: " + e.Message);
                }
                //GUILayout.Label($"Time Of Day: {formattedTime}", GUILayout.ExpandWidth(true));
                GUILayout.BeginVertical("Box");
                UIextensions.Slider("Time Of Day", UIActionManager.UpdateTimeOfDay, Color.white, SettingsManager.CurrentSettings.TimeOfDay, 0.0f, 24.0f, SettingsManager.DefaultSettings.TimeOfDay);
                GUILayout.EndVertical();

                GUILayout.BeginVertical("Box");
                UIextensions.Slider("Time Of Day Speed", UIActionManager.UpdateCycleSpeed, Color.white, SettingsManager.CurrentSettings.CycleSpeed, 0.01f, 1.00f, SettingsManager.DefaultSettings.CycleSpeed);
                GUILayout.EndVertical();

                GUILayout.BeginVertical("Box");
                UIextensions.Slider("Shadow Update Time", UIActionManager.UpdateShadowTime, Color.white, SettingsManager.CurrentSettings.ShadowUpdateTime, 0.01f, 0.10f, SettingsManager.DefaultSettings.ShadowUpdateTime);
                GUILayout.EndVertical();

                GUILayout.BeginVertical("Box");
                UIextensions.Slider("Time BetweenSky Updates", UIActionManager.TimeBetweenSkyUpdates, Color.white, SettingsManager.CurrentSettings.TimeBetweenSkyUpdates, 0.1f, 2.0f, SettingsManager.DefaultSettings.TimeBetweenSkyUpdates);
                GUILayout.EndVertical();
            }

            GUILayout.EndVertical(); // end
        }
    }
}




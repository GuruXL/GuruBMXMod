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
        public float font;

        public UItab(bool isClosed, string text, float font)
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

        readonly UItab Stats_Tab = new UItab(true, "Stats", 14.0f);
        readonly UItab Multi_Tab = new UItab(true, "Multiplayer", 14.0f);
        readonly UItab Unlocks_Tab = new UItab(true, "Unlocks", 14.0f);
        readonly UItab Camera_Tab = new UItab(true, "Camera", 14.0f);
        readonly UItab Cycle_Tab = new UItab(true, "Time Of Day", 14.0f);

        readonly UItab Player_Tab = new UItab(true, "Player", 13.0f);
        readonly UItab BMX_Tab = new UItab(true, "BMX", 13.0f);
        readonly UItab DriftBike_Tab = new UItab(true, "Drift Bike", 13.0f);

        readonly UItab Peddle_Tab = new UItab(true, "Peddle", 12.50f);
        readonly UItab Pumping_Tab = new UItab(true, "Pumping", 12.50f);
        readonly UItab Manny_Tab = new UItab(true, "Manny", 12.50f);
        readonly UItab Grind_Tab = new UItab(true, "Grinds", 12.50f);

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
            GUI.backgroundColor = Settings.BGColor;
            MainWindowRect = GUILayout.Window(387456, MainWindowRect, (GUI.WindowFunction)MainWindow, "<b> Guru BMX Mod </b>");
        }

        // Creates the GUI window
        public void MainWindow(int windowID)
        {
            GUI.backgroundColor = Settings.BGColor;
            GUI.DragWindow(new Rect(0, 0, 10000, 20));

            MainUI();
            if (!Settings.ModEnabled)
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
            UIextensions.FlexableButton(Settings.ModEnabled ? "<b> Enabled </b>" : "<b><color=#171717> Disabled </color></b>", UIActionManager.MainToggle, UIextensions.ButtonColorSwitch(Settings.ModEnabled));
            GUILayout.EndHorizontal();
        }

        private void Tabs(UItab obj, string color = "#e6ebe8")
        {
            if (GUILayout.Button($"<size={obj.font}><color={color}>" + (obj.isClosed ? "-" : "<b>+</b>") + obj.text + "</color>" + "</size>", "Label"))
            {
                obj.isClosed = !obj.isClosed;
                MainWindowRect.height = 20;
                MainWindowRect.width = Screen.width / 6;
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
            UIextensions.StandardButton(Settings.UnlockStars ? "<b> On </b>" : "<b><color=#171717> Off </color></b>", UIActionManager.UnlockStars, UIextensions.ButtonColorSwitch(Settings.UnlockStars), 72);
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            GUILayout.Label($"Unlock All Rewards", GUILayout.ExpandWidth(true));
            GUILayout.FlexibleSpace();
            UIextensions.StandardButton(Settings.UnlockRewards ? "<b> On </b>" : "<b><color=#171717> Off </color></b>", UIActionManager.UnlockRewards, UIextensions.ButtonColorSwitch(Settings.UnlockRewards), 72);
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
            UIextensions.Slider("Gravity", UIActionManager.UpdateGravitySlider, Color.white, Settings.Gravity, -50.0f, 50.0f);
            GUILayout.EndVertical();

            GUILayout.BeginVertical("Box");
            Tabs(Player_Tab, UIextensions.TabColorSwitch(Player_Tab));
            if (!Player_Tab.isClosed)
            {
                /*
                GUILayout.BeginHorizontal();
                GUILayout.Label($"Swap Session Marker Input", GUILayout.ExpandWidth(true));
                GUILayout.FlexibleSpace();
                UIextensions.StandardButton(Settings.SessionMarkerSwapped ? "<b> On </b>" : "<b><color=#171717> Off </color></b>", UIActionManager.SwapSessionMarker, UIextensions.ButtonColorSwitch(Settings.SessionMarkerSwapped), 72);
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
                    GUILayout.BeginVertical();
                    GUILayout.Label($"Enable Simple Pedal", GUILayout.ExpandWidth(true));
                    UIextensions.StandardButton(Settings.EnableSimplePedal ? "<b> On </b>" : "<b><color=#171717> Off </color></b>", UIActionManager.ToggleSimplePedal, UIextensions.ButtonColorSwitch(Settings.EnableSimplePedal), 72);
                    if (Settings.EnableSimplePedal)
                    {
                        GUILayout.BeginVertical("Box");
                        UIextensions.Slider("Pedal Force", UIActionManager.UpdatePedalForceSlider, Color.white, Settings.SimpleBMX_PedalForce, 0f, 10000f);
                        GUILayout.EndVertical();

                        GUILayout.BeginVertical("Box");
                        UIextensions.Slider("Max Pedal Velocity", UIActionManager.UpdatePedalVelocitySlider, Color.white, Settings.SimpleBMX_MaxPedalVel, 0f, 800f);
                        GUILayout.EndVertical();
                    }
                    GUILayout.EndVertical();
                }
                Tabs(Pumping_Tab, UIextensions.TabColorSwitch(Pumping_Tab));
                if (!Pumping_Tab.isClosed)
                {
                    GUILayout.BeginVertical("Box");
                    UIextensions.Slider("Steering Pump Force MIN", UIActionManager.UpdateSteeringPumpMin, Color.white, Settings.SimpleBMX_MinPumpForceMulti, 0f, 20f);
                    GUILayout.EndVertical();

                    GUILayout.BeginVertical("Box");
                    UIextensions.Slider("Steering Pump Force MAX", UIActionManager.UpdateSteeringPumpMax, Color.white, Settings.SimpleBMX_MaxPumpForceMulti, 0f, 20f);
                    GUILayout.EndVertical();

                    GUILayout.BeginVertical("Box");
                    UIextensions.Slider("Time from Min to Max", UIActionManager.UpdateSteeringPumpTime, Color.white, Settings.SimpleBMX_PumpMinMaxCurveTime, 0f, 100f);
                    GUILayout.EndVertical();
                }
                Tabs(Manny_Tab, UIextensions.TabColorSwitch(Manny_Tab));
                if (!Manny_Tab.isClosed)
                {

                }
                Tabs(Grind_Tab, UIextensions.TabColorSwitch(Grind_Tab));
                if (!Grind_Tab.isClosed)
                {
                    GUILayout.BeginVertical("Box");
                    UIextensions.Slider("Grind Hold Force", UIActionManager.UpdateGrindHoldForce, Color.white, Settings.SimpleBMX_GrindHoldForce, -20000f, 20000f);
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
                UIextensions.Slider("Jump Force", UIActionManager.UpdateDriftJumpForce, Color.white, Settings.DriftBike_JumpForce, 0f, 4000f);
                GUILayout.EndVertical();

                GUILayout.BeginVertical("Box");
                UIextensions.Slider("Max Motor Torque", UIActionManager.UpdateDriftMaxMotorTorque, Color.white, Settings.DriftBike_MaxMotorTorque, 0f, 5000f);
                GUILayout.EndVertical();

                GUILayout.BeginVertical("Box");
                UIextensions.Slider("Max Brake Torque", UIActionManager.UpdateDriftMaxBrakeTorque, Color.white, Settings.DriftBike_MaxBrakeTorque, 0f, 8000f);
                GUILayout.EndVertical();

                GUILayout.BeginVertical("Box");
                UIextensions.Slider("Air Flip Torque", UIActionManager.UpdateDriftAirFlipTorque, Color.white, Settings.DriftBike_AirFlipTorque, 0f, 2500f);
                GUILayout.EndVertical();

                GUILayout.BeginVertical("Box");
                UIextensions.Slider("Air Spin Torque", UIActionManager.UpdateDriftAirSpinTorque, Color.white, Settings.DriftBike_AirSpinTorque, -1000f, 1000f);
                GUILayout.EndVertical();

                GUILayout.BeginVertical("Box");
                UIextensions.Slider("Air Up Right Torque", UIActionManager.UpdateDriftAirUpRightTorque, Color.white, Settings.DriftBike_AirUpRightTorque, 0f, 20f);
                GUILayout.EndVertical();

                GUILayout.BeginVertical("Box");
                UIextensions.Slider("Anti Roll", UIActionManager.UpdateDriftAntiRoll, Color.white, Settings.DriftBike_AntiRoll, 0f, 1000f);
                GUILayout.EndVertical();

                GUILayout.BeginVertical("Box");
                UIextensions.Slider("Center Of Mass Offset", UIActionManager.UpdateDriftCOMoffset, Color.white, Settings.DriftBike_COMOffset, -0.2f, 0.2f);
                GUILayout.EndVertical();

                GUILayout.BeginVertical("Box");
                UIextensions.Slider("Turn Torque", UIActionManager.UpdateDriftTurnTorque, Color.white, Settings.DriftBike_TurnTorque, 0f, 8000f);
                GUILayout.EndVertical();

                GUILayout.BeginVertical("Box");
                UIextensions.Slider("Turn Responsiveness", UIActionManager.UpdateDriftTurnResponse, Color.white, Settings.DriftBike_TurnResponse, 0f, 20f);
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
            UIextensions.Slider("Lobby Size", UIActionManager.UpdateLobbySlider, Color.white, Settings.MultiRoomSize, 2, 16);
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
            UIextensions.StandardButton(Settings.EnableCycle ? "<b> On </b>" : "<b><color=#171717> Off </color></b>", UIActionManager.EnableCycle, UIextensions.ButtonColorSwitch(Settings.EnableCycle), 72);
            GUILayout.EndVertical();
            /*
            GUILayout.BeginVertical();
            GUILayout.Label($"Enable For Mod Maps", GUILayout.ExpandWidth(true));
            UIextensions.StandardButton(Settings.ToggleModMapLights ? "<b> On </b>" : "<b><color=#171717> Off </color></b>", UIActionManager.ToggleModMapLights, UIextensions.ButtonColorSwitch(Settings.ToggleModMapLights), 72);
            GUILayout.EndVertical();
            */
            if (Settings.EnableCycle)
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
                UIextensions.Slider("Time Of Day", UIActionManager.UpdateTimeOfDay, Color.white, Settings.TimeOfDay, 0.0f, 24.0f);
                GUILayout.EndVertical();

                GUILayout.BeginVertical("Box");
                UIextensions.Slider("Time Of Day Speed", UIActionManager.UpdateCycleSpeed, Color.white, Settings.CycleSpeed, 0.01f, 1.00f);
                GUILayout.EndVertical();

                GUILayout.BeginVertical("Box");
                UIextensions.Slider("Shadow Update Time", UIActionManager.UpdateShadowTime, Color.white, Settings.ShadowUpdateTime, 0.01f, 0.10f);
                GUILayout.EndVertical();

                GUILayout.BeginVertical("Box");
                UIextensions.Slider("Time BetweenSky Updates", UIActionManager.TimeBetweenSkyUpdates, Color.white, Settings.TimeBetweenSkyUpdates, 0.1f, 2.0f);
                GUILayout.EndVertical();
            }

            GUILayout.EndVertical(); // end
        }
    }
}




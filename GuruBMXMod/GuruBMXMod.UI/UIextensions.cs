﻿using UnityEngine;

namespace GuruBMXMod.UI
{
    public static class UIextensions
    {
        private static readonly string white = "#e6ebe8";
        private static readonly string LightBlue = "#30e2e6";
        private static string TabColor;

        public static string TabColorSwitch(UItab Tab)
        {
            switch (Tab.isClosed)
            {
                case true:
                    TabColor = white;
                    break;

                case false:
                    TabColor = LightBlue;
                    break;
            }
            return TabColor;
        }
        public static void TabFontSwitch(UItab Tab)
        {
            switch (!Tab.isClosed)
            {
                case true:
                    Tab.font = Tab.font + 2;
                    break;

                case false:
                    Tab.font = Tab.font - 2;
                    break;
            }
        }
        public static Color ButtonColorSwitch(bool toggle)
        {
            if (toggle)
            {
                return Color.cyan;
            }
            else
            {
                return Color.white;
            }
        }
        public static string ButtonLabelState(bool enabled, string ON, string OFF)
        {
            if (enabled)
                return $"<b> {ON} </b>";
            else
                return $"<b><color=#171717> {OFF} </color></b>";
        }
        public static void CenteredLabel(string label)
        {
            GUILayout.BeginHorizontal();
            GUILayout.FlexibleSpace();
            GUILayout.Label($"<i><b>{label}</b></i>", GUILayout.ExpandWidth(true));
            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();
        }
        public static void WarningLabel(string label)
        {
            GUILayout.BeginHorizontal();
            GUILayout.Label($"<i><color=#ffef0f>{label}</color></i>", GUILayout.ExpandWidth(true));
            GUILayout.EndHorizontal();
        }
        public static void FlexableToggleButton(string label, bool currentState, Action<bool> buttonAction, Color color)
        {
            GUILayout.BeginHorizontal();
            GUI.backgroundColor = color;
            if (GUILayout.Button($"{label}", GUILayout.ExpandWidth(true)))
            {
                // Toggling the current state and passing it to the action
                bool newState = !currentState;
                buttonAction?.Invoke(newState);
            }
            GUILayout.EndHorizontal();
        }
        public static void FlexableButton(string label, Action buttonAction, Color color)
        {
            GUILayout.BeginHorizontal();
            GUI.backgroundColor = color;
            if (GUILayout.Button($"{label}", GUILayout.ExpandWidth(true)))
            {
                buttonAction?.Invoke();
            }
            GUILayout.EndHorizontal();
        }
        public static void ToggleButton(string label, bool currentState, Action<bool> buttonAction, Color color, int width)
        {
            GUILayout.BeginHorizontal();
            GUI.backgroundColor = color;
            if (GUILayout.Button(label, GUILayout.MaxWidth(width)))
            {
                // Toggling the current state and passing it to the action
                bool newState = !currentState;
                buttonAction?.Invoke(newState);
            }
            GUILayout.EndHorizontal();
        }
        
        public static void StandardButton(string label, Action buttonAction, Color color, int width)
        {
            GUILayout.BeginHorizontal();
            GUI.backgroundColor = color;
            if (GUILayout.Button($"{label}", GUILayout.MaxWidth(width)))
            {
                buttonAction?.Invoke();
            }
            GUILayout.EndHorizontal();
        }
        
        public static void Slider(string label, Action<float> valueChangedCallback, Color color, ref float value, float minValue, float maxValue, float defaultValue)
        {
            GUILayout.BeginVertical(); // Start the main vertical layout

            GUI.backgroundColor = color;

            GUILayout.BeginHorizontal();
            GUILayout.Label(label, GUILayout.ExpandWidth(false));
            GUILayout.FlexibleSpace();

            // Use a TextField for the value input
            string valueInput = GUILayout.TextField(value.ToString("F2"), GUILayout.Width(50));

            // Draw the Reset button to the right of the input field
            if (GUILayout.Button("Reset", GUILayout.Width(50)))
            {
                valueInput = defaultValue.ToString("F2"); // Update the valueInput with the default value
                value = defaultValue; // Reset value to default
                valueChangedCallback?.Invoke(defaultValue); // Invoke the callback with the default value
            }
            GUILayout.EndHorizontal();

            // Slider underneath the labels
            float newValue = GUILayout.HorizontalSlider(value, minValue, maxValue, GUILayout.ExpandWidth(true));

            // Check if the text field input is a valid float and different from the current slider value
            if (float.TryParse(valueInput, out float inputValue) && inputValue != value)
            {
                newValue = inputValue; // Update the slider position based on input field value
            }

            // If the slider was moved or reset button was pressed, update the value
            if (newValue != value)
            {
                value = newValue; // Update the value if the slider moved
                valueChangedCallback?.Invoke(newValue); // Invoke the callback with new value
            }
            GUILayout.EndVertical(); // End the main vertical layout
        }
    }
}

using UnityEngine;

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
        public static string TabFontSwitch(UItab Tab)
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
            return TabColor;
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
        public static void CenteredLabel(string label)
        {
            GUILayout.BeginHorizontal();
            GUILayout.FlexibleSpace();
            GUILayout.Label($"<i><b>{label}</b></i>", GUILayout.ExpandWidth(true));
            GUILayout.FlexibleSpace();
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

        /* old working wlisder
        public void Slider(string label, Action<float> valueChangedCallback, Color color, float value, float minValue, float maxValue)
        {
            GUILayout.BeginVertical(); // Start the main vertical layout

            GUI.backgroundColor = color;

            GUILayout.BeginHorizontal();
            GUILayout.Label(label, GUILayout.ExpandWidth(false));
            GUILayout.FlexibleSpace();
            GUILayout.Label($"{value:F2}", GUILayout.Width(50));
            GUILayout.EndHorizontal();

            // Slider underneath the labels
            float newValue = GUILayout.HorizontalSlider(value, minValue, maxValue, GUILayout.ExpandWidth(true));

            // Check if the value has changed and invoke the callback if it has
            if (newValue != value)
            {
                valueChangedCallback?.Invoke(newValue);
            }

            GUILayout.EndVertical(); // End the main vertical layout
        }
        */
        public static void Slider(string label, Action<float> valueChangedCallback, Color color, float value, float minValue, float maxValue)
        {
            GUILayout.BeginVertical(); // Start the main vertical layout

            GUI.backgroundColor = color;

            GUILayout.BeginHorizontal();
            GUILayout.Label(label, GUILayout.ExpandWidth(false));
            GUILayout.FlexibleSpace();

            // Use a TextField instead of a Label for the value input
            string valueInput = GUILayout.TextField(value.ToString("F2"), GUILayout.Width(50));

            GUILayout.EndHorizontal();

            // Slider underneath the labels
            float newValue = GUILayout.HorizontalSlider(value, minValue, maxValue, GUILayout.ExpandWidth(true));

            // Check if the text field input is a valid float and different from the current slider value
            if (float.TryParse(valueInput, out float inputValue) && inputValue != value)
            {
                newValue = inputValue; // Update the slider position based on input field value
                value = newValue;      // Update the reference value to the new input
                valueChangedCallback?.Invoke(newValue); // Invoke the callback with new value
            }
            else if (newValue != value)
            {
                value = newValue; // Update the value if the slider moved
                valueChangedCallback?.Invoke(newValue); // Invoke the callback with new value
            }

            GUILayout.EndVertical(); // End the main vertical layout
        }
    }
}

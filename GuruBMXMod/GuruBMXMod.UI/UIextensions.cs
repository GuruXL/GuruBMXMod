using UnityEngine;

namespace GuruBMXMod.UI
{
    public static class UIextensions
    {
        private static string white = "#e6ebe8";
        private static string LightBlue = "#30e2e6";
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

        public static void Slider(string label, Action<float> valueChangedCallback, Color color, float value, float minValue, float maxValue)
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
    }
}

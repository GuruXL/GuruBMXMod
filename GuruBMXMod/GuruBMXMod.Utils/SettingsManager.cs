using Il2CppHellTap.MeshDecimator.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuruBMXMod.Utils
{
    public static class SettingsManager
    {
        public static Settings CurrentSettings { get; set; }
        public static Settings DefaultSettings { get; private set; }

        static SettingsManager()
        {
            CurrentSettings = new Settings();
            DefaultSettings = new Settings { ModEnabled = true };
        }

        // Method to reset current settings to the default
        public static void ResetToDefault()
        {
            CurrentSettings = DefaultSettings.Clone();
        }

        // Method to save current settings (could use serialization)
        public static void SaveSettings(string filePath)
        {
            // Serialization code to save CurrentSettings to a file
        }

        // Method to load settings into CurrentSettings (could use deserialization)
        public static void LoadSettings(string filePath)
        {
            // Deserialization code to load settings from a file into CurrentSettings
        }
    }
}

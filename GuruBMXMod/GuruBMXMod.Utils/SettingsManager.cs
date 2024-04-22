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

        public static void ResetToDefault()
        {
            CurrentSettings = DefaultSettings.Clone();
        }

        public static void SaveSettings(string filePath)
        {
            
        }

        public static void LoadSettings(string filePath)
        {
            
        }
    }
}

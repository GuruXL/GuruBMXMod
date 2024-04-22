using System.Collections.Generic;
using Il2Cpp;
using MelonLoader;

namespace GuruBMXMod.Utils
{
    public class ComponentCheck
    {
        public static void CheckComponents(Dictionary<string, object> components, string componentType)
        {
            bool allComponentsFound = true;

            foreach (KeyValuePair<string, object> component in components)
            {
                if (component.Value == null)
                {
                    MelonLogger.Msg($"{component.Key} NOT found");
                    allComponentsFound = false;
                }
            }

            if (allComponentsFound)
            {
                MelonLogger.Msg($"All {componentType} components found");
            }
        }
        /*
        public static void CheckComponents(params KeyValuePair<string, object>[] components)
        {
            bool allComponentsFound = true;

            foreach (KeyValuePair<string, object> component in components)
            {
                if (component.Value == null)
                {
                    MelonLogger.Msg($"{component.Key} NOT found");
                    allComponentsFound = false;
                }
            }

            if (allComponentsFound)
            {
                MelonLogger.Msg("All components found");
            }
        }
        */
    }
}

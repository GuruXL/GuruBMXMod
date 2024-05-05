using System.Collections.Generic;
using Il2Cpp;
using MelonLoader;

namespace GuruBMXMod.Utils
{
    public class ComponentCheck
    {
        /*
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
        */
        public static bool CheckComponents(Dictionary<string, object> components, string componentType)
        {
            bool allComponentsFound = true;

            foreach (KeyValuePair<string, object> component in components)
            {
                if (component.Value == null)
                {
                    MelonLogger.Msg($"{component.Key} NOT found");
                    allComponentsFound = false;
                    return false;
                }
            }

            if (allComponentsFound)
            {
                MelonLogger.Msg($"All {componentType} components found");
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

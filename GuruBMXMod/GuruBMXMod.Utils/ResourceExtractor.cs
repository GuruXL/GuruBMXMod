using MelonLoader;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace GuruBMXMod.Utils
{
    internal class ResourceExtractor
    {
        /*
        public static byte[] ExtractResources(string filename)
        {
            foreach (string resourceName in Assembly.GetExecutingAssembly().GetManifestResourceNames())
            {
                MelonLogger.Msg(resourceName);
            }

            using (Stream manifestResourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(filename))
            {
                if (manifestResourceStream == null)
                    MelonLogger.Msg($"manifestResourceStream Failed to Extract");
                    return null;

                byte[] buffer = new byte[manifestResourceStream.Length];
                manifestResourceStream.Read(buffer, 0, buffer.Length);
                return buffer;
            }
        }
        */
        public static byte[] ExtractResources(string filename)
        {
            // Log all resource names for debugging
            //foreach (string resourceName in Assembly.GetExecutingAssembly().GetManifestResourceNames())
            //{
            //    MelonLogger.Msg(resourceName);
            //}

            using (Stream manifestResourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(filename))
            {
                if (manifestResourceStream == null)
                {
                    MelonLogger.Msg($"Failed to extract resource: {filename}");
                    return null;
                }

                byte[] buffer = new byte[manifestResourceStream.Length];
                int bytesRead = 0;
                int totalBytesRead = 0;

                while ((bytesRead = manifestResourceStream.Read(buffer, totalBytesRead, buffer.Length - totalBytesRead)) > 0)
                {
                    totalBytesRead += bytesRead;
                }

                if (totalBytesRead != buffer.Length)
                {
                    MelonLogger.Msg("Did not read the full resource.");
                    return null;
                }

                return buffer;
            }
        }
    }
}

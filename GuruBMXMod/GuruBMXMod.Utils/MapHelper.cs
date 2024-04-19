using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuruBMXMod.Utils
{
    internal class MapHelper
    {
        public static List<string> GetModMapFileNames()
        {
            string directoryPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "BMX Streets\\Maps\\");

            // Check if the directory exists
            if (!Directory.Exists(directoryPath))
            {
                return new List<string>(); // Return an empty list if the directory does not exist
            }

            // Get all files in the directory
            string[] fileEntries = Directory.GetFiles(directoryPath);

            // Create a list to store the filenames
            List<string> fileNames = new List<string>();

            // Loop through each file found
            foreach (string fileName in fileEntries)
            {
                if (!fileName.EndsWith(".png") || !fileName.EndsWith(".jpg") || !fileName.EndsWith(".jpg"))
                {
                    fileNames.Add(Path.GetFileName(fileName));
                }
            }

            return fileNames;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuruBMXMod.Utils
{
    internal class TimeFormatter
    {
        public static string ConvertTimeTo12HourFormat(float timeDecimal)
        {
            // Ensure the time is within a typical 24-hour range
            if (timeDecimal < 0 || timeDecimal >= 24)
                return "Invalid time";  // Handle invalid time inputs

            int hours = (int)timeDecimal;
            int minutes = (int)((timeDecimal - hours) * 60);

            // Adjust hours for 12-hour clock format
            int displayHours = hours % 12;
            if (displayHours == 0) displayHours = 12;  // Adjust for 12 AM/PM

            string amPm = hours < 12 ? "AM" : "PM";

            // Ensure leading zero for single-digit minutes and seconds
            string minuteStr = minutes.ToString().PadLeft(2, '0');

            return $"{displayHours}:{minuteStr} {amPm}";
        }
    }
}

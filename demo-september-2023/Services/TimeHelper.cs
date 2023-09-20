using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerDemo.Models;

namespace TaskManagerDemo.Services
{
    public static class TimeHelper
    {
        private static readonly int SECONDS_IN_MINUTE = 60;
        public static string GetTimeDifferenceInMinSec(DateTime end, DateTime start)
        {
            var timeDiff = (end - start);
            var mins = Math.Floor(timeDiff.TotalMinutes);
            var secs = Math.Floor(timeDiff.TotalSeconds - (mins * SECONDS_IN_MINUTE));

            return $"{mins}:{secs}";
        }
    }
}

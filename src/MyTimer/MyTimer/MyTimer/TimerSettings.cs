using System;
using System.Collections.Generic;
using System.Text;

namespace MyTimer
{
    class TimerSettings
    {
        public static TimerSettings Instance { get; } = new TimerSettings();

        private TimerSettings() {; }

        public double CountMilliseconds { get; set; }
        public string SpeechText { get; set; }
        public bool UseSpeechText { get; set; }
    }
}

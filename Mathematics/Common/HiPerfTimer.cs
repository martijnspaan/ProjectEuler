using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace Mathematics.Common
{
    /// <summary>
    /// High performance timer class
    /// </summary>
    public class HiPerfTimer
    {
        private const string DurationMsTemplate = "Duration: {0} ms";
        public const int MsConversionFactor = 1000;

        [DllImport("Kernel32.dll")]
        private static extern bool QueryPerformanceCounter(out long lpPerformanceCount);
        [DllImport("Kernel32.dll")]
        private static extern bool QueryPerformanceFrequency(out long lpFrequency);
        private long _startTime, _stopTime;
        private readonly long _freq;

        /// <summary>
        /// Constructor
        /// </summary>
        public HiPerfTimer()
        {
            try
            {
                _startTime = 0;
                _stopTime = 0;

                if (QueryPerformanceFrequency(out _freq) == false)
                {
                    // high-performance counter not supported
                    throw new Exception("high-performance counter not supported");
                }
            }
            catch (Exception)
            {
                throw new Exception("high-performance counter not supported");
            }
        }

        /// <summary>
        /// Start the timer
        /// </summary>
        public void Start()
        {
            Reset();

            // lets do the waiting threads there work
            Thread.Sleep(0);
            QueryPerformanceCounter(out _startTime);
        }

        /// <summary>
        /// Stops the timer.
        /// </summary>
        public void Stop()
        {
            QueryPerformanceCounter(out _stopTime);
        }

        public void Reset()
        {
            _startTime = 0;
            _stopTime = 0;
        }


        /// <summary>
        /// Returns the duration of the timer (in milliseconds)
        /// </summary>
        public double Duration
        {
            get
            {
                return ((double)(_stopTime - _startTime) / (double)_freq) * MsConversionFactor;
            }
        }

        /// <summary>
        /// Returns the duration of the timer (in milliseconds)
        /// </summary>
        public string DurationMs
        {
            get
            {
                return String.Format(DurationMsTemplate, (((double)(_stopTime - _startTime) / (double)_freq) * MsConversionFactor));
            }
        }

        /// <summary>
        /// Returns the duration of the timer, formatted as a single string.
        /// </summary>
        public string DurationFormatted
        {
            get
            {
                var totalMilliseconds = (((_stopTime - _startTime) / (double)_freq) * MsConversionFactor);
                var totalSeconds = totalMilliseconds / (double)MsConversionFactor;
                var totalMinutes = totalSeconds / (double)60;

                return String.Format("{0:0.####} ms, {1:0.####} sec, {2:0.####} min", totalMilliseconds, totalSeconds, totalMinutes);
            }
        }
    }
}
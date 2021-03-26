using System;

namespace BlazorDesktopWeather
{
    public class WeatherResponse
    {
        public string Location { get; set; }
        public string WeatherText { get; set; }
        public Int32 WeatherIcon { get; set; }
        public string WeartherUri { get; set; }
        public bool IsDayTime { get; set; }
        public float Temperature { get; set; }
        public float RelativeHumidity { get; set; }
        public string WindDirection { get; set; }
        public float WindSpeed { get; set; }
        public Int32 UVIndex { get; set; }
        public float Pressure { get; set; }
        public float Past6HourMin { get; set; }
        public float Past6HourMax { get; set; }
        public DateTimeOffset RetrievedDateTimeOffset { get; set; }
    }
}

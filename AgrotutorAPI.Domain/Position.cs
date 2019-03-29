using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgrotutorAPI.Domain
{
    public class Position 
    {
        public DateTimeOffset Timestamp { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double? Altitude { get; set; }
        public double? Accuracy { get; set; }
        public double? Speed { get; set; }
        public double? Course { get; set; }
    }
}

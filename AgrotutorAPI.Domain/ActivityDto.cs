using System;

namespace AgrotutorAPI.Domain
{
    public class ActivityDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public ActivityTypeDto ActivityType { get; set; }   // enum!
        public string AmountApplied { get; set; }
        public string AppliedProduct { get; set; }
        public double Cost { get; set; }
        public double Price { get; set; }
        public double Dose { get; set; }

        public double NumberOfSeeds { get; set; }

        public PlotDto Plot { get; set; }
        public int PlotId { get; set; }
        public string ParcelId { get; set; }
        public string ProductObtained { get; set; }
        public string Sown { get; set; }
        public double WeightOfSeeds { get; set; }
        public string Yield { get; set; }
    }
}
﻿using AgrotutorAPI.Dto;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgrotutorAPI.Domain
{
    public class Activity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public ActivityTypeDto ActivityType { get; set; }   // enum!
        public string AmountApplied { get; set; }
        public string AppliedProduct { get; set; }
        public double Cost { get; set; }
        public double Price { get; set; }
        public double Dose { get; set; }

        public double NumberOfSeeds { get; set; }

        public Plot Plot { get; set; }
        public int PlotId { get; set; }
        public string ParcelId { get; set; }
        public string ProductObtained { get; set; }
        public string Sown { get; set; }
        public double WeightOfSeeds { get; set; }
        public string Yield { get; set; }
        public string Comment { get; set; }
        public int? SellingPrice { get; set; }
        public int? PlotArea { get; set; }
        public string AmountSold { get; set; }
    }
}
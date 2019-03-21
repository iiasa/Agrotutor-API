
using AgrotutorAPI.Data.Postgresql;
using AgrotutorAPI.Data.Postgresql.Repositories;
using AgrotutorAPI.Domain;
using AgrotutorAPI.Dto;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AgrotutorAPI.Test
{
    [TestClass]
    public class AgrotutorTest
    {
        DbContextOptions<AgrotutorContext> dbInMemoryOption;
        public AgrotutorTest()
        {
            dbInMemoryOption = new DbContextOptionsBuilder<AgrotutorContext>().UseInMemoryDatabase("AgrotutorDB").Options;
            SeedData();
        }
        [TestMethod]
        public void CanRetrieveListPlots()
        {
            var context = new AgrotutorContext(dbInMemoryOption);
            var rep = new PlotRepository(context);
          var result=  rep.GetPlots();
           var resultCount = result.Count();
            Assert.AreEqual(2, resultCount);
        }
        [TestMethod]
        public void UploadPictures()
        {
            var context = new AgrotutorContext(dbInMemoryOption);
            var rep = new PictureRepository(context);
            var result = rep.GetPlots();
            var resultCount = result.Count();
            Assert.AreEqual(2, resultCount);
        }
        [TestMethod]
        public void CreatPlot()
        {
            var context = new AgrotutorContext(dbInMemoryOption);
            var rep = new PlotRepository(context);
            var newPlot = new Plot { Id = 3, CropType = CropTypeDto.Alfalfa, ClimateType = ClimateTypeDto.Cold, Irrigated = false, Name = "Test1", MaturityType = MaturityTypeDto.Early, Activities = new List<Activity> { new Activity { Id = 3, Name = "ActivityTest1", ActivityType = ActivityTypeDto.Commercialization, AmountApplied = "AmountAppliedTest1", AmountSold = "AmountSoldTest1", Comment = "CommentTest", AppliedProduct = "AppliedProductTest1", Cost = 10, Date = DateTime.Now, Dose = 10, ParcelId = "3", NumberOfSeeds = 10, Price = 100, ProductObtained = "ProductObtainedTest1", Sown = "SownTest1", SellingPrice = 50, WeightOfSeeds = 200, Yield = "Yield1", PlotArea = 1 } } };
            rep.AddPlot(newPlot);
         var saveResult=   context.SaveChanges();
            var result = rep.GetPlots();
            var resultCount = result.Count();
            Assert.AreEqual(3, resultCount);
        }
        private void SeedData()
        {
            using (var context = new AgrotutorContext(dbInMemoryOption))
            {
                if (!context.Plots.Any())
                {
                    context.Plots.AddRange(new Plot { Id = 1, CropType = CropTypeDto.Alfalfa, ClimateType = ClimateTypeDto.Cold, Irrigated = false, Name = "Test1", MaturityType = MaturityTypeDto.Early, Activities = new List<Activity> { new Activity { Id = 1, Name = "ActivityTest1", ActivityType = ActivityTypeDto.Commercialization, AmountApplied = "AmountAppliedTest1", AmountSold = "AmountSoldTest1", Comment = "CommentTest", AppliedProduct = "AppliedProductTest1", Cost = 10, Date = DateTime.Now, Dose = 10, ParcelId = "1", NumberOfSeeds = 10, Price = 100, ProductObtained = "ProductObtainedTest1", Sown = "SownTest1", SellingPrice = 50, WeightOfSeeds = 200, Yield = "Yield1", PlotArea = 1 } } },
                        new Plot { Id = 2, CropType = CropTypeDto.Amaranth, ClimateType = ClimateTypeDto.TemperedSubtropical, Irrigated = true, Name = "Test2", MaturityType = MaturityTypeDto.Intermediate, Activities = new List<Activity> { new Activity { Id = 2, Name = "ActivityTest2", ActivityType = ActivityTypeDto.Harvest, AmountApplied = "AmountAppliedTest2", AmountSold = "AmountSoldTest2", Comment = "CommentTest2", AppliedProduct = "AppliedProductTest2", Cost = 20, Date = DateTime.Now, Dose = 30, ParcelId = "2", NumberOfSeeds = 10, Price = 300, ProductObtained = "ProductObtainedTest2", Sown = "SownTest2", SellingPrice = 100, WeightOfSeeds = 400, Yield = "Yield2", PlotArea = 1 } } });
                    context.SaveChanges();
                }
            }
        }
    }
}

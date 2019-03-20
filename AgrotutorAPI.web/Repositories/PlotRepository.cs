using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgrotutorAPI.Data;
using AgrotutorAPI.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace AgrotutorAPI.web.Repositories
{
    public class PlotRepository: IPlotRepository
    {
        private AgrotutorContext _agrotutorContext;
        public PlotRepository(AgrotutorContext agrotutorContext)
        {
            _agrotutorContext = agrotutorContext;
        }


        public void AddPlot(Plot plot)
        {
            _agrotutorContext.Plots.Add(plot);

        }

        public bool Save()
        {
            return _agrotutorContext.SaveChanges() >= 0;
        }

        public IEnumerable<Plot> GetPlots()
        {
            return _agrotutorContext.Plots.Include(p=>p.Activities).OrderBy(p => p.Name);
        }

        public Plot GetPlotById(int plotId)
        {
            return _agrotutorContext.Plots.Include(p => p.Activities).FirstOrDefault(p => p.Id == plotId);
        }

     
    }
}

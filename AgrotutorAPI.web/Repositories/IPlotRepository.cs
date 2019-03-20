using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgrotutorAPI.Data.Entities;

namespace AgrotutorAPI.web.Repositories
{
    public interface IPlotRepository
    {
        IEnumerable<Plot> GetPlots();
        Plot GetPlotById(int plotId);
         void AddPlot(Plot plot);
        bool Save();
    }

}

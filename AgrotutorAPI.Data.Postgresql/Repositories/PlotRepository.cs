using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgrotutorAPI.Data.Contract;
using AgrotutorAPI.Domain;
using Microsoft.EntityFrameworkCore;

namespace AgrotutorAPI.Data.Postgresql.Repositories
{
    public class PlotRepository: IPlotRepository
    {
        private AgrotutorContext _agrotutorContext;
        public PlotRepository(AgrotutorContext agrotutorContext)
        {
            _agrotutorContext = agrotutorContext;
        }


        public async Task AddPlotAsync(Plot plot)
        {
          await  _agrotutorContext.Plots.AddAsync(plot);

        }

        public void UpdatePlot(Plot plot)
        {
            _agrotutorContext.Update(plot);
        }

        public async Task<bool> SaveAsync()
        {
            return await _agrotutorContext.SaveChangesAsync() >= 0;
        }

        public async Task<IEnumerable<Plot>> GetPlotsAsync()
        {
            return await _agrotutorContext.Plots.Include(p=>p.Activities).OrderBy(p => p.Name).ToListAsync();
        }

        public async Task<Plot> GetPlotByIdAsync(int plotId)
        {
            return await _agrotutorContext.Plots.Include(p => p.Activities).FirstOrDefaultAsync(p => p.Id == plotId);
        }

        public async Task<Plot> GetPlotByMobileIdAndLocation(int mobileId, Position position)
        {
            var plot =  await _agrotutorContext.Plots
                .Include(p => p.Activities)
                .Include(p => p.Position)
                .Include(p => p.Delineation)
                .Include(p => p.MediaItems)
                .Where(p => p.MobileId == mobileId && Math.Abs(p.Position.Latitude - position.Latitude) < 0.00001 &&
                            Math.Abs(p.Position.Longitude - position.Longitude) < 0.00001).FirstOrDefaultAsync();

            return plot;
        }
    }
}

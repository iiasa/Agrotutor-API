using System.Collections.Generic;
using System.Threading.Tasks;
using AgrotutorAPI.Domain;

namespace AgrotutorAPI.Data.Contract
{
    public interface IPlotRepository
    {
        Task<IEnumerable<Plot>> GetPlotsAsync();
        Task<Plot> GetPlotByIdAsync(int plotId);
        Task AddPlotAsync(Plot plot);
        Task<bool> SaveAsync();
    }

}

using System.Collections.Generic;
using System.Threading.Tasks;
using vega.Core.Models;

namespace vega.Core
{
    public interface IRepository
    {
        Task<List<Make>> GetMakes();
        Task<List<Feature>> GetFeatures();
        Task AddVehicleAsync(Vehicle vehicle);
        void RemoveVehicle(Vehicle vehicle);
        Task<Vehicle> GetVehicleAsync(int id, bool includeRelated = true);
        Task<QueryResult<Vehicle>> GetVehiclesAsync(VehicleQuery queryObj);
    }
}
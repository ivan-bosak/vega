using System.Collections.Generic;
using System.Threading.Tasks;
using vega.Core.Models;

namespace vega.Core
{
    public interface IRepository
    {
        Task<IEnumerable<Make>> GetMakes();
        Task<IEnumerable<Feature>> GetFeatures();
        Task AddVehicle(Vehicle vehicle);
        void RemoveVehicle(Vehicle vehicle);
        Task<Vehicle> GetVehicle(int id, bool includeRelated = true);
    }
}
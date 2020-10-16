using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using vega.Core;
using vega.Core.Models;

namespace vega.Persistence
{
    public class VegaRepository : IRepository
    {
        private readonly VegaDbContext context;
        public VegaRepository(VegaDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Make>> GetMakes()
        {
            return await context.Makes.Include(m => m.Models).ToListAsync();
        }

        public async Task<IEnumerable<Feature>> GetFeatures()
        {
            return await context.Features.ToListAsync();
        }

        public async Task AddVehicle(Vehicle vehilce)
        {
            await context.Vehicles.AddAsync(vehilce);
        }

        public void RemoveVehicle(Vehicle vehilce)
        {
            context.Vehicles.Remove(vehilce);
        }

        public async Task<Vehicle> GetVehicle(int id, bool includeRelated = true)
        {
            if(!includeRelated)
                return await context.Vehicles.FirstOrDefaultAsync(v => v.Id == id);
                
            return await context.Vehicles
                .Include(v => v.Features)
                    .ThenInclude(vf => vf.Feature)
                .Include(v => v.Model)
                    .ThenInclude(m => m.Make)
                .SingleOrDefaultAsync(v => v.Id == id);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using vega.Core;
using vega.Core.Models;
using vega.Extensions;

namespace vega.Persistence
{
    public class VegaRepository : IRepository
    {
        private readonly VegaDbContext context;
        public VegaRepository(VegaDbContext context)
        {
            this.context = context;
        }

        public Task<List<Make>> GetMakes()
        {
            //return Task.Run(() => context.Makes.Include(m => m.Models).ToListAsync());
            return context.Makes.Include(m => m.Models).ToListAsync();
        }

        public Task<List<Feature>> GetFeatures()
        {
           return Task.Run(() => context.Features.ToListAsync());
        }

        public Task AddVehicleAsync(Vehicle vehilce)
        {
            return Task.Run(() => context.Vehicles.AddAsync(vehilce));
        }

        public void RemoveVehicle(Vehicle vehilce)
        {
            context.Vehicles.Remove(vehilce);
        }

        public Task<Vehicle> GetVehicleAsync(int id, bool includeRelated = true)
        {
            if(!includeRelated)
                return context.Vehicles.FirstOrDefaultAsync(v => v.Id == id);
                
            return context.Vehicles
                .Include(v => v.Features)
                    .ThenInclude(vf => vf.Feature)
                .Include(v => v.Model)
                    .ThenInclude(m => m.Make)
                .SingleOrDefaultAsync(v => v.Id == id);
        }
        public async Task<QueryResult<Vehicle>> GetVehiclesAsync(VehicleQuery queryObj)
        {
            var queryResult = new QueryResult<Vehicle>();

            var query = context.Vehicles
                .Include(v => v.Features)
                    .ThenInclude(vf => vf.Feature)
                .Include(v => v.Model)
                    .ThenInclude(m => m.Make)
                .AsQueryable();

            if(queryObj.MakeId.HasValue)
                query = query.Where(v => v.Model.MakeId == queryObj.MakeId);

            var columnsMap = new Dictionary<string, Expression<Func<Vehicle, object>>>()
            {
                ["make"] = v => v.Model.Make.Name,
                ["model"] = v => v.Model.Name,
                ["id"] = v => v.Id
            };
            
            query = query.ApplyOrdering<Vehicle>(queryObj, columnsMap);
            queryResult.TotalItems = await query.CountAsync();
            query = query.ApplyPagination<Vehicle>(queryObj);
            queryResult.Items = await query.ToListAsync();
            
            return queryResult;
        }
    }
}
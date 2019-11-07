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
    }
}
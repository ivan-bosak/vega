using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using vega.Core;
using vega.Core.Models;

namespace vega.Persistence
{
    public class PhotoReposritory: IPhotoRepository
    {
        private readonly VegaDbContext context;

        public PhotoReposritory(VegaDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Photo>> GetPhotos(int vehicleId)
        {
            var vehicle =  await context.Vehicles.Include(v => v.Photos).FirstAsync();

            return vehicle.Photos;
        }
    }
}
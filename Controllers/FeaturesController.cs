using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using vega.Controllers.Resources;
using vega.Core;
using vega.Core.Models;

namespace vega.Controllers
{
    [ApiController]
    [Route("/api/features")]
    public class FeaturesController : Controller
    {
        private readonly IRepository repository;
        private readonly IMapper mapper;
        public FeaturesController(IRepository repository, IMapper mapper)
        {
            this.mapper = mapper;
            this.repository = repository;
        }

        public async Task<IEnumerable<KeyValuePairResource>> GetFeatures()
        {
            var features = await repository.GetFeatures();

            return mapper.Map<IEnumerable<Feature>, IEnumerable<KeyValuePairResource>>(features);
        }
    }
}
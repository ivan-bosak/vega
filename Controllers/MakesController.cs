using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using vega.Controllers.Resources;
using vega.Core.Models;
using vega.Core;

namespace vega.Controllers
{
    [ApiController]
    [Route("/api/makes")]
    public class MakesController : Controller
    {
        private readonly IRepository repository;
        private readonly IMapper mapper;
        public MakesController(IRepository repository, IMapper mapper)
        {
            this.mapper = mapper;
            this.repository = repository;
        }

        public async Task<IEnumerable<MakeResource>> GetMakes()
        {
            var makes = await repository.GetMakes();

            return mapper.Map<IEnumerable<Make>, IEnumerable<MakeResource>>(makes);
        }
    }
}
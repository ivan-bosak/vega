using System;
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
    [Route("/api/vehicles")]
    public class VehiclesController : Controller
    {
        private readonly IMapper mapper;
        private readonly IRepository repository;
        private readonly IUnitOfWork ufw;
        public VehiclesController(IMapper mapper, IRepository repository, IUnitOfWork ufw)
        {
            this.ufw = ufw;
            this.repository = repository;
            this.mapper = mapper;
        }
        [HttpPost]
        public async Task<IActionResult> CreateVehicle([FromBody] SaveVehicleResource vehicleResource)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var vehicle = mapper.Map<SaveVehicleResource, Vehicle>(vehicleResource);
            vehicle.LastUpdated = DateTime.Now;

            await repository.AddVehicleAsync(vehicle);
            await ufw.Complete();
            
            vehicle = await repository.GetVehicleAsync(vehicle.Id);
            var result = mapper.Map<Vehicle, VehicleResource>(vehicle);

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVehicle(int id, [FromBody] SaveVehicleResource vehicleResource)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var vehicle = await repository.GetVehicleAsync(id);

            if(vehicle == null)
                return NotFound();

            mapper.Map<SaveVehicleResource, Vehicle>(vehicleResource, vehicle);
            vehicle.LastUpdated = DateTime.Now;

            await ufw.Complete();
            vehicle = await repository.GetVehicleAsync(vehicle.Id);
            var result = mapper.Map<Vehicle, VehicleResource>(vehicle);

            return Ok(result);
        }
        

        [HttpGet("{id}")]
        public async Task<IActionResult> GetVehicle(int id)
        {
            var vehicle = await repository.GetVehicleAsync(id);

            if(vehicle == null)
                return NotFound();

            var result = mapper.Map<Vehicle, VehicleResource>(vehicle);

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetVehicles([FromQuery]VehicleQueryResource filterResource)
        {
            var filter = mapper.Map<VehicleQueryResource, VehicleQuery>(filterResource);
            var queryResult = await repository.GetVehiclesAsync(filter);

            var result = mapper.Map<QueryResult<Vehicle>, QueryResultResource<VehicleResource>>(queryResult);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehicle(int id)
        {
            var vehicle = await repository.GetVehicleAsync(id, includeRelated: false);

            if(vehicle == null)
                return NotFound();

            repository.RemoveVehicle(vehicle);
            await ufw.Complete();

            return Ok();
        }
    }
}
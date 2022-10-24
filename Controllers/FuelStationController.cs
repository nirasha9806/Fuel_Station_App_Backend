using backend.Models;
using backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuelStationController : ControllerBase
    {
        private readonly IFuelStationService fuelStationService;

        public FuelStationController(IFuelStationService fuelStationService)
        {
            this.fuelStationService = fuelStationService;
        }

        [HttpGet]
        public ActionResult<List<FuelStation>> Get()
        {
            return fuelStationService.Get();
        }

        [HttpGet("{id}")]
        public ActionResult<FuelStation> Get(string id)
        {
            var fuelStation = fuelStationService.Get(id);

            if(fuelStation == null){
                return NotFound($"Fuel Station with Id = {id} not found");
            }

            return fuelStation;
        }

        [HttpPost]
        public ActionResult<FuelStation> Post([FromBody] FuelStation fuelStation)
        {
             fuelStationService.Create(fuelStation);

             return CreatedAtAction(nameof(Get), new {id = fuelStation.id}, fuelStation);
        }

        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] FuelStation fuelStation)
        {
             var existingFuelStation = fuelStationService.Get(id);

             if(existingFuelStation == null){
                return NotFound($"Fuel Station with Id = {id} not found");
             }

             fuelStationService.Update(id,fuelStation);

             return NoContent();
        }

         [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
             var existingFuelStation = fuelStationService.Get(id);

             if(existingFuelStation == null){
                return NotFound($"Fuel Station with Id = {id} not found");
             }

             fuelStationService.Remove(id);

             return Ok($"Fuel Station with Id = {id} deleted");
        }
    }
}
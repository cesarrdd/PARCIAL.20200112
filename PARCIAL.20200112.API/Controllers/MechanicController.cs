using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using PARCIAL._20200112.DOMAIN.Core.Interfaces;
using PARCIAL._20200112.DOMAIN.Infrastructure.Data;

namespace PARCIAL._20200112.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MechanicController : ControllerBase
    {

        private readonly IMechanicRepository _mechanicRepository;

        public MechanicController(IMechanicRepository mechanicRepository)
        {
            _mechanicRepository = mechanicRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetMechanic()
        {
            var mechanic = await _mechanicRepository.GetMechanic();
            return Ok(mechanic);
        }

        public Task<IActionResult> GetMechanicById(int id, [FromQuery] bool includeMechanics)
        {
            return GetMechanicById(id, includeMechanics, _mechanicRepository);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMechanicById(int id, [FromQuery] bool includeMechanics, IMechanicRepository _mechanicRepository)
        {
            if (includeMechanics)
                return Ok(await _mechanicRepository.GetMechanicById(id));

            return Ok(await _mechanicRepository.GetMechanicById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Mechanic mechanic)
        {
            int id = await _mechanicRepository.Insert(mechanic);
            return Ok(id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] Mechanic mechanic)
        {
            if (id != mechanic.Id) return BadRequest();

            var result = await _mechanicRepository.Update(mechanic);
            if (!result) return BadRequest();
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var result = await _mechanicRepository.Delete(id);
            if (!result) return BadRequest();
            return Ok(result);
        }
    }
}

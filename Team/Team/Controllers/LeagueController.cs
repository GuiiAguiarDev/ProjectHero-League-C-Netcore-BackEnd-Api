using Application.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using SQLitePCL;

namespace ProjectTeam.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class LeagueController : ControllerBase
    {

        private readonly Application.Services.Service _service;

        public LeagueController(Service service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Save(League team)
        {
            await _service.Save(team);

            return Ok(new { message = "Register successfully" });
        }

        [HttpGet]
        public async Task<IActionResult>FindAll()
        {
            var l = await _service.FindAll();

            return Ok(l);
        }

        [HttpGet("{id}")]
        public async Task <IActionResult>FindById(Guid id)
        {
            var l = await _service.FindById(id);

            if (l == null) return NotFound();

            return Ok(l);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, League updateLeague)
        {
           await _service.Update(id, updateLeague);

            return Ok(new { message = "Updated" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete (Guid id)
        {
            await _service.Delete(id);

            return Ok(new { message = "Deleted" });
        }

    }
}

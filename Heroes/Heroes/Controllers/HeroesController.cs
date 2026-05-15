using System.Threading.Tasks;
using Application.Interfaces;
using Application.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Heroes.Controllers
{



    [ApiController]
    [Route("api/[controller]")]
    public class HeroesController: ControllerBase
    {

        private readonly Service _service;

        public HeroesController(Service service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Save(Heroe heroe)
        {
           await _service.Save(heroe);

            return Ok(new { message = "Saved" });
        }

        [HttpGet]
        public async Task<IActionResult> FindAll()
        {
            var h = await _service.FindAll();

            return Ok(h);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult>FindById(Guid id)
        {
            var h = await _service.FindById(id);

            return Ok(h);
        }

        [HttpDelete]
        public async Task<IActionResult>Delete(Guid id)
        {
            await _service.Delete(id);

            return Ok(new { Message = "Deleted" });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult>Update(Guid id, Heroe heroeUpdate)
        {
            await _service.Update(id, heroeUpdate);

            return Ok(new { Message = "Updated" });
        }


        //EndoPoint de busca trazendo todos os dados a partir do relacionamento
        //de heroe e league junto amarrado (FindAll)
        [HttpGet("all")]
        public async Task<IActionResult> FindAllHeroeLeague()
        {
            var heroes = await _service.FindAllHeroeLeague();
            return Ok(heroes);
        }


        //EndoPoint de busca trazendo especifico um por um pelo id
        //os dados a partir do relacionamento
        //de heroe e league junto amarrado (FindById)
        [HttpGet("league/{id}")]
        public async Task<IActionResult> FindByIdHeroeLeague(Guid id)
        {
            var heroe = await _service.FindByIdHeroeLeague(id);

            return Ok(heroe);

        }
    }



}


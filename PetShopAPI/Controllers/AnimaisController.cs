using Microsoft.AspNetCore.Mvc;
using PetShop.Application;
using PetShop.Domain.Estruturas;

namespace PetShopAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnimaisController : ControllerBase
    {
        private readonly AnimalService _service;

        public AnimaisController(AnimalService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Get() => Ok(_service.ObterTodos());

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var animal = _service.ObterPorId(id);
            if (animal == null) return NotFound();
            return Ok(animal);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Animal animal)
        {
            _service.Adicionar(animal);
            return CreatedAtAction(nameof(Get), new { id = animal.Id }, animal);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Animal animal)
        {
            if (id != animal.Id) return BadRequest();
            _service.Atualizar(animal);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.Remover(id);
            return NoContent();
        }
    }
}

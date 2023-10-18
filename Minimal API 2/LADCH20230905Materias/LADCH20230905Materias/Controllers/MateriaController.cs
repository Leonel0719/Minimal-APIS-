using LADCH20230905Materias.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LADCH20230905Materias.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MateriaController : ControllerBase
    {
        static List<Materia> materias = new List<Materia>();

        [HttpGet]
        public IEnumerable<Materia> Get()
        {
            return materias;
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var exiatingMateria = materias.FirstOrDefault(m => m.Id == id);
            if (exiatingMateria != null)
            {
                materias.Remove(exiatingMateria);
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Materia materia)
        {
            materias.Add(materia);
            return Ok();
        }
    }
}

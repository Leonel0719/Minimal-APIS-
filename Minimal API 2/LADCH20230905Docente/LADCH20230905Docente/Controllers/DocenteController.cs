using LADCH20230905Docente.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LADCH20230905Docente.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocenteController : ControllerBase
    {
        static List<Docente> docentes = new List<Docente>();

        [HttpPost]
        // agrecar
        public IActionResult Post([FromBody] Docente docente)
        {
            docentes.Add(docente);
            return Ok();
        }

        [HttpGet("{id}")]

        public Docente Get(int id)
        {
            var docente = docentes.FirstOrDefault(d => d.Id == id);
            return docente;
        }

    }
}

using LADCH20230905Alumnos.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LADCH20230905Alumnos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlumnoController : ControllerBase
    {
        static List<Alumno> alumnos = new List<Alumno>();

        //agregar
        [HttpPost]
        public IActionResult Post([FromBody] Alumno alumno)
        {
            alumnos.Add(alumno);
            return Ok();
        }

        // modificar
        [HttpPut("{id}")]
        public IActionResult Put    (int id, [FromBody] Alumno alumno)
        {
            var existingAlumno = alumnos.FirstOrDefault(a => a.Id == id);
            if (existingAlumno != null)
            {
                existingAlumno.nombre = alumno.nombre;
                existingAlumno.apellido = alumno.apellido;
                existingAlumno.edad = alumno.edad;
                return Ok();
            }
            else
            {
                return NotFound();
            }

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existingAlumno = alumnos.FirstOrDefault(a => a.Id == id);
            if (existingAlumno != null)
            {
                alumnos.Remove(existingAlumno);
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        public IEnumerable<Alumno> Get()
        {
            return alumnos;
        }

        [HttpGet("{id}")]
        public Alumno Get(int id)
        {
            var alumno = alumnos.FirstOrDefault(c => c.Id == id);
            return alumno;
        }

    }
}

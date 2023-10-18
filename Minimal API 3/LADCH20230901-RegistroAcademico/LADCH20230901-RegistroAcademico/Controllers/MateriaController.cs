using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using LADCH20230901_RegistroAcademico.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LADCH20230901_RegistroAcademico.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MateriaController : ControllerBase
    {
        //Declaracion de una lista estatica de objetos 'Matriculas' para almacanea matriculas registradas
        static List<Matricula> matricula = new List<Matricula>();

        [HttpPost("CrearMatricula")]
        public IActionResult Post([FromBody] Matricula matriculas)
        {
            matricula.Add(matriculas);
            return Ok();
        }



        //Definicion de un metodo HTTP PUT para actualizar un cliente existente en la lista por su ID
        [HttpPut("{id}/ModificarMatricula")]

        public IActionResult Put(int id, [FromBody] Matricula matriculas)
        {
            var existingMatricula = matricula.FirstOrDefault(M => M.Id == id);
            if (existingMatricula != null)
            {

                existingMatricula.NameStudent = matriculas.NameStudent;
                existingMatricula.Classroom = matriculas.Classroom;

                return Ok();
            }
            else
            {
                return NotFound();
            }
        }


        //Definicion de un metodo HTTP GET que recibe un ID como parametro y devuelve una Matricula especifica
        [HttpGet("{id}/ObtenerPorIdMatricula")]
        public Matricula Get(int id)
        {
            var matriculas = matricula.FirstOrDefault(M => M.Id == id);
            return matriculas;
        }
    }
}

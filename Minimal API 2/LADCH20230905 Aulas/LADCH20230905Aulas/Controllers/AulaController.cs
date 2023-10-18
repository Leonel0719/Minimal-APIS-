using LADCH20230905Aulas.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LADCH20230905Aulas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AulaController : ControllerBase
    {
        static List<Aula> aulas = new List<Aula>
        {
        new Aula { Id = 1, Nombre = "Aula A-10" },
        new Aula { Id = 2, Nombre = "Aula B-6" },
        new Aula{ Id = 3, Nombre = "Aula Z-25"},
        new Aula{ Id = 4, Nombre = "Aula B-32"},
        new Aula{ Id = 5, Nombre = "Aula C-10"},

        };

        [HttpGet]
        //obtenner
        public IEnumerable<Aula> Get()
        {
            return aulas;
        }

    }
}

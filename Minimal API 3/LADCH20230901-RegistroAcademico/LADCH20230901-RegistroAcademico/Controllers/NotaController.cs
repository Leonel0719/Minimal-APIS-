﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LADCH20230901_RegistroAcademico.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotaController : ControllerBase
    {
        //Crea una lista de objetos'nota' para almacenar informacion
        static List<object> nota = new List<object>();

        [HttpGet("ObtenerNotas")]
        //Permite el acceso publico a esta accion, incluso  si no se ha autenticado el usuario
        public IEnumerable<object> Get()
        {
            //Desvuelve los datos almacenados en la lista  si no se ha autenticado el usuario
            return nota;
        }

        //Crea una nueva nota solo si el usuario esta autorizado
        [Authorize]
        [HttpPost("RegistrarNotas")]
        public IActionResult Post(string nameStudent, string subject, double qualification)
        {
            //Agerga un nuevo abjeto anonimo con 'nameStudent' 'subject' y 'qualification' a
            //la lista 'nota' en respuesta a una solocitud POST  

            nota.Add(new { nameStudent, subject, qualification });

            //Devuelve una respuesta HTTP exitosa
            return Ok();
        }
    }
}

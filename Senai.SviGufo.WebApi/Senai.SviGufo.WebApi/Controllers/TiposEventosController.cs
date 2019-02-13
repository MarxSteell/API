using Microsoft.AspNetCore.Mvc;
using Senai.SviGufo.WebApi.Domains;
using System.Collections.Generic;

namespace Senai.SviGufo.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class TiposEventosController : ControllerBase
    {
        //Declaração de um objeto list do tipo TipoEventoDomain
        List<TipoEventoDomain> tiposEventos = new List<TipoEventoDomain>()
        {
            new TipoEventoDomain{ ID = 1, Nome = "Tecnologia"},
            new TipoEventoDomain{ ID = 2, Nome = "Arquitetura"},
            new TipoEventoDomain{ ID = 3, Nome = "Engenharia"},
            new TipoEventoDomain{ ID = 4, Nome = "Medicina"}
        };
        /// <summary>
        /// Retorna uma string atraves do metodo Get
        /// </summary>
        /// <returns>String</returns>
        //[HttpGet]
        //public string Get()
        //{
        //  return "Requisição recebida com sucesso";
        //}
        
        //Define que o retorno será um json
        [HttpGet]
        //Retorna uma lista de  eventos
        public IEnumerable<TipoEventoDomain> Get() => tiposEventos;
        
        /// <summary>
        /// Retorna um tipo de evento pelo seu ID
        /// </summary>
        /// <param name="id">ID do evento</param>
        /// <returns>TipoEventoDomain</returns>
        [HttpGet("{id}")]
        public IActionResult GetByID(int id)
        {
            //Busca um tipo de evento pelo seu ID
            TipoEventoDomain tipoEventoSerProcurado = tiposEventos.Find(x => x.ID == id);

            if (tipoEventoSerProcurado == null)
            {
                return NotFound();
            }

            return Ok(tipoEventoSerProcurado);
        }
    }
}
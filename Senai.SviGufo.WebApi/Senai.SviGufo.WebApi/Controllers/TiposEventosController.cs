using Microsoft.AspNetCore.Mvc;
using Senai.SviGufo.WebApi.Domains;
using Senai.SviGufo.WebApi.Interfaces;
using Senai.SviGufo.WebApi.Repositorios;
using System.Collections.Generic;

namespace Senai.SviGufo.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
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

        private ITipoEventoRepositorio TipoEventoRepositorio { get; set; }

        public TiposEventosController()
        {
            TipoEventoRepositorio = new TipoEventoRepositorio();
        }

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
        public IEnumerable<TipoEventoDomain> Get()
        {
            return TipoEventoRepositorio.Listar();
        }
        
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

        [HttpPost]
        public IActionResult Post(TipoEventoDomain tipoEvento)
        {
            return Ok();
        }

        /// <summary>
        /// Atualiza um tipo de evento
        /// </summary>
        /// <param name="tipoEvento">Tipo de Eento a ser atualizado</param>
        /// <returns>Retorna um status code</returns>
        [HttpPut]
        public IActionResult Put(TipoEventoDomain tipoEvento)
        {
            TipoEventoRepositorio.Cadastrar(tipoEvento);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, TipoEventoDomain tipoEvento)
        {
            TipoEventoRepositorio.Alterar(tipoEvento);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            TipoEventoRepositorio.Deletar(id);
            return Ok();
        }
    }
}
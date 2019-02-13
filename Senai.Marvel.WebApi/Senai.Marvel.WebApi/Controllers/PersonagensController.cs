using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Marvel.WebApi.Domains;

namespace Senai.Marvel.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class PersonagensController : ControllerBase
    {
        List<PersonagensDomain> personagensMarvel = new List<PersonagensDomain>()
        {
            new PersonagensDomain{ ID = 1, Nome = "Homem-Aranha", Lancamento = "Amazing Fantasy #15 (1962)", Descricao = "O adolescente que é mordido por uma aranha radioativa conseguiu se tornar no super-herói mais famoso de todos os tempos, estabelecendo uma forte conexão com todos os jovens que entram em contato com sua história."},
            new PersonagensDomain{ ID = 2, Nome = "O Incrível Hulk", Lancamento = "O Incrível Hulk #1 (1962)", Descricao = "O Incrível Hulk não é mais do que uma alegoria sobre a perda do auto-controle e como a raiva pode ser canalizada para algo positivo."},
            new PersonagensDomain{ ID = 3, Nome = "Homem de Ferro", Lancamento = "Tales of Suspense #39 (1963)", Descricao = "Homem de Ferro é um personagem conhecido por ter pegado em uma situação extremamente má e se tornar em um super-herói. Com a ajuda de dinheiro e genialidade, claro."}
        };

        [HttpGet]
        public IEnumerable<PersonagensDomain> Get() => personagensMarvel;

        [HttpGet("{id}")]
        public IActionResult GetByID(int id)
        {
            PersonagensDomain PersonagemProcurado = personagensMarvel.Find(x => x.ID == id);

            if (PersonagemProcurado == null)
            {
                return NotFound();
            }

            return Ok(PersonagemProcurado);
        }
    }
}
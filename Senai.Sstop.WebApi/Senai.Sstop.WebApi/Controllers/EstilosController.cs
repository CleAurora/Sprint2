using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Sstop.WebApi.Domains;
using Senai.Sstop.WebApi.Repositories;

namespace Senai.Sstop.WebApi.Controllers
{
    [Route("api/estilos")]
    [Produces("application/json")]
    [ApiController]
   
    public class EstilosController : ControllerBase
    {

        List<EstiloDomain> estilos = new List<EstiloDomain>()
        {
            new EstiloDomain { IdEstilo = 1, Nome = "Rock"}
            , new EstiloDomain { IdEstilo = 1, Nome = "Pop"}
        };

        EstiloRepository estiloRepository = new EstiloRepository();

        [Produces("application/json")]

        [HttpGet]
        public IEnumerable<EstiloDomain> Listar()
        {
            //return estilos;
            return estiloRepository.Listar();
        }

        
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {

            EstiloDomain Estilo = estiloRepository.BuscarPorId(id);
            //EstiloDomain Estilo = estilos.Find(x => x.IdEstilo == id);
            if(Estilo == null)
            {
                return NotFound();
            }
            return Ok(Estilo);
        }

        //[HttpPost]
        //public IActionResult Cadastrar(EstiloDomain estiloDomain)
        //{
        //    estilos.Add(new EstiloDomain
        //   {
        //     IdEstilo = estilos.Count + 1,
        //   Nome = estiloDomain.Nome
        //      }
        //      );
        //      return Ok(estilos);
        //  }

        
     

        [HttpPost]
        public IActionResult Cadastrar(EstiloDomain estiloDomain)
        {
            //do bd
            estiloRepository.Cadastrar(estiloDomain);
            return Ok();
        }

        //Atualizar
        [HttpPut]
        public IActionResult Atualizar(EstiloDomain estiloDomain)
        {
            estiloRepository.Alterar(estiloDomain);
            return Ok();
        }

        //Deletar
        [HttpDelete("{ id}")]
        public IActionResult Deletar(int id)
        {
            estiloRepository.Deletar(id);
            return Ok();
        }
    }
}
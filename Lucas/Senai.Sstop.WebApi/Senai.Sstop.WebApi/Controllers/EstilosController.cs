using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Sstop.WebApi.Domains;
using Senai.Sstop.WebApi.Repositories;

namespace Senai.Sstop.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class EstilosController : ControllerBase
    {
        //List<EstiloDomain> estilos = new List<EstiloDomain>()
        //{
        //    new EstiloDomain { IdEstilo = 1, Nome = "Rock"}
        //    ,new EstiloDomain {  IdEstilo = 2, Nome = "Pagode"}
        //};

        

        EstiloRepository EstiloRepository = new EstiloRepository();

        [HttpGet]
        public IEnumerable<EstiloDomain> Listar()
        {
            return EstiloRepository.Listar();
            //return estilos;
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            //EstiloDomain Estilo = estilos.Find(x => x.IdEstilo == id);

            var Estilo = EstiloRepository.BuscarPorId(id);
            if (Estilo == null)
            {
                return NotFound();
            }
            return Ok(Estilo);
        }


        [HttpPost]
        public IActionResult Cadastrar(EstiloDomain estiloDomain)
        {
            EstiloRepository.Cadastrar(estiloDomain);
            return Ok();
        }

        [HttpPut]
        public IActionResult Atualizar(EstiloDomain estiloDomain)
        {
            EstiloRepository.Alterar(estiloDomain);
            return Ok();
        }
        
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            EstiloRepository.Deletar(id);
            return Ok();
        }


        //GET Busca uma lista
        //POST Manda um modelo
            
        //[HttpGet]
        //public string Get()
        //{
        //    return "Requisição recebida";
        //}
    }
}
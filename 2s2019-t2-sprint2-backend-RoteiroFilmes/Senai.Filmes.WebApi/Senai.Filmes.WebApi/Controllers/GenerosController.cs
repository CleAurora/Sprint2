using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Senai.Filmes.WebApi.Domains;
using Senai.Filmes.WebApi.Repositories;

namespace Senai.Filmes.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]

    public class GenerosController : Controller
    {
        GeneroRepository GeneroRepository = new GeneroRepository();

        //Atualizar
        [HttpPut]
        public IActionResult Atualizar(GeneroDomain generoDomain)
        {
            GeneroRepository.Alterar(generoDomain);
            return Ok();
        }// fim atualizar

        //BuscarPorId
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            var genero = GeneroRepository.BuscarPorId(id);
            if (genero == null)
            {
                return NotFound();
            }
            return Ok(genero);
        }// fim buscar por id

        //Cadastrar
        [HttpPost]
        public IActionResult Cadastrar(GeneroDomain generoDomain)
        {
            GeneroRepository.Cadastrar(generoDomain);
            return Ok();
        }//fim cadastrar

        //Deletar
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            GeneroRepository.Deletar(id);
            return Ok();
        }//fim deletar

        //Listar
        [HttpGet]
        public IEnumerable<GeneroDomain> Listar()
        {
            return GeneroRepository.Listar();
            //return estilos;
        }// fim listar

    }
}
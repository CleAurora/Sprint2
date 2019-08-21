using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Senai.Filmes.WebApi.Domains;
using Senai.Filmes.WebApi.Repositories;

namespace Senai.Filmes.WebApi.Controllers
{   [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class FilmesController : ControllerBase
    {
        List<FilmeDomain> estilos = new List<FilmeDomain>()
        {
            new FilmeDomain { IdFilme = 1, Titulo = "O Rei Leao" }
            ,new FilmeDomain { IdFilme = 2, Titulo = "Cinderela" }
        };

        FilmeRepository FilmeRepository = new FilmeRepository();

        [HttpGet]
        public IEnumerable<FilmeDomain> Listar()
        {
            return FilmeRepository.Listar();
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {

            FilmeDomain Filme = FilmeRepository.BuscarPorId(id);
            if (Filme == null)
            {
                return NotFound();
            }
            return Ok(Filme);
        }

        [HttpPost]
        public IActionResult Cadastrar(FilmeDomain filmeDomain)
        {
            //do bd
            FilmeRepository.Cadastrar(filmeDomain);
            return Ok();
        }

        //Atualizar
        [HttpPut]
        public IActionResult Atualizar(FilmeDomain filmeDomain)
        {
            FilmeRepository.Alterar(filmeDomain);
            return Ok();
        }

        //Deletar
        [HttpDelete("{ id}")]
        public IActionResult Deletar(int id)
        {
            FilmeRepository.Deletar(id);
            return Ok();
        }
    }
}
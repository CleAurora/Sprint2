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
        FilmeRepository FilmeRepository = new FilmeRepository();


        //BuscarPorId
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            var filme = FilmeRepository.BuscarPorId(id);
            if (filme == null)
            {
                return NotFound();
            }
            return Ok(filme);
        }// fim buscar por id

        //Cadastrar
        [HttpPost]
        public IActionResult Cadastrar(FilmeDomain filme)
        {
            try
            {
                //tenta fazer isso: 
                FilmeRepository.Cadastrar(filme);
                return Ok();
            }
            catch (Exception ex)
            {
                //nao foi realizada com sucesso
                return BadRequest(new { mensagem = "Vixi! Desculpa aí mas... rolou um erro:" + ex.Message });
            }
        }

        //Listar
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(FilmeRepository.Listar());
        }//Fim Listar
    }
}
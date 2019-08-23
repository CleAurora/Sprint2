using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Senai.BookStore.WebApi.Domains;
using Senai.BookStore.WebApi.Repositories;

namespace Senai.BookStore.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class LivrosController : Controller
    {
        LivroRepository livroRepository = new LivroRepository();


        /// <summary>
        /// Controle que chama o método Atualizar
        /// </summary>
        /// <param name="livroDomain"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Atualizar(LivroDomain livroDomain)
        {
            livroRepository.Alterar(livroDomain);
            return Ok();
        }// fim atualizar



        /// <summary>
        /// Controle que chama o método Buscar por id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>livro</returns>
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            var livro = livroRepository.BuscarPorId(id);
            if (livro == null)
            {
                return NotFound();
            }
            return Ok(livro);
        }// fim buscar por id

        //Cadastrar
        [HttpPost]
        public IActionResult Cadastrar(LivroDomain livroDomain)
        {
            livroRepository.Cadastrar(livroDomain);
            return Ok();
        }//fim cadastrar

        //Deletar
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            livroRepository.Deletar(id);
            return Ok();
        }//fim deletar


        /// <summary>
        /// Controle que chama o método Listar
        /// </summary>
        /// <returns>Lista de Livros</returns>
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(livroRepository.Listar());
        }//Fim Listar


    }
}
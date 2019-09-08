using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Senai.BookStore.WebApi.Domains;
using Senai.BookStore.WebApi.Repositories;

namespace Senai.BookStore.WebApi.Controllers
{
    public class GenerosController : Controller
    {
        GeneroRepository generoRepository = new GeneroRepository();

        
        /// <summary>
        /// Controle que chama o método Cadastrar
        /// </summary>
        /// <param name="generoDomain"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Cadastrar(GeneroDomain generoDomain)
        {
            generoRepository.Cadastrar(generoDomain);
            return Ok();
        }//fim cadastrar


        /// <summary>
        /// Controle que chama o método Listar
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<GeneroDomain> Listar()
        {
            return generoRepository.Listar();
            //return estilos;
        }// fim listar
    }
}
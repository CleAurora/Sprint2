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
    public class AutoresController : Controller
    {
        AutorRepository autorRepository = new AutorRepository;

        /// <summary>
        /// Controle que chama o método Listar Autores
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<AutorDomain> Listar()
        {
            return autorRepository.Listar();
            //return estilos;
        }// fim listar
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Senai.Sstop.WebApi.Repositories;

namespace Senai.Sstop.WebApi.Controllers
{
    public class ArtistasController : Controller
    {
        // instanciar repositório
        ArtistaRepository ArtistaRepository = new ArtistaRepository();

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(ArtistaRepository.Listar());
        }

        try
        {
            ArtistaRepository.Cadastrar(artista);
            return Ok();
    }
        catch(Exception ex)
        {
            return BadRequest(New})
        }

        


    }
}
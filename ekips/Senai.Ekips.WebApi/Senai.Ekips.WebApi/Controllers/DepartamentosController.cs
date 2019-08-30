using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Senai.Ekips.WebApi.Domains;
using Senai.Ekips.WebApi.Repositories;

namespace Senai.Ekips.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class DepartamentosController : Controller
    {
              DepartamentoRepository departamentoRepository = new DepartamentoRepository();

        /// <summary>
        /// Lista Departamentos já cadastrados
        /// </summary>
        /// <returns>Lista de Departamentos</returns>
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(departamentoRepository.Listar());
        }

        /// <summary>
        /// Cadastra novo Departamento
        /// </summary>
        /// <param name="departamento"></param>
        [HttpPost]
        public IActionResult Cadastrar(Departamentos departamento)
        {
            try
            {
                departamentoRepository.Cadastrar(departamento);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(new { mensagem = "Oops! Tem coisa errada na parada" + ex.Message });
            }
        }

        /// <summary>
        /// Busca Departamento por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Departamento Selecionado</returns>
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            Departamentos departamento = departamentoRepository.BuscarPorId(id);
            if (departamento == null)
                return NotFound();
            return Ok(departamento);
        }


    }
}
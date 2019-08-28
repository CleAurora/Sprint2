using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Senai.Ekips.WebApi.Domains;
using Senai.Ekips.WebApi.Repositories;

namespace Senai.Ekips.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class CargosController : ControllerBase
    {
        CargoRepository CargoRepository = new CargoRepository();

        /// <summary>
        /// Lista os cargos
        /// </summary>
        /// <returns>Lista de Cargos</returns>
        //[Authorize]
        [HttpGet]
        public IActionResult ListarTodos()
        {
            return Ok(CargoRepository.Listar());
        }

        /// <summary>
        /// Cadastra novo Cargo
        /// </summary>
        /// <param name="cargo"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Cadastrar (Cargos cargo)
        {
            try
            {
                CargoRepository.Cadastrar(cargo);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Oops... Não deu certo..." + ex.Message });
            }
        }

        /// <summary>
        /// Busca Cargo por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Cargo buscado</returns>
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            Cargos cargo = CargoRepository.BuscarPorId(id);
            if (cargo == null)
                return NotFound();
            return Ok(cargo);
        }

        /// <summary>
        /// Atualiza o cargo
        /// </summary>
        /// <param name="cargo"></param>
        /// <returns>Cargo atualizado</returns>
        [HttpPut]
        public IActionResult Atualizar(Cargos cargo)
        {
            try
            {
                Cargos CargoBuscado = CargoRepository.BuscarPorId(cargo.IdCargo);

                if (CargoBuscado == null)
                    return NotFound();

                CargoRepository.Atualizar(cargo);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

    }
}
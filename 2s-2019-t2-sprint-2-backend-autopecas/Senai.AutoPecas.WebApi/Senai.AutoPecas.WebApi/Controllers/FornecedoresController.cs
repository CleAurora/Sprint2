using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.AutoPecas.WebApi.Domains;
using Senai.AutoPecas.WebApi.Interfaces;
using Senai.AutoPecas.WebApi.Repositories;

namespace Senai.AutoPecas.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class FornecedoresController : ControllerBase
    {
        private IFornecedorRepository FornecedorRepository { get; set; }

        public FornecedoresController()
        {
            FornecedorRepository = new FornecedorRepository();
        }

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(FornecedorRepository.Listar());
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            try
            {
                Fornecedores fornecedor = FornecedorRepository.BuscarPorId(id);
                if (fornecedor == null)
                    return NotFound();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }

        [HttpPost]
        public IActionResult Cadastrar(Fornecedores fornecedor)
        {
            try
            {
                int UsuarioId = Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Jti).Value);
                fornecedor.UsuarioId = UsuarioId;
                FornecedorRepository.Cadastrar(fornecedor);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }

        [HttpPut]
        public IActionResult Atualizar(Fornecedores fornecedor)
        {
            try
            {
                Fornecedores FornecedorBuscado = FornecedorRepository.BuscarPorId(fornecedor.FornecedorId);
                if (FornecedorBuscado == null)
                    return NotFound();

                FornecedorRepository.Atualizar(fornecedor);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            FornecedorRepository.Deletar(id);
            return Ok();
        }


    }
}
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
        private IUsuarioRepository UsuarioRepository { get; set; }

        public FornecedoresController()
        {
            FornecedorRepository = new FornecedorRepository();
            UsuarioRepository = new UsuarioRepository();
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
                return Ok(fornecedor);
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
                var usuarioId = UsuarioRepository.Cadastrar(fornecedor.Usuario);
                fornecedor.Usuario = null;
                fornecedor.UsuarioId = usuarioId;
                FornecedorRepository.Cadastrar(fornecedor);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Fornecedores fornecedor)
        {
            try
            {
                Fornecedores FornecedorBuscado = FornecedorRepository.BuscarPorId(id);
                if (FornecedorBuscado == null)
                    return NotFound();

                fornecedor.FornecedorId = FornecedorBuscado.FornecedorId;
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
            try
            {
                FornecedorRepository.Deletar(id);
                return NoContent();
            }
            catch(Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }


    }
}
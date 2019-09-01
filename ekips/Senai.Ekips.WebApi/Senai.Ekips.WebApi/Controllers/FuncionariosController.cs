using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Senai.Ekips.WebApi.Domains;
using Senai.Ekips.WebApi.Repositories;
using Senai.Ekips.WebApi.ViewModels;

namespace Senai.Ekips.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class FuncionariosController : ControllerBase
    {
        private readonly FuncionarioRepository FuncionarioRepository = new FuncionarioRepository();
        private readonly UsuarioRepository UsuarioRepository = new UsuarioRepository();

        /// <summary>
        /// Lista os funcionários
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        public IActionResult ListarTodos()
        {
            if (IsAdministrator())
            {
                return Ok(FuncionarioRepository.Listar());
            }

            return Ok(new List<Funcionarios> { GetFuncionario() });
        }

        private bool IsAdministrator()
        {
            return User.HasClaim(claim => claim.Type == ClaimTypes.Role && claim.Value == "ADMINISTRADOR");
        }

        private Funcionarios GetFuncionario()
        {
            var usuarioId = User.Claims.FirstOrDefault(claim => claim.Type == JwtRegisteredClaimNames.Jti);
            var usuarioIdAsInt = int.Parse(usuarioId.Value);

            return FuncionarioRepository.BuscarPorUsuarioId(usuarioIdAsInt);
        }

        [HttpPost]
        [Authorize(Roles = "ADMINISTRADOR")]
        public IActionResult Cadastrar(FuncionarioViewModel viewModel)
        {
            try
            {
                var usuario = new Usuarios
                {
                    Email = viewModel.Usuario.Email,
                    Senha = viewModel.Usuario.Senha,
                    Permissao = viewModel.Usuario.Permissao
                };

                var usuarioId = UsuarioRepository.Cadastrar(usuario);

                var funcionario = new Funcionarios
                {
                    Nome = viewModel.Nome,
                    Cpf = viewModel.Cpf,
                    DataNascimento = viewModel.DataNascimento,
                    Salario = viewModel.Salario,
                    IdDepartamento = viewModel.IdDepartamento,
                    IdCargo = viewModel.IdCargo,
                    IdUsuario = usuarioId
                };

                FuncionarioRepository.Cadastrar(funcionario);

                return Ok();
            } catch (Exception exception)
            {
                return BadRequest(new
                {
                    message = "Oops... Não deu certo...",
                    details = exception.Message
                });
            }
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "ADMINISTRADOR")]
        public IActionResult Atualizar (int id, FuncionarioViewModel viewModel)
        {
            try
            {
                var funcionarioAtual = FuncionarioRepository.BuscarPorId(id);
                funcionarioAtual.Nome = viewModel.Nome;
                funcionarioAtual.Cpf = viewModel.Cpf;
                funcionarioAtual.DataNascimento = viewModel.DataNascimento;
                funcionarioAtual.Salario = viewModel.Salario;
                funcionarioAtual.IdDepartamento = viewModel.IdDepartamento;
                funcionarioAtual.IdCargo = viewModel.IdCargo;

                FuncionarioRepository.Atualizar(funcionarioAtual);

                if (funcionarioAtual.IdUsuario != null)
                {
                    var usuario = UsuarioRepository.BuscarPorId((int)funcionarioAtual.IdUsuario);

                    usuario.Email = viewModel.Usuario.Email;
                    usuario.Senha = viewModel.Usuario.Senha;
                    usuario.Permissao = viewModel.Usuario.Permissao;

                    UsuarioRepository.Atualizar(usuario);
                }

                return Ok();
            } catch (Exception exception)
            {
                return BadRequest(new
                {
                    message = "Oops... Não deu certo...",
                    details = exception.Message
                });
            }

        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "ADMINISTRADOR")]
        public IActionResult Deletar (int id)
        {
            try
            {
                FuncionarioRepository.Deletar(id);

                return NoContent();
            }
            catch (Exception exception)
            {
                return BadRequest(new
                {
                    message = "Oops... Não deu certo...",
                    details = exception.Message
                });
            }
        }
    }
}
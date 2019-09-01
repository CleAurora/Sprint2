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

            return Ok(new List<Funcionarios> { GetFuncionario()});
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
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Senai.Peoples.WebApi.Domains;
using Senai.Peoples.WebApi.Repositories;

namespace Senai.Peoples.WebApi.Controllers
{
    [Route("api/funcionarios")]
    [Produces("application/json")]
    [ApiController]

    public class FuncionariosController : Controller
    {
        //necessário instanciar
        FuncionarioRepository funcionarioRepository = new FuncionarioRepository();

        //Listar
        [HttpGet]
        public IEnumerable<FuncionarioDomain> Listar()
        {
            //return estilos;
            return funcionarioRepository.Listar();
        }//fim Listar

        //Buscar po id
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            FuncionarioDomain funcionario = funcionarioRepository.BuscarPorId(id);
            if(funcionario == null)
            {
                return NotFound();
            }
            return Ok(funcionario);
        }// fim Buscar Por Id

        //Deletar
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            funcionarioRepository.Deletar(id);
            return Ok();
        }//fim Deletar

        //Atualizar
        [HttpPut("{id}")]
        public IActionResult Atualizar(FuncionarioDomain funcionario)
        {
            funcionarioRepository.Alterar(funcionario);
            return Ok();
        }//Fim Atualizar

        //Inserir
        [HttpPost]
        public IActionResult Cadastrar(FuncionarioDomain funcionario)
        {
            funcionarioRepository.Cadastrar(funcionario);
            return Ok();
        }// Fim Inserir


        //Buscar por Nome
        [HttpGet("buscarpor/{nome}")]
        public IActionResult BuscarPorNome(string nome)
        {
            FuncionarioDomain funcionario = funcionarioRepository.BuscarPorNome(nome);
            if (funcionario == null)
            {
                return NotFound();
            }
            return Ok(funcionario);
        }// fim Buscar Por Nome

    }
}
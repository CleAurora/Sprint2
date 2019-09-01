using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Ekips.WebApi.ViewModels
{
    public class FuncionarioViewModel
    {
        [Required]
        public string Nome { get; set; }
        public int Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public float Salario { get; set; }
        public int IdDepartamento { get; set; } 
        public int IdCargo { get; set; }
        public UsuarioViewModel Usuario { get; set; }
    }

    public class UsuarioViewModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Senha { get; set; }
        [Required]
        public string Permissao { get; set; }
    }
}

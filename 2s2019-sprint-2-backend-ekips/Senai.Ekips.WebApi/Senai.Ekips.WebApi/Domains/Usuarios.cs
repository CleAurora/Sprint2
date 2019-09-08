using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Senai.Ekips.WebApi.Domains
{
    public partial class Usuarios
    {
        public Usuarios()
        {
            Funcionarios = new HashSet<Funcionarios>();
        }

        public int IdUsuario { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        [Required(ErrorMessage = "Então! A permissão é obrigatória. Coloca aí vai!")]
        public string Permissao { get; set; }

        public ICollection<Funcionarios> Funcionarios { get; set; }
    }
}

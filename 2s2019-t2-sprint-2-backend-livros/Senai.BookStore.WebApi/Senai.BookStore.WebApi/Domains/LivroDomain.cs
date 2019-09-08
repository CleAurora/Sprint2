using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.BookStore.WebApi.Domains
{
    public class LivroDomain
    {
        public int IdLivro { get; set; }
        public string Descricao { get; set; }
        public int AutorId { get; set; }
        public AutorDomain Autor { get; set; }
        public int GeneroId { get; set; }
        public GeneroDomain Genero { get; set; }
    }
}

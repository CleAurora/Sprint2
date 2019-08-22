using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Sstop.WebApi.Domains
{
    public class ArtistaDomain
    {
        public int IdArtista { get; set; }
        public string Nome { get; set; }
        //esse debaixo so pra cadastrar, pq n precisa do objeto inteiro pra cadastrar, só o id
        public int EstiloId { get; set; }
        public EstiloDomain Estilo { get; set; }
    }
}

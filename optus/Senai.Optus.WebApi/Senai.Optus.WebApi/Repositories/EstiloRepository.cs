using Senai.Optus.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Optus.WebApi.Repositories
{
    public class EstiloRepository
    {
        //Estilos - GET, POST, PUT, DELETE

        /// <summary>
        /// Listar Estilos
        /// </summary>
        /// <returns>Lista de Estilos</returns>
        public List<Estilos> Listar()
        {
            using (OptusContext ctx = new OptusContext())
            {
                return ctx.Estilos.ToList();
            }
        }

        /// <summary>
        /// Cadastrar Estilo
        /// </summary>
        /// <param name="estilo"></param>
        public void Cadastrar (Estilos estilo)
        {
            using (OptusContext ctx = new OptusContext())
            {
                ctx.Estilos.Add(estilo);
                ctx.SaveChanges();
            }
        }

        /// <summary>
        /// Busca Estilo pelo Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>estilo</returns>
        public Estilos BuscarPorId(int id)
        {
            using (OptusContext ctx = new OptusContext())
            {
                return ctx.Estilos.FirstOrDefault(x => x.IdEstilo == id);
            }
        }

        /// <summary>
        /// Atualiza Estilo
        /// </summary>
        /// <param name="estilo"></param>
        public void Atualizar(Estilos estilo)
        {
            using (OptusContext ctx = new OptusContext())
            {
                Estilos EstiloBuscado = ctx.Estilos.FirstOrDefault(x => x.IdEstilo == estilo.IdEstilo);

                EstiloBuscado.Nome = estilo.Nome;

                ctx.Estilos.Update(EstiloBuscado);

                ctx.SaveChanges();
            }
        }

        /// <summary>
        /// Deleta o estilo solicitado pelo Id
        /// </summary>
        /// <param name="id"></param>
        public void Deletar(int id)
        {
            using (OptusContext ctx = new OptusContext())
            {
                Estilos EstiloBuscado = ctx.Estilos.Find(id);
                ctx.Estilos.Remove(EstiloBuscado);
                ctx.SaveChanges();
            }
        }
    }
}

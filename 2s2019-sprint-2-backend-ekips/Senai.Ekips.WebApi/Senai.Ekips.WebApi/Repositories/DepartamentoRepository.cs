using Senai.Ekips.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Ekips.WebApi.Repositories
{
    public class DepartamentoRepository
    {
        //get, get e post

        /// <summary>
        /// Lista Departamentos
        /// </summary>
        /// <returns>Lista de Departamentos</returns>
        public List<Departamentos> Listar()
        {
            using (EkipsContext ctx = new EkipsContext())
            {
                return ctx.Departamentos.ToList();
            }
        }

        /// <summary>
        /// Cadastra novo Departamento
        /// </summary>
        /// <param name="departamento"></param>
        public void Cadastrar(Departamentos departamento)
        {
            using (EkipsContext ctx = new EkipsContext())
            {
                ctx.Departamentos.Add(departamento);
                ctx.SaveChanges();
            }
        }

        /// <summary>
        /// Busca o departamento por Id
        /// </summary>
        /// <param name="id">IdDepartamento</param>
        /// <returns>Departamento</returns>
        public Departamentos BuscarPorId(int id)
        {
            using (EkipsContext ctx = new EkipsContext())
            {
                return ctx.Departamentos.FirstOrDefault(x => x.IdDepartamento == id);
            }
        }


    }
}

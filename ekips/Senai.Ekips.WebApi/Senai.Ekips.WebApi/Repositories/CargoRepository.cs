using Senai.Ekips.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Ekips.WebApi.Repositories
{
    public class CargoRepository
    {
        /// <summary>
        /// Listar Cargos
        /// </summary>
        /// <returns>Lista de Cargos</returns>
        public List<Cargos> Listar()
        {
            using (EkipsContext ctx = new EkipsContext())
            {
                return ctx.Cargos.ToList();
            }
        }

        /// <summary>
        /// Cadastra Cargo
        /// </summary>
        /// <param name="cargo"></param>
        public void Cadastrar(Cargos cargo)
        {
            using (EkipsContext ctx = new EkipsContext())
            {
                ctx.Cargos.Add(cargo);
                ctx.SaveChanges();
            } 
        }

        /// <summary>
        /// Buscar por Id
        /// </summary>
        /// <param name="cargo"></param>
        public Cargos BuscarPorId(int id)
        {
            using (EkipsContext ctx = new EkipsContext())
            {
                return ctx.Cargos.FirstOrDefault(x => x.IdCargo == id);
            }
        }

        /// <summary>
        /// Atualiza
        /// </summary>
        /// <param name="cargo"></param>
        public void Atualizar(Cargos cargo)
        {
            using (EkipsContext ctx = new EkipsContext())
            {
                Cargos CargoBuscado = ctx.Cargos.FirstOrDefault(x => x.IdCargo == cargo.IdCargo);
                CargoBuscado.Nome = cargo.Nome;
                ctx.Cargos.Update(CargoBuscado);
                ctx.SaveChanges();
            }
        }

    }
}

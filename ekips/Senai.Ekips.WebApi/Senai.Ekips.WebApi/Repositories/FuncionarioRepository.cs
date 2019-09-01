using Microsoft.EntityFrameworkCore;
using Senai.Ekips.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Ekips.WebApi.Repositories
{
    public class FuncionarioRepository
    {
        // PUT /api/funcionarios/{id} 

        public List<Funcionarios> Listar()
        {
            using (EkipsContext ctx = new EkipsContext())
            {
                return ctx.Funcionarios.Include(x => x.IdCargoNavigation).Include(x => x.IdDepartamentoNavigation).ToList();
            }
        }

        public Funcionarios BuscarPorId(int id)
        {
            using (EkipsContext ctx = new EkipsContext())
            {
                return ctx.Funcionarios.FirstOrDefault(x => x.IdFuncionario == id);
            }
        }

        public Funcionarios BuscarPorUsuarioId(int usuarioId)
        {
            using (EkipsContext ctx = new EkipsContext())
            {
                return ctx.Funcionarios.FirstOrDefault(x => x.IdUsuario == usuarioId);
            }
             
        }

        public void Cadastrar(Funcionarios funcionario)
        {
            using (EkipsContext ctx = new EkipsContext())
            {
                ctx.Funcionarios.Add(funcionario);
                ctx.SaveChanges();
            }
        }

        public void Atualizar (Funcionarios funcionario)
        {
            using (EkipsContext ctx = new EkipsContext())
            {
                Funcionarios FuncionarioBuscado = ctx.Funcionarios.FirstOrDefault(x => x.IdFuncionario == funcionario.IdFuncionario);
                FuncionarioBuscado.Nome = funcionario.Nome;
                ctx.Funcionarios.Update(FuncionarioBuscado);
                ctx.SaveChanges();
            }
        }

        public void Deletar(int id)
        {
            using (EkipsContext ctx = new EkipsContext())
            {
                Funcionarios FuncionarioBuscado = ctx.Funcionarios.Find(id);
                ctx.Funcionarios.Remove(FuncionarioBuscado);
                ctx.SaveChanges();
            }
        }


    }
}

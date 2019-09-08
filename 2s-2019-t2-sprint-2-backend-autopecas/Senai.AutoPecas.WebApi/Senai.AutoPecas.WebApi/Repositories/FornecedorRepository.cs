using Senai.AutoPecas.WebApi.Domains;
using Senai.AutoPecas.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.AutoPecas.WebApi.Repositories
{
    public class FornecedorRepository: IFornecedorRepository
    {
        /// <summary>
        /// Busca Fornecedor por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Fornecedor</returns>
        public Fornecedores BuscarPorId(int id)
        {
            using (AutoPecasContext ctx = new AutoPecasContext())
            {
                return ctx.Fornecedores.Find(id);
            }
        }

        /// <summary>
        /// Cadastra novo Fornecedor
        /// </summary>
        /// <param name="fornecedor"></param>
        public void Cadastrar(Fornecedores fornecedor)
        {
            using (AutoPecasContext ctx = new AutoPecasContext())
            {
                ctx.Fornecedores.Add(fornecedor);
                ctx.SaveChanges();
            }
        }

        /// <summary>
        /// Lista Fornecedores
        /// </summary>
        /// <returns>Lista de Fornecedores</returns>
        public List<Fornecedores> Listar()
        {
            using (AutoPecasContext ctx = new AutoPecasContext())
            {
                return ctx.Fornecedores.ToList();
            }
        }

        /// <summary>
        /// Atualiza Fornecedor
        /// </summary>
        /// <param name="fornecedor"></param>
        public void Atualizar(Fornecedores fornecedor)
        {
            using (AutoPecasContext ctx = new AutoPecasContext())
            {
                Fornecedores FornecedorBuscado = ctx.Fornecedores.FirstOrDefault(x => x.FornecedorId == fornecedor.FornecedorId);
                FornecedorBuscado.Cnpj = fornecedor.Cnpj;
                FornecedorBuscado.RazaoSocial = fornecedor.RazaoSocial;
                FornecedorBuscado.NomeFantasia = fornecedor.NomeFantasia;
                FornecedorBuscado.Endereco = fornecedor.Endereco;
                FornecedorBuscado.UsuarioId = fornecedor.UsuarioId;

                ctx.Fornecedores.Update(FornecedorBuscado);
                ctx.SaveChanges();
            }
        }

        /// <summary>
        /// Deleta o fornecedor buscado
        /// </summary>
        /// <param name="id"></param>
        public void Deletar(int id)
        {
            using (AutoPecasContext ctx = new AutoPecasContext())
            {
                Fornecedores FornecedorBuscado = ctx.Fornecedores.Find(id);
                ctx.Fornecedores.Remove(FornecedorBuscado);
                ctx.SaveChanges();
            }
        }

        
    }
}

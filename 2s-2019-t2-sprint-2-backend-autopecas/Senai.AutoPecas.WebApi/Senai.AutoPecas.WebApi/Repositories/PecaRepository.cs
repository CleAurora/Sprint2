using Senai.AutoPecas.WebApi.Domains;
using Senai.AutoPecas.WebApi.Interfaces;
using Senai.AutoPecas.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.AutoPecas.WebApi.Repositories
{
    public class PecaRepository: IPecaRepository
    {
        /// <summary>
        /// Lista Pecas
        /// </summary>
        /// <param name="FornecedorId"></param>
        /// <returns>Lista de Pecas</returns>
        public List<Pecas> Listar(int FornecedorId)
        {
            using (AutoPecasContext ctx = new AutoPecasContext())
            {
                return ctx.Pecas.Where(x => x.Fornecedor.FornecedorId == FornecedorId).ToList();
            }
        }

        /// <summary>
        /// Buscar Peça
        /// </summary>
        /// <param name="PecaId"></param>
        /// <param name="FornecedorId"></param>
        /// <returns>Peça</returns>
        public Pecas BuscarPorId(int PecaId, int FornecedorId)
        {
            using (AutoPecasContext ctx = new AutoPecasContext())
            {
                return ctx.Pecas.FirstOrDefault(x => x.Fornecedor.FornecedorId == FornecedorId && x.PecaId == PecaId);
            }
        }

        /// <summary>
        /// Cadastra nova peça
        /// </summary>
        /// <param name="peca"></param>
        public void Cadastrar(Pecas peca)
        {
            using (AutoPecasContext ctx = new AutoPecasContext())
            {
                ctx.Pecas.Add(peca);
                ctx.SaveChanges();
            }
        }

        /// <summary>
        /// Atualiza peca
        /// </summary>
        /// <param name="peca"></param>
        public void Atualizar(Pecas peca)
        {
            using (AutoPecasContext ctx = new AutoPecasContext())
            {
                Pecas PecaBuscada = ctx.Pecas.FirstOrDefault(x => x.PecaId == peca.PecaId);
                PecaBuscada.Codigo = peca.Codigo;
                PecaBuscada.Descricao = peca.Descricao;
                PecaBuscada.Peso = peca.Peso;
                PecaBuscada.PrecoCusto = peca.PrecoCusto;
                PecaBuscada.PrecoVenda = peca.PrecoVenda;
                ctx.Pecas.Update(PecaBuscada);
                ctx.SaveChanges();
            }
        }

        /// <summary>
        /// Deleta Peca
        /// </summary>
        /// <param name="id"></param>
        public void Deletar(int id)
        {
            using (AutoPecasContext ctx = new AutoPecasContext())
            {
                ctx.Pecas.Remove(ctx.Pecas.FirstOrDefault(x => x.PecaId == id));
                ctx.SaveChanges();
            }
        }

        /// <summary>
        /// Lista preço das peças
        /// </summary>
        /// <param name="FornecedorId"></param>
        /// <returns>Preço</returns>
        public IEnumerable<PecasPrecosViewModel> ListarPrecos(int FornecedorId)
        {
            using (AutoPecasContext ctx = new AutoPecasContext())
            {
                var resultado = from c in ctx.Pecas.Where(x => x.Fornecedor.FornecedorId == FornecedorId).ToList()
                                select new PecasPrecosViewModel { PecaId = c.PecaId, Codigo = c.Codigo, Descricao = c.Descricao, Peso = c.Peso, PrecoCusto = c.PrecoCusto, PrecoVenda = c.PrecoVenda, PrecoGanho = c.PrecoVenda - c.PrecoCusto, Porcentagem = ((c.PrecoVenda - c.PrecoCusto) * 100)/c.PrecoCusto };
                // List<PecasPrecosViewModel> Pecas = ctx.Pecas.Where(x => x.Fornecedor.FornecedorId == FornecedorId).ToList();
                return resultado;
            }
        }

        public List<Pecas> Listar()
        {
            throw new NotImplementedException();
        }

        public Pecas BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Atualizar(int id)
        {
            throw new NotImplementedException();
        }
    }
}

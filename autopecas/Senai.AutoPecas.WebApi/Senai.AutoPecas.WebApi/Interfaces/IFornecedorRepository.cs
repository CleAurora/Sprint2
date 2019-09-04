using Senai.AutoPecas.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.AutoPecas.WebApi.Interfaces
{
    interface IFornecedorRepository
    {
        List<Fornecedores> Listar();

        void Cadastrar(Fornecedores fornecedor);

        Fornecedores BuscarPorId(int id);

        void Atualizar(int id);

        void Deletar(int id);
    }
}

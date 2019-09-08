using Senai.AutoPecas.WebApi.Domains;
using Senai.AutoPecas.WebApi.ViewModels;

namespace Senai.AutoPecas.WebApi.Interfaces
{
    interface IUsuarioRepository
    {
        Usuarios BuscarPorEmailESenha(LoginViewModel login);
        int Cadastrar(Usuarios usuario);
    }
}

using Microsoft.EntityFrameworkCore;
using Senai.AutoPecas.WebApi.Domains;
using Senai.AutoPecas.WebApi.Interfaces;
using Senai.AutoPecas.WebApi.ViewModels;
using System.Linq;

namespace Senai.AutoPecas.WebApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {

        public Usuarios BuscarPorEmailESenha(LoginViewModel login)
        {
            using (AutoPecasContext ctx = new AutoPecasContext())
            {
                // buscar os dados no banco e verificar se este email e senha sao validos
                Usuarios UsuarioBuscado = ctx.Usuarios.Include(x => x.Fornecedores).FirstOrDefault(x => x.Email == login.Email && x.Senha == login.Senha);
                if (UsuarioBuscado == null)
                {
                    return null;
                }
                return UsuarioBuscado;
            }
        }
        public int Cadastrar(Usuarios usuario)
        {
            using (AutoPecasContext ctx = new AutoPecasContext())
            {
                ctx.Usuarios.Add(usuario);
                ctx.SaveChanges();

                return usuario.UsuarioId;
            }
        }
    }

}
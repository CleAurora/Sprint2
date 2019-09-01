using Senai.Ekips.WebApi.Domains;
using Senai.Ekips.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Ekips.WebApi.Repositories
{
    public class UsuarioRepository
    {
        /// <summary>
        /// Buscar por e-mail e senha o usuário para fins de login
        /// </summary>
        /// <param name="login"></param>
        /// <returns>Usuário Buscado</returns>
        public Usuarios BuscarPorEmailESenha(LoginViewModel login)
        {
            using (EkipsContext ctx = new EkipsContext())
            {
                Usuarios UsuarioBuscado = ctx.Usuarios.FirstOrDefault(x => x.Email == login.Email && x.Senha == login.Senha);
                if(UsuarioBuscado == null)
                {
                    return null;
                }
                return UsuarioBuscado;
            }
        }

        public int Cadastrar(Usuarios usuario)
        {
            using (EkipsContext ctx = new EkipsContext())
            {
                ctx.Usuarios.Add(usuario);
                return ctx.SaveChanges();
            }
        }

        public void Atualizar(Usuarios usuario)
        {
            using (EkipsContext ctx = new EkipsContext())
            {
                ctx.Usuarios.Update(usuario);
                ctx.SaveChanges();
            }
        } 

        public Usuarios BuscarPorId(int id)
        {
            using (EkipsContext ctx = new EkipsContext())
            {
                return ctx.Usuarios.FirstOrDefault(x => x.IdUsuario == id);
            }
        }
    }
}

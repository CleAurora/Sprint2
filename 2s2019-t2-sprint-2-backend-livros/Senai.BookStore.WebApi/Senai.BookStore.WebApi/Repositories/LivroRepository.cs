using Senai.BookStore.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.BookStore.WebApi.Repositories
{
    public class LivroRepository
    {
        /*-- livros
GET /api/livros
GET /api/livros/{id}
POST /api/livros
PUT /api/livros/{id}
DELETE /api/livros/{id}*/

     private string StringConexao = "Data Source =.\\SqlExpress; initial catalog=M_BookStore;User Id = sa;Pwd=132";


        /// <summary>
        /// Método para Atualizar
        /// </summary>
        /// <param name="livroDomain"></param>
        public void Alterar(LivroDomain livroDomain)
        {
            string Query = "UPDATE Livros SET Descricao = @Descricao, AutorId=@AutorId, GeneroId = @GeneroId WHERE IdLivro = @IdLivro";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@Descricao", livroDomain.Descricao);
                cmd.Parameters.AddWithValue("@IdLivro", livroDomain.IdLivro);
                cmd.Parameters.AddWithValue("@GeneroId", livroDomain.GeneroId);
                cmd.Parameters.AddWithValue("@AutorId", livroDomain.AutorId);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }//fim atualizar



        /// <summary>
        /// Método para buscar por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>livro</returns>
        public LivroDomain BuscarPorId(int id)
        {
            string Query = "select L.IdLivro, L.Descricao as DescricaoLivro, L.IdAutor, L.IdGenero, G.IdGenero, G.Descricao as DescricaoGenero, A.IdAutor, A.Nome, A.Email, A.Ativo, A.DataNascimento from Generos as G join Livros as L on L.IdGenero = G.IdGenero join Autores as A on L.IdAutor = A.IdAutor ";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();
                SqlDataReader sdr;
                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    cmd.Parameters.AddWithValue("IdLivro", id);
                    sdr = cmd.ExecuteReader();

                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            LivroDomain livro = new LivroDomain
                            {
                                IdLivro = Convert.ToInt32(sdr["IdLivro"]),
                                Descricao = sdr["DescricaoLivro"].ToString(),
                                Genero = new GeneroDomain
                                {
                                    IdGenero = Convert.ToInt32(sdr["IdGenero"]),
                                    Descricao = sdr["DescricaoGenero"].ToString()
                                },
                                Autor = new AutorDomain
                                {
                                    IdAutor = Convert.ToInt32(sdr["IdAutor"]),
                                    Nome = sdr["Nome"].ToString(),
                                    Email = sdr["Email"].ToString(),
                                    Ativo = Convert.ToBoolean(sdr["Ativo"]),
                                    DataNascimento = Convert.ToDateTime(sdr["DataNascimento"])
                                }
                            };
                            return livro;
                        }
                    }
                }
                return null;
            }
        }//fim buscar por id


        /// <summary>
        /// Cadastrar
        /// </summary>
        /// <param name="livro"></param>
        public void Cadastrar(LivroDomain livro)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();
                string Query = "insert into Livros (Descricao, IdAutor, IdGenero) VALUES (@Descricao, @IdAutor, @IdGenero)";

                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@Descricao", livro.Descricao);
                cmd.Parameters.AddWithValue("@IdAutor", livro.AutorId);
                cmd.Parameters.AddWithValue("@IdGenero", livro.GeneroId);

                cmd.ExecuteNonQuery();
            }
        }//fim Cadastrar


        /// <summary>
        /// Método para Deletar
        /// </summary>
        /// <param name="id"></param>
        public void Deletar(int id)
        {
            string Query = "DELETE FROM Livros WHERE IdLivro = @IdLivro";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@IdLivro", id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }// fim deletar

        /// <summary>
        /// Controle que chama o Listar Livros
        /// </summary>
        /// <returns>livros</returns>
        public List<LivroDomain> Listar()
        {
            List<LivroDomain> livros = new List<LivroDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string Query = "select L.IdLivro, L.Descricao as DescricaoLivro, L.IdAutor, L.IdGenero, G.IdGenero, G.Descricao as DescricaoGenero, A.IdAutor, A.Nome, A.Email, A.Ativo, A.DataNascimento from Generos as G join Livros as L on L.IdGenero = G.IdGenero join Autores as A on L.IdAutor = A.IdAutor ";
                con.Open();

                SqlDataReader sdr;

                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    sdr = cmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        var livro = new LivroDomain
                        {
                            IdLivro = Convert.ToInt32(sdr["IdLivro"]),
                            Descricao = sdr["DescricaoLivro"].ToString(),
                            Genero = new GeneroDomain
                            {
                                IdGenero = Convert.ToInt32(sdr["IdGenero"]),
                                Descricao = sdr["DescricaoGenero"].ToString()
                            },
                            Autor = new AutorDomain
                            {
                                IdAutor = Convert.ToInt32(sdr["IdAutor"]),
                                Nome = sdr["Nome"].ToString(),
                                Email = sdr["Email"].ToString(),
                                Ativo = Convert.ToBoolean(sdr["Ativo"]),
                                DataNascimento = Convert.ToDateTime(sdr["DataNascimento"])
                            }
                        };
                        livros.Add(livro);
                    }
                }
            }
            return livros;
        }//fim Listar

    }
}

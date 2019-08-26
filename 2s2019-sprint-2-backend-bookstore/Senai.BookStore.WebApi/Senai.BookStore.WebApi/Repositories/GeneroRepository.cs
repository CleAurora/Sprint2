using Senai.BookStore.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.BookStore.WebApi.Repositories
{
    /// <summary>
    /// Classe responsãvel para o repositõrio dos Gêneros de Livros
    /// </summary>
    public class GeneroRepository
    {
        /*--generos GET /api/generos POST /api/generos*/

        /// <summary>
        /// String que estabelece a conexão com o banco de dados
        /// </summary>
        private string StringConexao = "Data Source=.\\SqlExpress; initial catalog=M_BookStore; User Id=sa;Pwd=132";

        /// <summary>
        /// Método para Cadastrar novos gêneros
        /// </summary>
        /// <param name="genero"></param>
        public void Cadastrar(GeneroDomain genero)
        {
            string Query = "INSERT INTO Generos(Nome) VALUES(@Nome)";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                //o que quer fazer(query) na conexao(ta na stringconexao)
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@Nome", genero.Descricao);
                con.Open();

                cmd.ExecuteNonQuery();

            }
        }// fim Cadastrar


        /// <summary>
        /// Método para listar novos gêneros
        /// </summary>
        /// <returns></returns>
        //Listar
        public List<GeneroDomain> Listar()
        {
            List<GeneroDomain> generos = new List<GeneroDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string Query = "SELECT IdGenero, Nome FROM IdGeneros ORDER BY Genero ASC";

                con.Open();
                SqlDataReader rdr;
                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        GeneroDomain genero = new GeneroDomain
                        {
                            IdGenero = Convert.ToInt32(rdr["IdGeneroMusical"]),
                            Descricao = rdr["Descrição"].ToString()
                        };
                        generos.Add(genero);
                    }
                }
            }

            return generos;
        }//Fim Listar
    }
}
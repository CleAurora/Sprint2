using Senai.Filmes.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Filmes.WebApi.Repositories
{
    public class FilmeRepository
    {
        private string StringConexao = "Data Source=localhost; initial catalog=RoteiroFilmes; Integrated Security = true";

        public List<FilmeDomain> Listar()
        {
            List<FilmeDomain> filmes = new List<FilmeDomain>();

            //abrir uma conexao com o banco
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                //fazer a leitura de todos os registros
                //declarar a instrucao a ser realizada
                string Query = "select Filmes.*, Generos.* from Filmes join Generos on Filmes.IdGenero = Generos.IdGenero";

                // abre a conexao com o bd
                con.Open();
                //declaro para percorrer a lista
                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    //executa a query
                    rdr = cmd.ExecuteReader();

                    while(rdr.Read())
                    {
                        FilmeDomain filme = new FilmeDomain
                        {
                            IdFilme = Convert.ToInt32(rdr["IdFilme"]),
                            Titulo = rdr["Titulo"].ToString(),
                            IdGenero = Convert.ToInt32(rdr["IdGenero"])
                        };
                        filmes.Add(filme);
                    }
                }
            }

            //devolver a lista preenchida
            return filmes;

        }
    }
}

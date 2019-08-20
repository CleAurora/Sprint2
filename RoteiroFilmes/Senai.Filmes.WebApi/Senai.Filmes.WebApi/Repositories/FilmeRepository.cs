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
        //private string StringConexao = "Data Source=.\\SqlExpress; initial catalog=RoteiroFilmes; Integrated Security = true";
        private string StringConexao = "Data Source =.\\SqlExpress; initial catalog=RoteiroFilmes;User Id = sa;Pwd=132";


        //Método Listar:
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
        }//Fim método Listar

        //Método BuscarPorId
        public FilmeDomain BuscarPorId(int id)
        {
            string Query = "Select IdFilme, Titulo From Filmes where IdFilme = @Filme";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();
                SqlDataReader sdr;

                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    cmd.Parameters.AddWithValue("@Filme", id);
                    sdr = cmd.ExecuteReader();

                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            FilmeDomain filme = new FilmeDomain
                            {
                                IdFilme = Convert.ToInt32(sdr["IdFilme"]),
                                Titulo = sdr["Titulo"].ToString()
                            };
                            return filme;
                        }
                    }
                    return null;

                }
            }
        }//fim método BuscarPorId

        //Método Cadastrar
        public void Cadastrar(FilmeDomain filme)
        {
            string Query = "Insert into Filmes(Titulo) Values(@Titulo)";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                //declara o comando com a query e a conexão
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@Titulo", filme.Titulo);
                //abre a conexão
                con.Open();
                //executa o comando
                cmd.ExecuteNonQuery();
            }
        }// fim método cadastrar

        //Método Atualizar
        public void Alterar(FilmeDomain filmeDomain)
        {
            string Query = "Update Filmes SET Titulo = @Titulo where IdFilme = @IdFilme";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                //faço o comando
                SqlCommand cmd = new SqlCommand(Query, con);
                //defino os parâmetros
                cmd.Parameters.AddWithValue("@Titulo", filmeDomain.Titulo);
                cmd.Parameters.AddWithValue("@IdFilme", filmeDomain.IdFilme);
                //abrir a conexão
                con.Open();
                //executar
                cmd.ExecuteNonQuery();
            }
        }


    }
}

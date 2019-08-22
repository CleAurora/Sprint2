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

        //Atualizar


        //BuscarPorId
        //Cadastrar
        public void Cadastrar(FilmeDomain filme)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();
                string Query = "INSERT INTO Filmes (Titulo,IdGenero) VALUES (@Titulo,@IdGenero)";

                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@Titulo", filme.Titulo);
                cmd.Parameters.AddWithValue("@IdEstiloMusical", filme.GeneroId);

                cmd.ExecuteNonQuery();

            }
        }

        //Deletar

        //Listar
        
        private string StringConexao = "Data Source=.\\SqlExpress; initial catalog=RoteiroFilmes; User Id=sa;Pwd=132";

        public List<FilmeDomain> Listar()
        {
            List<FilmeDomain> filmes = new List<FilmeDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string Query = "select F.IdFilme, F.Titulo, F.IdGenero, G.IdGenero, G.Nome as NomeGenero from Filmes as F join Generos as G on F.IdGenero = G.IdGenero";
                con.Open();

                SqlDataReader sdr;

                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    sdr = cmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        var filme = new FilmeDomain
                        {
                            IdFilme = Convert.ToInt32(sdr["IdFilme"]),
                            Titulo = sdr["Titulo"].ToString(),
                            Genero = new GeneroDomain
                            {
                                IdGenero = Convert.ToInt32(sdr["IdGenero"]),
                                Nome = sdr["NomeGenero"].ToString()
                            }
                        };
                        filmes.Add(filme);
                    }
                }
            }
            return artistas;
        }//fim Listar

    }
}
using Senai.Filmes.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Filmes.WebApi.Repositories
{
    public class GeneroRepository
    {
        private string StringConexao = "Data Source=.\\SqlExpress; initial catalog=RoteiroFilmes; User Id=sa;Pwd=132";


        //Atualizar
        public void Alterar(GeneroDomain generoDomain)
        {
            string Query = "UPDATE Generos SET Nome = @Nome WHERE IdGenero = @IdGenero";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@Nome", generoDomain.Nome);
                cmd.Parameters.AddWithValue("@IdEstiloMusical", generoDomain.IdGenero);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }//fim atualizar

        //BuscarPorId
        public GeneroDomain BuscarPorId(int id)
        {
            string Query = "SELECT IdGenero, Nome FROM Generos WHERE IdGenero = @IdGenero";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();
                SqlDataReader sdr;
                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    cmd.Parameters.AddWithValue("IdGenero", id);
                    sdr = cmd.ExecuteReader();

                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            GeneroDomain estilo = new GeneroDomain
                            {
                                IdGenero = Convert.ToInt32(sdr["IdGenero"]),
                                Nome = sdr["Nome"].ToString()
                            };
                            return estilo;
                        }
                    }
                }
                return null;
            }
        }//fim buscar por id

        //Cadastrar
        public void Cadastrar(GeneroDomain genero)
        {
            string Query = "INSERT INTO Generos(Nome) VALUES(@Nome)";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                //o que quer fazer(query) na conexao(ta na stringconexao)
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@Nome", genero.Nome);
                con.Open();

                //só manda o insert, n tem nada no retorno
                cmd.ExecuteNonQuery();
            }
        }//fim Cadastrar
        //Deletar
        public void Deletar(int id)
        {
            string Query = "DELETE FROM Generos WHERE IdGenero = @IdGenero";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@IdGenero", id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }// fim deletar

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
                            Nome = rdr["Nome"].ToString()
                        };
                        generos.Add(genero);
                    }
                }
            }

            return generos;
        }//Fim Listar

    }
}

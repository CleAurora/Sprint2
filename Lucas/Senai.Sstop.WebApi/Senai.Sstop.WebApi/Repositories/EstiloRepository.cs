using Senai.Sstop.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Sstop.WebApi.Repositories
{
    public class EstiloRepository
    {
        //List<EstiloDomain> estilos = new List<EstiloDomain>()
        //{
        //    new EstiloDomain { IdEstilo = 1, Nome = "Rock"}
        //    ,new EstiloDomain {  IdEstilo = 2, Nome = "Pop"}
        //};

        //string de conexão
        private string StringConexao ="Data Source=.\\SqlExpress; initial catalog=M_SStop; User Id=sa;Pwd=132";


        /// <summary>
        /// Cadastra um novo estilo musical no banco de dados
        /// </summary>
        /// <param name="estilo"></param>
        public void Cadastrar(EstiloDomain estilo)
        {
            string Query = "INSERT INTO EstilosMusicais(Nome) VALUES(@Nome)";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                //o que quer fazer(query) na conexao(ta na stringconexao)
                SqlCommand cmd = new SqlCommand(Query,con);
                cmd.Parameters.AddWithValue("@Nome", estilo.Nome);
                con.Open();

                //só manda o insert, n tem nada no retorno
                cmd.ExecuteNonQuery();
            }
        }

        public List<EstiloDomain> Listar()
        {
            List<EstiloDomain> estilos = new List<EstiloDomain>();
            
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string Query = "SELECT IdEstiloMusical, Nome FROM EstilosMusicais ORDER BY IdEstiloMusical ASC";

                con.Open();
                SqlDataReader rdr;
                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        EstiloDomain estilo = new EstiloDomain
                        {
                            IdEstilo = Convert.ToInt32(rdr["IdEstiloMusical"]),
                            Nome = rdr["Nome"].ToString()
                        };
                        estilos.Add(estilo);
                    }
                }
            }

            return estilos;
        }

        public EstiloDomain BuscarPorId(int id)
        {
            string Query = "SELECT IdEstiloMusical, Nome FROM EstilosMusicais WHERE IdEstiloMusical = @IdEstiloMusical";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();
                SqlDataReader sdr;
                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    cmd.Parameters.AddWithValue("IdEstiloMusical", id);
                    sdr = cmd.ExecuteReader();

                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            EstiloDomain estilo = new EstiloDomain
                            {
                                IdEstilo = Convert.ToInt32(sdr["IdEstiloMusical"]),
                                Nome = sdr["Nome"].ToString()
                            };
                            return estilo;
                        }
                    }
                }
                return null;  
            }
        }

        public void Alterar(EstiloDomain estiloDomain)
        {   
            string Query = "UPDATE EstilosMusicais SET Nome = @Nome WHERE IdEstiloMusical = @IdEstiloMusical";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@Nome", estiloDomain.Nome);
                cmd.Parameters.AddWithValue("@IdEstiloMusical", estiloDomain.IdEstilo);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Deletar(int id)
        {
            string Query = "DELETE FROM EstilosMusicais WHERE IdEstiloMusical = @IdEstiloMusical";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@IdEstiloMusical", id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}

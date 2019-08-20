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
        //   , new EstiloDomain { IdEstilo = 1, Nome = "Pop"}
        //};



        public void Cadastrar(EstiloDomain estilo)
        {
            string Query = "Insert into EstilosMusicas(Nome) Values(@Nome)";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                //declara o comando com a query e a conexão
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@Nome", estilo.Nome);
                //abre a conexão
                con.Open();
                //executa o comando
                cmd.ExecuteNonQuery();
            }
        }


        private string StringConexao = "Data Source =.\\SqlExpress; initial catalog=M_SStop;User Id = sa;Pwd=132";

        public EstiloDomain BuscarPorId(int id)
        {
            string Query = "Select IdEstiloMusical, Nome From EstilosMusicas where IdEstiloMusical = @IdEstiloMusical";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();
                SqlDataReader sdr;

                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    cmd.Parameters.AddWithValue("@IdEstiloMusical", id);
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
                    return null;

                }
            }
        }

        public List<EstiloDomain> Listar()
        {

            List<EstiloDomain> estilos = new List<EstiloDomain>();

            //abre conexao com banco
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                //faz leitura com todos os registros
                // declara a instrucao a ser realizada
                string Query = "SELECT IdEstiloMusical, Nome FROM EstilosMusicas order by Nome asc";

                //abre a conexão com bd
                con.Open();

                //declara para percorrer a lista
                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    //executa a query
                    rdr = cmd.ExecuteReader();

                    while(rdr.Read())
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

        //update
        public void Alterar(EstiloDomain estiloDomain)
        {
            string Query = "Update EstilosMusicas SET Nome = @Nome where IdEstiloMusical = @IdEstiloMusical";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                //faço o comando
                SqlCommand cmd = new SqlCommand(Query, con);
                //defino os parâmetros
                cmd.Parameters.AddWithValue("@Nome", estiloDomain.Nome);
                cmd.Parameters.AddWithValue("@IdEstiloMusical", estiloDomain.IdEstilo);
                //abrir a conexão
                con.Open();
                //executar
                cmd.ExecuteNonQuery();
            }
        }

        public void Deletar(int id)
        {
            string Query = "delete from EstilosMusicas where IdEstiloMusical = @IdEstiloMusical";
            //conexão
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                //comando
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@IdEstiloMusical", id);
                con.Open();
                //executar
                cmd.ExecuteNonQuery();
            }
        }
            

    }
}

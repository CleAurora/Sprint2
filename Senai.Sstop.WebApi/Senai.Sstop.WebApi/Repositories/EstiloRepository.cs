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

        

        private string StringConexao = "Data Source =.\\SqlExpress; initial catalog=M_SStop;User Id = sa;Pwd=132";

        public List<EstiloDomain> Listar()
        {

            List<EstiloDomain> estilos = new List<EstiloDomain>();

            //abre conexao com banco
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                //faz leitura com todos os registros
                // declara a instrucao a ser realizada
                string Query = "SELECT IdEstiloMusical, Nome FROM EstilosMusicas order by asc";

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
    }
}

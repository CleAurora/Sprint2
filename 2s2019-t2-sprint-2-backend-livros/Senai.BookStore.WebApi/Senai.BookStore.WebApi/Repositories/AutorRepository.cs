using Senai.BookStore.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.BookStore.WebApi.Repositories
{
    public class AutorRepository
    {
        private string StringConexao = "Data Source=.\\SqlExpress; initial catalog=M_BookStore; User Id=sa;Pwd=132";

        /// <summary>
        /// Método para Listar os autores 
        /// </summary>
        /// <returns></returns>
        public List<AutorDomain> Listar()
        {
            List<AutorDomain> autores = new List<AutorDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string Query = "SELECT IdAutor, Nome FROM IdAutor ORDER BY Autor ASC";

                con.Open();
                SqlDataReader rdr;
                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        AutorDomain autor = new AutorDomain
                        {
                            IdAutor = Convert.ToInt32(rdr["IdAutor"]),
                            Nome = rdr["Nome"].ToString()
                        };
                        autores.Add(autor);
                    }
                }
            }

            return autores;
        }//Fim Listar
    }
}

using Senai.Peoples.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Repositories
{
    public class FuncionarioRepository
    { //ações: listar, buscar por id, 
      //deletar, atualizar e inserir

        //Declaração da minha String de Conexão
        private string StringConexao = "Data Source =.\\SqlExpress; initial catalog=M_Peoples;User Id = sa;Pwd=132";

        //Listar

        public List<FuncionarioDomain> Listar()
        {

            List<FuncionarioDomain> funcionarios = new List<FuncionarioDomain>();

            //abre conexao com banco
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                //faz leitura com todos os registros
                // declara a instrucao a ser realizada
                string Query = "SELECT IdNome, Nome, Sobrenome FROM Funcionarios order by Nome asc";

                //abre a conexão com bd
                con.Open();

                //declara para percorrer a lista
                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    //executa a query
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        FuncionarioDomain funcionario = new FuncionarioDomain
                        {
                            IdNome = Convert.ToInt32(rdr["IdNome"]),
                            Nome = rdr["Nome"].ToString(),
                            Sobrenome = rdr["Sobrenome"].ToString()
                        };
                        funcionarios.Add(funcionario);
                    }
                }
            }

            return funcionarios;
        }// Fim Listar

        // Buscar por id

        public FuncionarioDomain BuscarPorId(int id)
        {
            string Query = "Select IdNome, Nome, Sobrenome From Funcionarios where IdNome = @IdNome";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();
                SqlDataReader sdr;

                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    cmd.Parameters.AddWithValue("@IdNome", id);
                    sdr = cmd.ExecuteReader();

                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            FuncionarioDomain funcionario = new FuncionarioDomain
                            {
                                IdNome = Convert.ToInt32(sdr["IdNome"]),
                                Nome = sdr["Nome"].ToString(),
                                Sobrenome = sdr["Sobrenome"].ToString()
                            };
                            return funcionario;
                        }
                    }
                    return null;

                }
            }
        }// fim buscar por id

        //Deletar
        public void Deletar(int id)
        {
            string Query = "delete from Funcionarios where IdNome = @IdNome";
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@IdNome", id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }//Fim Deletar

        // Atualizar
        public void Alterar(FuncionarioDomain funcionarioDomain)
        {
            string Query = "Update Funcionarios set Nome = @Nome where IdNome = @IdNome Update Funcionarios set Sobrenome = @Sobrenome where IdNome = @IdNome ";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@Nome", funcionarioDomain.Nome);
                cmd.Parameters.AddWithValue("@IdNome", funcionarioDomain.IdNome);
                cmd.Parameters.AddWithValue("@Sobrenome", funcionarioDomain.Sobrenome);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }//Fim Atualizar

        // Inserir
        public void Cadastrar(FuncionarioDomain funcionario)
        {
            string Query = "Insert into Funcionarios(Nome, Sobrenome) Values(@Nome, @Sobrenome)";
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@Nome", funcionario.Nome);
                cmd.Parameters.AddWithValue("@Sobrenome", funcionario.Sobrenome);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }//fim Inserir

        //Criar um endpoint chamado /api/funcionarios/buscar/{nome} passando 
        //como parâmetro o nome do funcionário e realizando a determinada busca no banco;

        public FuncionarioDomain BuscarPorNome(string nome)
        {
            string Query = "Select IdNome, Nome, Sobrenome, DataNascimento From Funcionarios where Nome = @Nome";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();
                SqlDataReader sdr;

                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    cmd.Parameters.AddWithValue("@Nome", nome);
                    sdr = cmd.ExecuteReader();

                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            FuncionarioDomain funcionario = new FuncionarioDomain
                            {
                                IdNome = Convert.ToInt32(sdr["IdNome"]),
                                Nome = sdr["Nome"].ToString(),
                                Sobrenome = sdr["Sobrenome"].ToString(),
                                DataNascimento = Convert.ToDateTime(sdr["DataNascimento"])
                            };
                            return funcionario;
                        }
                    }
                    return null;

                }
            }
        }// fim buscar por nome

        //Criar um endpoint chamado /api/funcionarios/nomescompletos que na saída do json, 
        //o nome e o sobrenome venham na mesma chave. Ex.: { "nomeCompleto" : "Catarina Strada" }.

        public List<FuncionarioDomain> NomesCompletos()
        {

            List<FuncionarioDomain> funcionarios = new List<FuncionarioDomain>();

            //abre conexao com banco
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                //faz leitura com todos os registros
                // declara a instrucao a ser realizada
                string Query = "SELECT IdNome, Nome, Sobrenome FROM Funcionarios order by Nome asc";

                //abre a conexão com bd
                con.Open();

                //declara para percorrer a lista
                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    //executa a query
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        FuncionarioDomain funcionario = new FuncionarioDomain
                        {
                            IdNome = Convert.ToInt32(rdr["IdNome"]),
                            Nome = rdr["Nome"].ToString(),
                            Sobrenome = rdr["Sobrenome"].ToString()
                        };
                        funcionarios.Add(funcionario);
                    }
                }
            }

            return funcionarios;
        }// Fim Nomes Completos

    }
}

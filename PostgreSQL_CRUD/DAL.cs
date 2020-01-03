using System;
using System.Data;
using Npgsql;

namespace PostgreSQL_CRUD
{
    class DAL
    {
        static string serveName = "127.0.0.1";
        static string port = "5432";
        static string userName = "postgres";
        static string password = "123456";
        static string databaseName = "Cadastro";
        NpgsqlConnection pgsqlConnection = null;
        string connString = null;

        public DAL()
        {
            connString = String.Format("Server={0};Port={1};User Id={2};Password={3};Database={4};", serveName, port, userName, password, databaseName);
        }

        public DataTable GetTodosRegistros()
        {
            DataTable dt = new DataTable();

            try
            {
                using (pgsqlConnection = new NpgsqlConnection(connString))
                {
                    // abre a conexao com PgSQL e define a instrução SQL
                    pgsqlConnection.Open();
                    string cmdSeleciona = "Select * from funcionarios order by id";

                    using (NpgsqlDataAdapter Adpt = new NpgsqlDataAdapter(cmdSeleciona, pgsqlConnection))
                    {
                        Adpt.Fill(dt);
                    }
                }
            }
            catch (NpgsqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                pgsqlConnection.Close();
            }

            return dt;
        }

        public DataTable GetRegistroPorId(int id)
        {
            DataTable dt = new DataTable();

            try
            {
                using (pgsqlConnection = new NpgsqlConnection(connString))
                {
                    pgsqlConnection.Open();
                    string cmdSeleciona = "Select * from funcionarios Where id = " + id;

                    using (NpgsqlDataAdapter Adpt = new NpgsqlDataAdapter(cmdSeleciona, pgsqlConnection))
                    {
                        Adpt.Fill(dt);
                    }
                }
            }
            catch (NpgsqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                pgsqlConnection.Close();
            }

            return dt;
        }

        public void InserirRegistros(string nome, string email, int idade)
        {

            try
            {
                using (pgsqlConnection = new NpgsqlConnection(connString))
                {
                    //Abra a conexão com o PgSQL                  
                    pgsqlConnection.Open();

                    string cmdInserir = String.Format("Insert Into funcionarios(nome,email,idade) values('{0}','{1}',{2})", nome, email, idade);

                    using (NpgsqlCommand pgsqlcommand = new NpgsqlCommand(cmdInserir, pgsqlConnection))
                    {
                        pgsqlcommand.ExecuteNonQuery();
                    }
                }
            }
            catch (NpgsqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                pgsqlConnection.Close();
            }
        }

        public void AtualizarRegistro(int codigo, string email, int idade)
        {
            try
            {
                using (pgsqlConnection = new NpgsqlConnection(connString))
                {
                    //Abra a conexão com o PgSQL                  
                    pgsqlConnection.Open();

                    string cmdAtualiza = String.Format("Update funcionarios Set email = '" + email + "' , idade = " + idade + " Where id = " + codigo);

                    using (NpgsqlCommand pgsqlcommand = new NpgsqlCommand(cmdAtualiza, pgsqlConnection))
                    {
                        pgsqlcommand.ExecuteNonQuery();
                    }
                }
            }
            catch (NpgsqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                pgsqlConnection.Close();
            }
        }

        public void DeletarRegistro(string nome)
        {
            try
            {
                using (pgsqlConnection = new NpgsqlConnection(connString))
                {
                    //abre a conexao                
                    pgsqlConnection.Open();

                    string cmdDeletar = String.Format("Delete From funcionarios Where nome = '{0}'", nome);

                    using (NpgsqlCommand pgsqlcommand = new NpgsqlCommand(cmdDeletar, pgsqlConnection))
                    {
                        pgsqlcommand.ExecuteNonQuery();
                    }
                }
            }
            catch (NpgsqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                pgsqlConnection.Close();
            }
        }
    }
}

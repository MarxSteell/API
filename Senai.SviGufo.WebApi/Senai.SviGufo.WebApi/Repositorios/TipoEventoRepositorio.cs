using Senai.SviGufo.WebApi.Domains;
using Senai.SviGufo.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Senai.SviGufo.WebApi.Repositorios
{
    public class TipoEventoRepositorio : ITipoEventoRepositorio
    {
        //Data Source - Nome do Servidor
        //Initial catalog - Nome do banco
        //User ID = Usuário
        //Password = Senha
        //Caso seja autenticação do windows não pass usuário e senha e passa integrated security= true
        private string StringConexao = @"Data Source=.\SqlExpress;initial catalog=SVIGUFO;user id=sa;password=132";

        public void Alterar(TipoEventoDomain tipoEvento)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryAltercao = "UPDATE TIPO_EVENTOS SET TITULO = @TITULO WHERE ID = @ID";
                SqlCommand cmd = new SqlCommand(queryAltercao, con);
                cmd.Parameters.AddWithValue("@TITULO", tipoEvento.Nome);
                cmd.Parameters.AddWithValue("@ID", tipoEvento.ID);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Cadastrar(TipoEventoDomain tipoEvento)
        {
            //Declaro a minha conexão e passo como parâmetro a string de conexão
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                //Query que insere os dados
                string queryInsert = "INSERT INTO TIPO_EVENTOS(TITULO) VALUES(@TITULO)";

                //Cria um objeto comando passando como parâmetro a query e a conexão
                SqlCommand cmd = new SqlCommand(queryInsert, con);

                //Atribui o nome do evento ao parâmetro
                cmd.Parameters.AddWithValue("@TITULO", tipoEvento.Nome);

                //Abre o banco
                con.Open();

                //Executa o comando
                cmd.ExecuteNonQuery();
            }
        }

        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryDelete = "DELETE FROM TIPO_EVENTOS WHERE ID =@ID";
                SqlCommand cmd = new SqlCommand(queryDelete, con);
                cmd.Parameters.AddWithValue("@ID", id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Lista os tipos de eventos
        /// </summary>
        /// <returns>Lista de TipoEventoDomain</returns>
        public List<TipoEventoDomain> Listar()
        {
            //Objeto que irá retornar na chamada do método
            List<TipoEventoDomain> tiposEventos = new List<TipoEventoDomain>();

            //Define a conexão passando a string de conexão
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string QuerySelect = "SELECT ID, TITULO FROM TIPO_EVENTOS";

                //Define o comando que será executado no construtor
                //passa a Query e a conexão
                using (SqlCommand cmd = new SqlCommand(QuerySelect,con))
                {
                    //Abre a conexãp com o Banco de Dados
                    con.Open();

                    //Objeto que irá armazenar os dados retornados
                    SqlDataReader rdr = cmd.ExecuteReader();

                    //Percorre todos os dados do objeto
                    while (rdr.Read())
                    {
                        //Cria um objeto tipo evento e atribui os valores da tabela ao objeto
                        TipoEventoDomain tipoEvento = new TipoEventoDomain
                        {
                            ID = Convert.ToInt32((rdr["ID"]))
                            , Nome = rdr["TITULO"].ToString()
                        };

                        //Adiciona o objeto na lista de tipos de eventos
                        tiposEventos.Add(tipoEvento);
                    }
                }
            }
            return tiposEventos;
        }
    }
}

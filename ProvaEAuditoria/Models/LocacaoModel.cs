using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProvaEAuditoria.Models
{
    public class LocacaoModel : IDisposable
    {
        private SqlConnection connection;

        public LocacaoModel()
        {
            string strConn = "Data Source=localhost;Initial Catalog=Locadora;Integrated Security=true";
            connection = new SqlConnection(strConn);
            connection.Open();
        }

        public void Dispose()
        {
            connection.Close();
        }

        public void Create(Locacao locacao)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = @"insert into Locacao values(@idFilme,@idCliente,@dataLocacao,@dataDevolucao)";

            cmd.Parameters.AddWithValue("@idFilme", locacao.IdFilme);
            cmd.Parameters.AddWithValue("@idCliente", locacao.IdCliente);
            cmd.Parameters.AddWithValue("@dataLocacao", locacao.DataLocacao);
            cmd.Parameters.AddWithValue("@dataDevolucao", locacao.DataDevolucao);


            cmd.ExecuteNonQuery();
        }

        public List<Locacao> Read()
        {
            List<Locacao> lista = new List<Locacao>();
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = connection;
            cmd.CommandText = @"select * from locacao";

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Locacao locacao = new Locacao();
                locacao.Id = (int)reader["Id"];
                locacao.IdCliente = (int)reader["IdCliente"];
                locacao.IdFilme = (int)reader["IdFilme"];
                locacao.DataLocacao = (DateTime)reader["DataLocacao"];
                locacao.DataDevolucao = (DateTime)reader["DataDevolucao"];

                lista.Add(locacao);
            }

            return lista;
        }

        public void Update(Locacao locacao)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = @"update Locacao set IdFilme=@idFilme,IdCliente=@idCliente,DataLocacao=@dataLocacao,DataDevolucao=@dataDevolucao where Id=@id";


            cmd.Parameters.AddWithValue("@id", locacao.Id);
            cmd.Parameters.AddWithValue("@idFilme", locacao.IdFilme);
            cmd.Parameters.AddWithValue("@idCliente", locacao.IdCliente);
            cmd.Parameters.AddWithValue("@dataLocacao", locacao.DataLocacao);
            cmd.Parameters.AddWithValue("@dataDevolucao", locacao.DataDevolucao);

            cmd.ExecuteNonQuery();
        }

        public void Delete(Locacao locacao)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = @"delete from Locacao where Id=@id";

            cmd.Parameters.AddWithValue("@id", locacao.Id);

            cmd.ExecuteNonQuery();
        }
    }
}

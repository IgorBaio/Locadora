using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProvaEAuditoria.Models
{
    public class ClientesModel : IDisposable
    {
        private SqlConnection connection;

        public ClientesModel()
        {
            string strConn = "Data Source=localhost;Initial Catalog=Locadora;Integrated Security=true";
            connection = new SqlConnection(strConn);
            connection.Open();
        }

        public void Dispose()
        {
            connection.Close();
        }

        public void Create(Cliente cliente)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = @"insert into clientes values(@nome,@cpf,@dataNascimento)";

            cmd.Parameters.AddWithValue("@nome", cliente.Nome);
            cmd.Parameters.AddWithValue("@cpf", cliente.CPF);
            cmd.Parameters.AddWithValue("@dataNascimento", cliente.DataNascimento);


            cmd.ExecuteNonQuery();
        }

        public List<Cliente> Read()
        {
            List<Cliente> lista = new List<Cliente>();
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = connection;
            cmd.CommandText = @"select * from clientes";

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Cliente cliente = new Cliente();
                cliente.Id = (int)reader["Id"];
                cliente.Nome = (string)reader["Nome"];
                cliente.CPF= (string)reader["Cpf"];
                cliente.DataNascimento= (DateTime)reader["DataNascimento"];

                lista.Add(cliente);
            }

            return lista;
        }

        public void Update(Cliente cliente)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = @"update Clientes set Nome=@nome, Cpf=@cpf, DataNascimento=@dataNascimento where Id=@id";

            cmd.Parameters.AddWithValue("@nome", cliente.Nome);
            cmd.Parameters.AddWithValue("@cpf", cliente.CPF);
            cmd.Parameters.AddWithValue("@dataNascimento", cliente.DataNascimento);
            cmd.Parameters.AddWithValue("@id", cliente.Id);

            cmd.ExecuteNonQuery();
        }

        public void Delete(Cliente cliente)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = @"delete from Clientes where Id=@id";

            cmd.Parameters.AddWithValue("@id", cliente.Id);

            cmd.ExecuteNonQuery();
        }

    }
}

using Microsoft.Data.SqlClient;
using ProvaEAuditoria.Models;
using System;
using System.Collections.Generic;

namespace ProvaEAuditoria.Models
{
    public class FilmesModel : IDisposable
    {
        private SqlConnection connection;

        public FilmesModel()
        {
            string strConn = "Data Source=localhost;Initial Catalog=Locadora;Integrated Security=true";
            connection = new SqlConnection(strConn);
            connection.Open();
        }

        public void Dispose()
        {
            connection.Close();
        }

        public void Create(Filmes filme)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = @"insert into Filmes values(@titulo,@lancamento,@classificacaoIndicativa)";

            cmd.Parameters.AddWithValue("@titulo", filme.Titulo);
            cmd.Parameters.AddWithValue("@lancamento", filme.Lancamento);
            cmd.Parameters.AddWithValue("@classificacaoIndicativa", filme.ClassificacaoIndicativa);


            cmd.ExecuteNonQuery();
        }

        public List<Filmes> Read()
        {
            List<Filmes> lista = new List<Filmes>();
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = connection;
            cmd.CommandText = @"select * from filmes";

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Filmes filme = new Filmes();
                filme.Id = (int)reader["Id"];
                filme.Titulo = (string)reader["Titulo"];
                filme.Lancamento = reader["Lancamento"].ToString() == "0"? false:true;
                filme.ClassificacaoIndicativa = (int)reader["ClassificacaoIndicativa"];

                lista.Add(filme);
            }

            return lista;
        }

        public void Update(Filmes filme)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = @"update Filmes set Titulo=@titulo, Lancamento=@lancamento, ClassificacaoIndicativa=@classificacaoIndicativa where Id=@id";

            cmd.Parameters.AddWithValue("@titulo", filme.Titulo);
            cmd.Parameters.AddWithValue("@lancamento", filme.Lancamento);
            cmd.Parameters.AddWithValue("@classificacaoIndicativa", filme.ClassificacaoIndicativa);
            cmd.Parameters.AddWithValue("@id", filme.Id);

            cmd.ExecuteNonQuery();
        }

        public void Delete(Filmes filme)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = @"delete from Filmes where Id=@id";

            cmd.Parameters.AddWithValue("@id", filme.Id);

            cmd.ExecuteNonQuery();
        }


    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// Adiciona essa linha
using System.Data.SqlClient;
// Disciplina em outro namespace
using NotaWeb.Entity;


namespace NotaWeb.Models
{
    // Puxa do Model
    public class DisciplinaModel : Model
    {
        public void Create(Itens entity)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "insert into Itens values (@funcionario_id, @nome)";

            cmd.Parameters.AddWithValue("@funcionario_id", entity.Funcionario);
            cmd.Parameters.AddWithValue("@nome", entity.Nome);

            cmd.ExecuteNonQuery();
        }

        internal List<Itens> Read(int funcionario_id)
        {
            List<Itens> lista = new List<Itens>();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = @"SELECT * FROM Itens
                                WHERE funcionario_id = @Funcionario_id";

            cmd.Parameters.AddWithValue("@Funcionario_id", funcionario_id);

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Itens d = new Itens();
                d.Id = (int)reader["Id"];
                d.Funcionario_id = (int)reader["Funcionario_id"];
                d.Nome = (string)reader["Nome"];

                lista.Add(d);
            }

            return lista;
        }
    }
}
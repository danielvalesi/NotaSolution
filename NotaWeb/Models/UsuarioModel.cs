using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using NotaWeb.Entity;

namespace NotaWeb.Models
{
    public class UsuarioModel : Model
    {
        public Pessoa Login(string email, string senha)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = @"select * from Usuarios
                where email = @email AND senha = @senha";

            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@senha", senha);

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                // Polimorfismo
                if ((string)reader["tipo"] == "Funcionarios")
                {
                    Funcionario funcionario = new Funcionario();
                    funcionario.Pessoa_id = (int)reader["Pessoa_id"];
                    funcionario.Nome = (string)reader["Nome"];
                    funcionario.Email = (string)reader["Email"];
                    funcionario.Cargo = (string)reader["Cargo"];
                   

                    return funcionario;
                }
                else
                {
                    Cliente cliente = new Cliente();
                    cliente.Pessoa_id = (int)reader["Pessoa_id"];
                    cliente.Nome = (string)reader["Nome"];
                    cliente.Email = (string)reader["Email"];
                    //cliente.PorcentagemDesconto = (decimal)reader["PorcentagemDesconto"];


                    return cliente;
                }
            }

            return null;
        }
    }
}
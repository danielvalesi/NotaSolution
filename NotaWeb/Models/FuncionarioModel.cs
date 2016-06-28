using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// add notaweb
using NotaWeb.Entity;
using System.Data.SqlClient;

namespace NotaWeb.Models
{
    public class FuncionarioModel : Model
    {

        // CADASTRAR Funcionario
        public void Create(Funcionario f)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = @"
                    INSERT INTO Pessoas
                    (nome, email, senha)
                    VALUES
                    (@nome, @email, @senha)
                    INSERT INTO Funcionarios
                    (pessoa_id, cargo, horarioEntrada, horarioSaida)
                    VALUES
                    (@@IDENTITY, @cargo, @horarioEntrada, @horarioSaida)
            ";

            cmd.Parameters.AddWithValue("@nome", f.Nome);
            cmd.Parameters.AddWithValue("@email", f.Email);
            cmd.Parameters.AddWithValue("@senha", f.Senha);
            //cmd.Parameters.AddWithValue("@cpf", f.Cpf);
            cmd.Parameters.AddWithValue("@cargo", f.Cargo);
            cmd.Parameters.AddWithValue("@horarioEntrada", f.HorarioEntrada);
            cmd.Parameters.AddWithValue("@horarioSaida", f.HorarioSaida);

            cmd.ExecuteNonQuery();

        }

        // LISTANDO FUNCIONARIOS (SELECT)

        public List<Funcionario> Read()
        {

            List<Funcionario> lista = new List<Funcionario>();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = @" SELECT p.pessoa_id, p.nome, p.email, p.senha, p.cpf, f.cargo, f.horarioEntrada, f.horarioSaida
                                FROM Pessoas p, Funcionarios f
                                WHERE p.pessoa_id = f.pessoa_id";


            SqlDataReader reader = cmd.ExecuteReader();


            while (reader.Read())
            {
                Funcionario f = new Funcionario();
                //funcionario.FuncionarioId = reader.GetInt32(0);
                f.Pessoa_id = (int)reader["Pessoa_id"];
                f.Nome = (string)reader["Nome"];
                f.Email = (string)reader["Email"];
                f.Senha = (string)reader["Senha"];
                f.Cpf = (string)reader["Cpf"];
                f.Cargo = (string)reader["Cargo"];
                f.HorarioEntrada = (TimeSpan)reader["HorarioEntrada"];
                //f.HorarioSaida = (TimeSpan)reader["HorarioSaida"];
                //f.HorarioSaida = (TimeSpan)(reader["HorarioSaida"] != DBNull.Value ? reader["HorarioSaida"] : null);
                f.HorarioSaida = (TimeSpan?)(reader["HorarioSaida"] != DBNull.Value ? reader["HorarioSaida"] : null);

                lista.Add(f);
            }


            return lista;
        }

        // BUSCA DE FUNCIONARIOS POR NOME

        internal List<Funcionario> Read(string nome)
        {
            List<Funcionario> lista = new List<Funcionario>();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = @"select * from Pessoas p, Funcionarios f, where nome like @nome AND p.pessoa_id = f.pessoa_id";



            cmd.Connection = conn;

            cmd.Parameters.AddWithValue("@nome", "%" + nome + "%");

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Funcionario f = new Funcionario();
                //funcionario.funcionarioId = reader.GetInt32(0);
                f.Pessoa_id = (int)reader["Pessoa_id"];
                f.Nome = (string)reader["Nome"];
                f.Email = (string)reader["Email"];
                f.Senha = (string)reader["Senha"];
                f.Cpf = (string)reader["Cpf"];
                f.Cargo = (string)reader["Cargo"];
                f.HorarioEntrada = (TimeSpan)reader["HorarioEntrada"];
                //f.HorarioSaida = (TimeSpan)reader["HorarioSaida"];
                f.HorarioSaida = (TimeSpan?)(reader["HorarioSaida"] != DBNull.Value ? reader["HorarioSaida"] : null);


                lista.Add(f);
            }

            return lista;

        }

        // BUSCA POR ID

        internal Funcionario Read(int idFuncionario)
        {
            Funcionario f = new Funcionario();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = @"select p.pessoa_id, p.nome, p.email, p.senha, p.cpf, f.cargo, f.horarioEntrada, f.horarioSaida from Funcionarios f, Pessoas p where p.pessoa_id = f.pessoa_id";
            cmd.Connection = conn;

            cmd.Parameters.AddWithValue("@pessoa_id", idFuncionario);

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                f.Pessoa_id = (int)reader["Pessoa_id"];
                f.Nome = (string)reader["Nome"];
                f.Email = (string)reader["Email"];
                f.Senha = (string)reader["Senha"];
                f.Cpf = (string)reader["Cpf"];
                f.Cargo = (string)reader["Cargo"];
                f.HorarioEntrada = (TimeSpan)reader["HorarioEntrada"];
                //f.HorarioSaida = (TimeSpan)reader["HorarioSaida"];
                f.HorarioSaida = (TimeSpan?)(reader["HorarioSaida"] != DBNull.Value ? reader["HorarioSaida"] : null);
            }

            return f;

        }

        // ATUALIZAR FUNCIONARIO
        public void Update(Funcionario f)
        {
            SqlCommand cmd = new SqlCommand();


            cmd.Connection = conn;
            cmd.CommandText = @"
                    UPADTE Pessoas set
                    Nome = @nome, Email = @email, Senha = @senha, Cpf = @cpf
                    WHERE
                    pessoa_id = @pessoa_id;
  
                    Upadte Funcionarios set
                    cargo = @cargo, horarioEntrada = @horarioEntrada, horarioSaida = @horarioSaida

            ";

            cmd.Parameters.AddWithValue("@nome", f.Nome);
            cmd.Parameters.AddWithValue("@email", f.Email);
            cmd.Parameters.AddWithValue("@senha", f.Senha);
            cmd.Parameters.AddWithValue("@cpf", f.Cpf);
            cmd.Parameters.AddWithValue("@cargo", f.Cargo);
            cmd.Parameters.AddWithValue("@horarioEntrada", f.HorarioEntrada);
            cmd.Parameters.AddWithValue("@horarioSaida", f.HorarioSaida);

       


            cmd.ExecuteNonQuery();
        }

        // APAGAR FUNCIONARIO
        public void Delete(int idFuncionario)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = @"
                    DELETE from Funcionarios
                    WHERE
                    pessoa_id = @pessoa_id;
            ";

            cmd.Parameters.AddWithValue("@pessoa_id", idFuncionario);

            cmd.ExecuteNonQuery();

        }

        // metodo login

        internal Funcionario Read(string email, string senha)
        {
            Funcionario f = null;

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = @"select * from Pessoas where email = @Email and senha = @Senha";


            cmd.Parameters.AddWithValue("@Email", email);
            cmd.Parameters.AddWithValue("@Senha", senha);


            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                f = new Funcionario();
                //funcionario.funcionarioId = reader.GetInt32(0);
                f.Pessoa_id = (int)reader["Pessoa_id"];
                f.Nome = (string)reader["Nome"];
                f.Email = (string)reader["Email"];
                f.Cpf = (string)reader["Cpf"];
                f.Cargo = (string)reader["Cargo"];
            }

            return f;

        }

    }
}

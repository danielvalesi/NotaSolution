using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NotaWeb.Models;

namespace NotaWeb.Entity
{
    public class Funcionario : Pessoa
    {


        public string Cargo { get; set; }

        public TimeSpan HorarioEntrada { get; set; }

        public TimeSpan? HorarioSaida { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NotaWeb.Entity
{
    public class Itens
    {
        public int Id { get; set; }
        public int Funcionario_id { get; set; }
        public string Nome { get; set; }

        // Classes Associadas
        public Funcionario Funcionario { get; set; }
    }
}
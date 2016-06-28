using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NotaWeb.Entity
{
    public class Cliente : Pessoa
    {
        public int Pessoa_id { get; set; }

        public decimal PorcentagemDesconto { get; set; }

    }
}
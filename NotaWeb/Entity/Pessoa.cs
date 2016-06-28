using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NotaWeb.Entity
{
    public class Pessoa
    {
        private int pessoa_id;

        public int Pessoa_id {
            get { return pessoa_id; }
            set { pessoa_id = value; }
        }

        //public int Pessoa_id { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

        public string Senha { get; set; }

        public string Tipo { get; set; }

        public string Cpf { get; set; }

    }
}
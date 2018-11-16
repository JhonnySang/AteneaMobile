using System;
using System.Collections.Generic;
using System.Text;

namespace AteneaMobile.Models
{
    public class Usuario
    {
        public int UsuCod { get; set; }
        public int EmpCod { get; set; }

        public string UsuLog { get; set; }
        public string UsuPass { get; set; }
        public bool UsuPrivilegios { get; set; }

        public bool UsuEstado { get; set; }
        public DateTime UsuUltConexFch { get; set; }
        public TimeSpan UsuUltConexHora { get; set; }
    }
}

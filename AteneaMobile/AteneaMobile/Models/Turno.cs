using System;
using System.Collections.Generic;
using System.Text;

namespace AteneaMobile.Models
{
    public class Turno
    {
        public int ptuCod { get; set; }
        public int praCod { get; set; }
        public int pacCod { get; set; }
        public int proCod { get; set; }
        public int ptuNro { get; set; }
        public DateTime ptuFecha { get; set; }
        public string ptuHora { get; set; }
        public string ptuUsuLog { get; set; }
        public DateTime ptuUsuFch { get; set; }
        public string ptuUsuHra { get; set; }
        public string paciente { get; set; }
        public string profesional { get; set; }
        public string practica { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Text;

namespace AteneaMobile.Models
{
    public class Empleado : Persona
    {
        public int empCod { get; set; }
        public bool empActivo { get; set; }
        public string empCargo { get; set; }
        public DateTime empFchAlta { get; set; }
        public DateTime? empFchBaja { get; set; }
    }
}

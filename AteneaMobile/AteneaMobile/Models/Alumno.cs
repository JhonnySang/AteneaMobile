using System;
using System.Collections.Generic;
using System.Text;

namespace AteneaMobile.Models
{
    public class Alumno : Persona
    {
        public int aluCod { get; set; }
        public string aluFchInscripcion { get; set; }
        public bool aluEstado { get; set; }
        public string aluUsuLog { get; set; }
        public DateTime aluUsuFch { get; set; }
        public string aluUsuHra { get; set; }
    }
}

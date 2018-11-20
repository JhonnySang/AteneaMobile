using System;

namespace AteneaMobile.Models
{
    public class Paciente : Persona
    {
        public int pacCod { get; set; }
        public bool pacEstado { get; set; }
        public string pacEstadoAuditor { get; set; }
        public DateTime pacFchAlta { get; set; }
        public object pacFchBaja { get; set; }
        public object pacFchSuspencion { get; set; }
        public string pacUsuLog { get; set; }
        public DateTime pacUsuFch { get; set; }
        public string pacUsuHra { get; set; }
    }
}
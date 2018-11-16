using System;

namespace AteneaMobile.Models
{
    public class Paciente
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
        public int perCod { get; set; }
        public string perNombre { get; set; }
        public string perApellido { get; set; }
        public string perDomicilio { get; set; }
        public int perDni { get; set; }
        public string perTipoDoc { get; set; }
        public string perMail { get; set; }
        public int perTelefono { get; set; }
        public string perLocalidad { get; set; }
        public string perProvincia { get; set; }
        public string perNacionalidad { get; set; }
        public DateTime perFchNac { get; set; }
        public int perEdad { get; set; }
        public string apyNom { get; set; }
    }
}
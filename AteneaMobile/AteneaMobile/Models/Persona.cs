using System;
using System.Collections.Generic;
using System.Text;

namespace AteneaMobile.Models
{
    public class Persona
    {
        public string perUsuLog { get; set; }
        public DateTime perUsuFch { get; set; }
        public string perUsuHra { get; set; }
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

using System;
using System.Collections.Generic;
using System.Text;

namespace AteneaMobile.Models
{
    public class CursoInscripcion
    {
        public int cinCod { get; set; }
        public int aluCod { get; set; }
        public int curCod { get; set; }
        public DateTime cinFchInscripcion { get; set; }
        public string cinObservaciones { get; set; }
        public string cinUsuLog { get; set; }
        public DateTime cinUsuFch { get; set; }
        public string cinUsuHra { get; set; }
        public string alumnoApyNom { get; set; }
        public string cursoNombre { get; set; }
        public bool cinEstado { get; set; }
    }
}
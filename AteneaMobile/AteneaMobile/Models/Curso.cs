using System;

namespace AteneaMobile.Models
{
    public partial class Curso
    {
        public int curCod { get; set; }
        public int proCod { get; set; }
        public string curDescripcion { get; set; }
        public float curCosto { get; set; }
        public DateTime curFchInicio { get; set; }
        public DateTime curFchFin { get; set; }
        public bool curEstado { get; set; }
        public string profesional { get; set; }
    }
}

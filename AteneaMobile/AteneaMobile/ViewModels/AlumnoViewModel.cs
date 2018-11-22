using System;
using System.Collections.Generic;
using System.Text;
using AteneaMobile.Models;

namespace AteneaMobile.ViewModels
{
    public class AlumnoViewModel
    {
        #region Propperties
        public Alumno Alumno { get; set; }
        #endregion

        #region Constructors
        public AlumnoViewModel(Alumno alumno) // se la puede convertir en land xq hereda la misma clase
        {
            this.Alumno = alumno;
        }
        #endregion
    }
}

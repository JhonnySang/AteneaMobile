using System;
using System.Collections.Generic;
using System.Text;
using AteneaMobile.Models;

namespace AteneaMobile.ViewModels
{
    public class CursoInscripcionViewModel
    {
        #region Propperties
        public CursoInscripcion CursoInscripcion { get; set; }
        #endregion

        #region Constructors
        public CursoInscripcionViewModel(CursoInscripcion cursoInscripcion) // se la puede convertir en land xq hereda la misma clase
        {
            this.CursoInscripcion = cursoInscripcion;
        }
        #endregion
    }
}

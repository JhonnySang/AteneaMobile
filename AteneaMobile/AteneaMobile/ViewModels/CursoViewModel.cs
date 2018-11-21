using System;
using System.Collections.Generic;
using System.Text;
using AteneaMobile.Models;

namespace AteneaMobile.ViewModels
{
    public class CursoViewModel
    {
        #region Propperties
        public Curso Curso { get; set; }
        #endregion

        #region Constructors
        public CursoViewModel(Curso curso) // se la puede convertir en land xq hereda la misma clase
        {
            this.Curso = curso;
        }
        #endregion
    }
}

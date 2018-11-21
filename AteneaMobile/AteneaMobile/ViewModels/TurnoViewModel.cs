using System;
using System.Collections.Generic;
using System.Text;
using AteneaMobile.Models;

namespace AteneaMobile.ViewModels
{
    public class TurnoViewModel
    {
        #region Propperties
        public Turno Turno { get; set; }
        #endregion

        #region Constructors
        public TurnoViewModel(Turno turno) // se la puede convertir en land xq hereda la misma clase
        {
            this.Turno = turno;
        }
        #endregion
    }
}

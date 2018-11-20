using AteneaMobile.Models;

namespace AteneaMobile.ViewModels
{
    public class EmpleadoViewModel
    {
        #region Propperties

        public Empleado Empleado { get; set; }

        #endregion

        #region Constructors
        
        public EmpleadoViewModel(Empleado empleado)
        {
            this.Empleado = empleado;
        }

        #endregion
    }
}

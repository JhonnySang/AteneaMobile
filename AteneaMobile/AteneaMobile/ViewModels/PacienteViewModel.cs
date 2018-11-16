using AteneaMobile.Models;

namespace AteneaMobile.ViewModels
{
    public class PacienteViewModel
    {
        #region Propperties
        public Paciente Paciente { get; set; }
        #endregion

        #region Constructors
        public PacienteViewModel(Paciente paciente) // se la puede convertir en land xq hereda la misma clase
        {
            this.Paciente = paciente;
        }
        #endregion
    }
}

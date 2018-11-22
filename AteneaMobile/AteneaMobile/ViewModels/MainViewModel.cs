using System.Collections.ObjectModel;
using AteneaMobile.Models;

namespace AteneaMobile.ViewModels
{
    public class MainViewModel
    {
        #region ViewModels
        public ObservableCollection<Menu> MyMenu { get; set; }

        public LoginViewModel Login { get; set; }

        public HomeViewModel Home { get; set; }

        public PacientesViewModel Pacientes { get; set; }

        public PacienteViewModel Paciente { get; set; }

        public EmpleadosViewModel Empleados { get; set; }

        public EmpleadoViewModel Empleado { get; set; }

        public TurnosViewModel Turnos { get; set; }

        public TurnoViewModel Turno { get; set; }

        public CursosViewModel Cursos { get; set; }

        public CursoViewModel Curso { get; set; }

        public AlumnosViewModel Alumnos { get; set; }

        public AlumnoViewModel Alumno { get; set; }

        #endregion

        #region Constructors

        public MainViewModel()
        {
            instance = this;
            this.Login = new LoginViewModel();
            LoadMenu();
        }
        #endregion

        #region Methods

        private void LoadMenu()
        {
            MyMenu = new ObservableCollection<Menu>
            {
                new Menu
                {
                    Icon = "paciente",
                    PageName = "PacientesPage",
                    Title = "Pacientes"
                },
                new Menu
                {
                    Icon = "empleado",
                    PageName = "EmpleadosPage",
                    Title = "Empleados"
                },
                new Menu
                {
                    Icon = "turno",
                    PageName = "TurnosPage",
                    Title = "Turnos"
                },
                new Menu
                {
                    Icon = "Curso",
                    PageName = "CursosPage",
                    Title = "Cursos"
                },
                new Menu
                {
                    Icon = "ic_launcher",
                    PageName = "LoginPage",
                    Title = "Salir"
                }
            };
        }
        #endregion
        
        #region Singleton
        // vamos a poder llamar la pagina principal desde cualquier clase sin necesidad de tener q instanciarla
        private static MainViewModel instance;

        public static MainViewModel GetInstance()
        {
            if (instance==null)
            {
                return new MainViewModel();
            }

            return instance;
        }

        #endregion
    }
}

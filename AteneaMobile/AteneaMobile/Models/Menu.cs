using System.Windows.Input;
using AteneaMobile.Services;
using AteneaMobile.ViewModels;
using GalaSoft.MvvmLight.Command;

namespace AteneaMobile.Models
{
    public class Menu
    {
        #region Services

        private readonly NavigationService _navigationService =new NavigationService();
        #endregion

        #region Properties
        public string Icon { get; set; }
        public string Title { get; set; }
        public string PageName { get; set; }
        #endregion

        #region Command
        public ICommand NavigateCommand => new RelayCommand(Navigate);

        private async void Navigate()
        {
            switch (PageName)
            {
                case "LoginPage":
                    MainViewModel.GetInstance().Login=new LoginViewModel();
                    _navigationService.SetMainPage("LoginPage");
                    break;
                case "PacientesPage":
                    MainViewModel.GetInstance().Pacientes = new PacientesViewModel();
                    await _navigationService.NavigateOnMaster("PacientesPage");
                    break;
                case "EmpleadosPage":
                    MainViewModel.GetInstance().Empleados = new EmpleadosViewModel();
                    await _navigationService.NavigateOnMaster("EmpleadosPage");
                    break;
                case "TurnosPage":
                    MainViewModel.GetInstance().Turnos = new TurnosViewModel();
                    await _navigationService.NavigateOnMaster("TurnosPage");
                    break;
                case "CursosPage":
                    MainViewModel.GetInstance().Cursos = new CursosViewModel();
                    await _navigationService.NavigateOnMaster("CursosPage");
                    break;
            }
        }

        #endregion
    }
}

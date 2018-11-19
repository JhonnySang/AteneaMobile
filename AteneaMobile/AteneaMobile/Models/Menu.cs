using System.Windows.Input;
using AteneaMobile.Services;
using AteneaMobile.ViewModels;
using GalaSoft.MvvmLight.Command;

namespace AteneaMobile.Models
{
    public class Menu
    {
        #region Services

        private NavigationService _navigationService =new NavigationService();
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
                case "PacientesPage":
                    MainViewModel.GetInstance().Pacientes = new PacientesViewModel();
                    await _navigationService.NavigateOnMaster("PacientesPage");
                    break;
                case "LoginPage":
                    MainViewModel.GetInstance().Login=new LoginViewModel();
                    _navigationService.SetMainPage("LoginPage");
                    break;
            }
        }

        #endregion
    }
}

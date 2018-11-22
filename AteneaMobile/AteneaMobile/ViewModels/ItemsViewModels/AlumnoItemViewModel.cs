using AteneaMobile.Models;
using AteneaMobile.Services;
using GalaSoft.MvvmLight.Command;
using System.Windows.Input;

namespace AteneaMobile.ViewModels.ItemsViewModels
{
    public class AlumnoItemViewModel : Alumno
    {
        #region Services

        private readonly NavigationService _navigationService = new NavigationService();
        #endregion
        #region Commands

        public ICommand SelectAlumnoCommand => new RelayCommand(SelectAlumno);

        #endregion

        #region Methods
        private async void SelectAlumno()
        {
            // si no instancio la ViewModel relacionada a la Page, sino se instancia la Page no funciona.
            MainViewModel.GetInstance().Alumno = new AlumnoViewModel(this);
            await _navigationService.NavigateOnMaster("AlumnoPage");
        }
        #endregion
    }
}

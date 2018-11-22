using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using AteneaMobile.Models;
using AteneaMobile.Services;
using GalaSoft.MvvmLight.Command;

namespace AteneaMobile.ViewModels.ItemsViewModels
{
    public class CursoInscripcionItemViewModel : CursoInscripcion
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
            MainViewModel.GetInstance().Alumno = new CursoInscripcionViewModel(this);
            await _navigationService.NavigateOnMaster("AlumnoPage");
        }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using AteneaMobile.Models;
using AteneaMobile.Services;
using GalaSoft.MvvmLight.Command;

namespace AteneaMobile.ViewModels.ItemsViewModels
{
    public class CursoItemViewModel : Curso
    {
        #region Services

        private readonly NavigationService _navigationService = new NavigationService();
        #endregion
        #region Commands

        public ICommand SelectCursoCommand => new RelayCommand(SelectCurso);

        #endregion

        #region Methods
        private async void SelectCurso()
        {
            // si no instancio la ViewModel relacionada a la Page, sino se instancia la Page no funciona.
            MainViewModel.GetInstance().Curso = new CursoViewModel(this);
            MainViewModel.GetInstance().Alumnos = new AlumnosViewModel();
            await _navigationService.NavigateOnMaster("CursoTabbedPage");
        }
        #endregion
    }
}

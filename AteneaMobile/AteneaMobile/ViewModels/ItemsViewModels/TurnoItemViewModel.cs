using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using AteneaMobile.Models;
using AteneaMobile.Services;
using GalaSoft.MvvmLight.Command;

namespace AteneaMobile.ViewModels.ItemsViewModels
{
    public class TurnoItemViewModel : Turno
    {
        #region Services

        private readonly NavigationService _navigationService = new NavigationService();
        #endregion
        #region Commands

        public ICommand SelectTurnoCommand => new RelayCommand(SelectPaciente);

        #endregion

        #region Methods
        private async void SelectPaciente()
        {
            // si no instancio la ViewModel relacionada a la Page, sino se instancia la Page no funciona.
            MainViewModel.GetInstance().Turno = new TurnoViewModel(this);
            await _navigationService.NavigateOnMaster("TurnoPage");
        }
        #endregion
    }
}

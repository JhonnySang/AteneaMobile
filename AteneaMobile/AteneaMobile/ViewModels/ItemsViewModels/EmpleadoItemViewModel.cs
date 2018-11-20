using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using AteneaMobile.Models;
using AteneaMobile.Services;
using GalaSoft.MvvmLight.Command;

namespace AteneaMobile.ViewModels.ItemsViewModels
{
    public class EmpleadoItemViewModel : Empleado
    {
        #region Services

        private readonly NavigationService _navigationService = new NavigationService();
        #endregion
        #region Commands

        public ICommand SelectEmpleadoCommand => new RelayCommand(SelectEmpleado);

        #endregion

        #region Methods
        private async void SelectEmpleado()
        {
            // si no instancio la ViewModel relacionada a la Page, sino se instancia la Page no funciona.
            MainViewModel.GetInstance().Empleado = new EmpleadoViewModel(this);
            await _navigationService.NavigateOnMaster("EmpleadoPage");
        }
        #endregion
    }
}

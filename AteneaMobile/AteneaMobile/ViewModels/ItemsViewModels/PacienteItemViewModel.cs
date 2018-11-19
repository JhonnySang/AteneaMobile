using AteneaMobile.Models;
using AteneaMobile.Services;
using GalaSoft.MvvmLight.Command;
using System.Windows.Input;

namespace AteneaMobile.ViewModels.ItemsViewModels
{
    public class PacienteItemViewModel : Paciente
    {
        #region Services

        private readonly NavigationService _navigationService =new NavigationService();
        #endregion
        #region Commands

        public ICommand SelectPacienteCommand => new RelayCommand(SelectPaciente);

        #endregion

        #region Methods
        private async void SelectPaciente()
        {
            // si no instancio la ViewModel relacionada a la Page, sino se instancia la Page no funciona.
            MainViewModel.GetInstance().Paciente = new PacienteViewModel(this);
            await _navigationService.NavigateOnMaster("PacientePage");
        }
        #endregion
    }
}

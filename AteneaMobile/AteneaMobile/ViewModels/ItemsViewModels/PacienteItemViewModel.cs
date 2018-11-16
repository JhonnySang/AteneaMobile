using System.Windows.Input;
using AteneaMobile.Models;
using GalaSoft.MvvmLight.Command;
using Xamarin.Forms;
using PacientesPage = AteneaMobile.Views.PacientesPage;

namespace AteneaMobile.ViewModels.ItemsViewModels
{
    public class PacienteItemViewModel : Paciente
    {
        #region Commands

        public ICommand SelectPacienteCommand => new RelayCommand(SelectPaciente);

        #endregion

        #region Methods
        private async void SelectPaciente()
        {
            // si no instancio la ViewModel relacionada a la Page, sino se instancia la Page no funciona.
            MainViewModel.GetInstance().Paciente = new PacienteViewModel(this); // pasa toda la clase
            await Application.Current.MainPage.Navigation.PushAsync(new PacientesPage());
        }
        #endregion
    }
}

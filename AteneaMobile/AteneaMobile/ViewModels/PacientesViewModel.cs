using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using AteneaMobile.Models;
using AteneaMobile.Services;
using AteneaMobile.ViewModels.ItemsViewModels;
using GalaSoft.MvvmLight.Command;
using Xamarin.Forms;

namespace AteneaMobile.ViewModels
{
    public class PacientesViewModel : BaseViewModel
    {
        #region Services

        private ApiService _apiService;

        #endregion

        #region Attributes

        private List<Paciente> pacienteList;
        private List<PacienteItemViewModel> pacienteViewModelsList;
        private ObservableCollection<PacienteItemViewModel> pacientes;
        private bool isRefreshing;
        private string filter;

        #endregion

        #region Properties

        public string Filter
        {
            get => this.filter;
            set
            {
                SetProperty(ref filter, value);
                this.Search();
            }
        }

        public bool IsRefreshing
        {
            get => this.isRefreshing;
            set => SetProperty(ref isRefreshing, value);
        }

        public ObservableCollection<PacienteItemViewModel> Pacientes
        {
            get => this.pacientes;
            set => SetProperty(ref this.pacientes, value);
        }

        #endregion

        #region Constructors

        public PacientesViewModel()
        {
            this._apiService = new ApiService();
            this.LoadPacientes();
        }

        #endregion

        #region Methods

        private async void LoadPacientes()
        {
            this.IsRefreshing = true;
            var connection = await this._apiService.CheckConnection();

            if (!connection.IsSuccess)
            {
                this.IsRefreshing = false;
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    connection.Message,
                    "Accept");
                await Application.Current.MainPage.Navigation.PopAsync();
                return;
            }

            var response = await this._apiService.GetList<Paciente>(
                $"{App.UrlServer}",
                "/api",
                "/PacientesMobile");

            if (!response.IsSuccess)
            {
                this.IsRefreshing = false;
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    response.Message,
                    "Accept");
                await Application.Current.MainPage.Navigation.PopAsync();
                return;
            }

            this.pacienteList = (List<Paciente>)response.Result;
            ToPacienteItemViewModel(pacienteList);
            this.Pacientes = new ObservableCollection<PacienteItemViewModel>(
                pacienteViewModelsList);
            this.IsRefreshing = false;
        }

        private void ToPacienteItemViewModel(List<Paciente> pacientesList)
        {
            pacienteViewModelsList = AutoMapper.Mapper.Map<List<PacienteItemViewModel>>(pacientesList);
        }

        #endregion

        #region Commands

        public ICommand RefreshCommand => new RelayCommand(LoadPacientes);

        public ICommand SearchCommand => new RelayCommand(Search);

        private void Search()
        {
            if (string.IsNullOrEmpty(this.Filter))
            {
                this.Pacientes = new ObservableCollection<PacienteItemViewModel>(pacienteViewModelsList);
            }
            else
            {
                this.Pacientes = new ObservableCollection<PacienteItemViewModel>(
                    pacienteViewModelsList.Where(l => l.perNombre.ToLower().Contains(this.Filter.ToLower()) ||
                                                      l.perApellido.ToLower().Contains(this.Filter.ToLower())));
            }
        }

        #endregion
    }
}

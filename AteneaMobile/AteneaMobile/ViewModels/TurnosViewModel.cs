using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using AteneaMobile.Models;
using AteneaMobile.Services;
using AteneaMobile.ViewModels.ItemsViewModels;
using GalaSoft.MvvmLight.Command;
using Xamarin.Forms;

namespace AteneaMobile.ViewModels
{
    public class TurnosViewModel : BaseViewModel
    {
        #region Services

        private ApiService _apiService;

        #endregion

        #region Attributes

        private List<Turno> TurnoList;
        private List<TurnoItemViewModel> TurnoViewModelsList;
        private ObservableCollection<TurnoItemViewModel> turnos;
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

        public ObservableCollection<TurnoItemViewModel> Turnos
        {
            get => this.turnos;
            set => SetProperty(ref this.turnos, value);
        }

        #endregion

        #region Constructors

        public TurnosViewModel()
        {
            this._apiService = new ApiService();
            this.LoadTurnos();
        }

        #endregion

        #region Methods

        private async void LoadTurnos()
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
                await App.Navigator.PopAsync();
                return;
            }

            var response = await this._apiService.GetList<Turno>(
                $"{App.UrlServer}",
                "/api",
                "/PacientesTurnosMobile");

            if (!response.IsSuccess)
            {
                this.IsRefreshing = false;
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    response.Message,
                    "Accept");
                await App.Navigator.PopAsync();
                return;
            }

            this.TurnoList = (List<Turno>)response.Result;
            ToTurnoItemViewModel();
            this.Turnos = new ObservableCollection<TurnoItemViewModel>(
                TurnoViewModelsList);
            this.IsRefreshing = false;
        }

        private void ToTurnoItemViewModel()
        {
            TurnoViewModelsList = AutoMapper.Mapper.Map<List<TurnoItemViewModel>>(TurnoList);
        }

        #endregion

        #region Commands

        public ICommand RefreshCommand => new RelayCommand(LoadTurnos);

        public ICommand SearchCommand => new RelayCommand(Search);

        private void Search()
        {
            if (string.IsNullOrEmpty(this.Filter))
            {
                this.Turnos = new ObservableCollection<TurnoItemViewModel>(TurnoViewModelsList);
            }
            else
            {
                this.Turnos = new ObservableCollection<TurnoItemViewModel>(
                    TurnoViewModelsList.Where(l => l.paciente.ToLower().Contains(this.Filter.ToLower()) ||
                                                   l.profesional.ToLower().Contains(this.Filter.ToLower()) ||
                                                   l.practica.ToLower().Contains(this.Filter.ToLower())));
            }
            #endregion
        }
    }
}
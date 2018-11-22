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
    public class AlumnosViewModel : BaseViewModel
    {
        #region Services

        private ApiService _apiService;

        #endregion

        #region Attributes

        private List<Alumno> AlumnoList;
        private List<AlumnoItemViewModel> AlumnoVMList;
        private ObservableCollection<AlumnoItemViewModel> alumnos;
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

        public ObservableCollection<AlumnoItemViewModel> Alumnos
        {
            get => this.alumnos;
            set => SetProperty(ref this.alumnos, value);
        }

        #endregion

        #region Constructors

        public AlumnosViewModel()
        {
            this._apiService = new ApiService();
            this.LoadAlumnos();
        }

        #endregion

        #region Methods

        private async void LoadAlumnos()
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

            var response = await this._apiService.GetList<Alumno>(
                $"{App.UrlServer}",
                "/api",
                "/AlumnosMobile");

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

            this.AlumnoList = (List<Alumno>)response.Result;
            ToAlumnoItemViewModel();
            this.Alumnos = new ObservableCollection<AlumnoItemViewModel>(
                AlumnoVMList);
            this.IsRefreshing = false;
        }

        private void ToAlumnoItemViewModel()
        {
            AlumnoVMList = AutoMapper.Mapper.Map<List<AlumnoItemViewModel>>(AlumnoList);
        }

        #endregion

        #region Commands

        public ICommand RefreshCommand => new RelayCommand(LoadAlumnos);

        public ICommand SearchCommand => new RelayCommand(Search);

        private void Search()
        {
            if (string.IsNullOrEmpty(this.Filter))
            {
                this.Alumnos = new ObservableCollection<AlumnoItemViewModel>(AlumnoVMList);
            }
            else
            {
                try
                {
                    var dni = 0;

                    if (Filter.Length == 8)
                    {
                        int.TryParse(Filter, out dni);
                    }

                    this.Alumnos = new ObservableCollection<AlumnoItemViewModel>(
                        AlumnoVMList.Where(l => l.perNombre.ToLower().Contains(this.Filter.ToLower()) ||
                                                  l.perApellido.ToLower().Contains(this.Filter.ToLower())
                                                  || l.perDni == dni));
                }
                catch
                {
                    return;
                }

            }
        }

        #endregion
    }
}

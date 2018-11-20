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

    public class EmpleadosViewModel : BaseViewModel
    {
        #region Services

        private ApiService _apiService;

        #endregion

        #region Attributes

        private List<Empleado> empleadoList;
        private List<EmpleadoItemViewModel> empleadoVMList;
        private ObservableCollection<EmpleadoItemViewModel> empleados;
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

        public ObservableCollection<EmpleadoItemViewModel> Empleados
        {
            get => this.empleados;
            set => SetProperty(ref this.empleados, value);
        }

        #endregion

        #region Constructors

        public EmpleadosViewModel()
        {
            this._apiService = new ApiService();
            this.LoadEmpleados();
        }

        #endregion

        #region Methods

        private async void LoadEmpleados()
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

            var response = await this._apiService.GetList<Empleado>(
                $"{App.UrlServer}",
                "/api",
                "/EmpleadosMobile");

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

            this.empleadoList = (List<Empleado>)response.Result;
            ToempleadoItemViewModel();
            this.Empleados = new ObservableCollection<EmpleadoItemViewModel>(
                empleadoVMList);
            this.IsRefreshing = false;
        }

        private void ToempleadoItemViewModel()
        {
            empleadoVMList = AutoMapper.Mapper.Map<List<EmpleadoItemViewModel>>(empleadoList);
        }

        #endregion

        #region Commands

        public ICommand RefreshCommand => new RelayCommand(LoadEmpleados);

        public ICommand SearchCommand => new RelayCommand(Search);

        private void Search()
        {
            if (string.IsNullOrEmpty(this.Filter))
            {
                this.Empleados = new ObservableCollection<EmpleadoItemViewModel>(empleadoVMList);
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

                    this.Empleados = new ObservableCollection<EmpleadoItemViewModel>(
                        empleadoVMList.Where(l => l.perNombre.ToLower().Contains(this.Filter.ToLower()) ||
                                                  l.perApellido.ToLower().Contains(this.Filter.ToLower())
                                                  || l.empCargo.ToLower().Contains(this.Filter.ToLower())
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

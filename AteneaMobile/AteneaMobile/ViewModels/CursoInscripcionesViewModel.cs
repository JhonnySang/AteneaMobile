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
    public class CursoInscripcionsViewModel : BaseViewModel
    {
        #region Services

        private ApiService _apiService;

        #endregion

        #region Attributes

        private List<CursoInscripcion> CursoInscripcionList;
        private List<CursoInscripcionItemViewModel> CursoInscripcionVMList;
        private ObservableCollection<CursoInscripcionItemViewModel> cursoInscripcions;
        private bool isRefreshing;
        private string filter;

        #endregion

        #region Properties

        public int CursoSelect { get; set; }

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

        public ObservableCollection<CursoInscripcionItemViewModel> CursoInscripcions
        {
            get => this.cursoInscripcions;
            set => SetProperty(ref this.cursoInscripcions, value);
        }

        #endregion

        #region Constructors

        public CursoInscripcionsViewModel(int curCod)
        {
            this.CursoSelect = curCod;
            this._apiService = new ApiService();
            this.LoadCursoInscripcions();
        }

        #endregion

        #region Methods

        private async void LoadCursoInscripcions()
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

            var response = await this._apiService.GetList<CursoInscripcion>(
                $"{App.UrlServer}",
                "/api",
                $"/CursosMobile/{CursoSelect}");

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

            this.CursoInscripcionList = (List<CursoInscripcion>)response.Result;
            ToCursoInscripcionItemViewModel();
            this.CursoInscripcions = new ObservableCollection<CursoInscripcionItemViewModel>(
                CursoInscripcionVMList);
            this.IsRefreshing = false;
        }

        private void ToCursoInscripcionItemViewModel()
        {
            CursoInscripcionVMList = AutoMapper.Mapper.Map<List<CursoInscripcionItemViewModel>>(CursoInscripcionList);
        }

        #endregion

        #region Commands

        public ICommand RefreshCommand => new RelayCommand(LoadCursoInscripcions);

        public ICommand SearchCommand => new RelayCommand(Search);

        private void Search()
        {
            if (string.IsNullOrEmpty(this.Filter))
            {
                this.CursoInscripcions = new ObservableCollection<CursoInscripcionItemViewModel>(CursoInscripcionVMList);
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

                    this.CursoInscripcions = new ObservableCollection<CursoInscripcionItemViewModel>(
                        CursoInscripcionVMList.Where(l => l.alumnoApyNom.ToLower().Contains(this.Filter.ToLower())));
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

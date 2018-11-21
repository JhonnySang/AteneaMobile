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
    public class CursosViewModel : BaseViewModel
    {
        #region Services

        private ApiService _apiService;

        #endregion

        #region Attributes

        private List<Curso> CursoList;
        private List<CursoItemViewModel> CursoViewModelsList;
        private ObservableCollection<CursoItemViewModel> cursos;
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

        public ObservableCollection<CursoItemViewModel> Cursos
        {
            get => this.cursos;
            set => SetProperty(ref this.cursos, value);
        }

        #endregion

        #region Constructors

        public CursosViewModel()
        {
            this._apiService = new ApiService();
            this.LoadCursos();
        }

        #endregion

        #region Methods

        private async void LoadCursos()
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

            var response = await this._apiService.GetList<Curso>(
                $"{App.UrlServer}",
                "/api",
                "/CursosMobile");

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

            this.CursoList = (List<Curso>) response.Result;
            ToCursoItemViewModel();
            this.Cursos = new ObservableCollection<CursoItemViewModel>(
                CursoViewModelsList);
            this.IsRefreshing = false;
        }

        private void ToCursoItemViewModel()
        {
            CursoViewModelsList = AutoMapper.Mapper.Map<List<CursoItemViewModel>>(CursoList);
        }

        #endregion

        #region Commands

        public ICommand RefreshCommand => new RelayCommand(LoadCursos);

        public ICommand SearchCommand => new RelayCommand(Search);

        private void Search()
        {
            if (string.IsNullOrEmpty(this.Filter))
            {
                this.Cursos = new ObservableCollection<CursoItemViewModel>(CursoViewModelsList);
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

                    this.Cursos = new ObservableCollection<CursoItemViewModel>(
                        CursoViewModelsList.Where(l => l.curDescripcion.ToLower().Contains(this.Filter.ToLower())));
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

using System;
using System.Windows.Input;
using AteneaMobile.Models;
using AteneaMobile.Services;
using AteneaMobile.Views;
using GalaSoft.MvvmLight.Command;
using Xamarin.Forms;

namespace AteneaMobile.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        #region Services

        private ApiService _apiService;
        private NavigationService _navigationService;

        #endregion

        #region Atributes

        private string usuario;
        private string password;
        private bool isRunnig;
        private bool recordarPassword;
        private bool isEnabled;

        #endregion

        #region Properties

        public string Usuario
        {
            get => usuario;
            set => SetProperty(ref usuario, value);
        }

        public string Password
        {
            get => password;
            set => SetProperty(ref password, value);
        }

        public bool IsRunning
        {
            get => isRunnig;
            set => SetProperty(ref isRunnig, value);
        }

        public bool RecordarPassword
        {
            get => recordarPassword;
            set => SetProperty(ref recordarPassword, value);
        }

        public bool IsEnabled
        {
            get => isEnabled;
            set => SetProperty(ref isEnabled, value);
        }

        #endregion

        #region Commands

        public ICommand LoginCommand => new RelayCommand(Login);

        private async void Login()
        {
            var connection = await this._apiService.CheckConnection();

            if (!connection.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    connection.Message,
                    "Accept");
                await Application.Current.MainPage.Navigation.PopAsync();
                return;
            }

            if (string.IsNullOrEmpty(this.Usuario))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Debes ingresar un Usuario", "Ok");
                return;
            }

            if (string.IsNullOrEmpty(this.Password))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Debes ingresar un Password", "Ok");
                return;
            }

            this.IsRunning = true;
            this.IsEnabled = false;

            var usuarioLogin = new Usuario
            {
                UsuLog = this.Usuario,
                UsuPass = this.Password
            };

            var response = await _apiService.PostLogin($"{App.UrlServer}", "/api", "/ApiLogin", usuarioLogin);

            if (!response.IsSuccess)
            {
                //this.IsRunning = false;
                //this.IsEnabled = true;
                //await Application.Current.MainPage.DisplayAlert("Error", "Usuario o Password Incorrecto", "Ok");
                //this.Password = string.Empty;
                //return;
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    response.Message,
                    "Accept");
                //await Application.Current.MainPage.Navigation.PopAsync();
                await _navigationService.Back();
                return;
            }

            this.IsRunning = false;
            this.IsEnabled = true;


            var grupoUsuario = (Grupo)response.Result;

            App.PerfilUsuario = grupoUsuario.GruDescripcion;

            var mainViewModel = MainViewModel.GetInstance();
            mainViewModel.Pacientes = new PacientesViewModel();// antes de cargar la viewPacientes, la ligo a la mainViewModel
            await Application.Current.MainPage.Navigation.PushModalAsync(new MainPage());
            //await _navigationService.Navigate("MainPage"); // Aqui trabaja sin saber cual es la interfaz del usuario
        }

        #endregion

        #region Constructors

        public LoginViewModel()
        {
            _navigationService = new NavigationService();
            this.RecordarPassword = true;
            this.IsEnabled = true;
            _apiService = new ApiService();
            this.Usuario = "admin";
            this.Password = "admin123";
        }

        #endregion

    }
}

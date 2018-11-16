using System;
using AteneaMobile.Models;
using AteneaMobile.Services;
using AteneaMobile.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace AteneaMobile
{
    public partial class App : Application
    {
        public static string UrlServer = "http://192.168.184.2:8080";

        public static string PerfilUsuario = "";

        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();

            MappingConfig.RegisterMaps();

            MainPage = new LoginPage();
            //MainPage = new NavigationPage(new LoginPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}

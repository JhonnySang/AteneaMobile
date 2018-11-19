using AteneaMobile.Views;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AteneaMobile.Services
{
    public class NavigationService
    {
        public void SetMainPage(string pageName)
        {
            switch (pageName)
            {
                case "LoginPage":
                    Application.Current.MainPage = new NavigationPage(new LoginPage());
                    break;
                case "MainPage":
                    Application.Current.MainPage = new MainPage();
                    break;
            }
        }

        public async Task NavigateOnMaster(string pageName)
        {
            App.Master.IsPresented = false;//para q se oculte cada vez q elijo una opcion

            switch (pageName)
            {
                case "MainPage":
                    await Application.Current.MainPage.Navigation.PushAsync(new MainPage());
                    break;
                case "PacientesPage":
                    await Application.Current.MainPage.Navigation.PushAsync(new PacientesPage());
                    break;
                case "EmpleadosPage":
                    await Application.Current.MainPage.Navigation.PushAsync(new EmpleadosPage());
                    break;
                case "HomePage":
                    await Application.Current.MainPage.Navigation.PushAsync(new HomePage());
                    break;
            }
        }

        //public async Task NavigateOnLogin(string pageName)
        //{
        //    switch (@pageName)
        //    {
        //        case "NewCustomerView":
        //            await Application.Current.MainPage.Navigation.PushAsync(new NewCustomerView());
        //            break;
        //    }
        //}


        public async Task BackOnMaster()
        {
            await App.Navigator.PopAsync();
        }
        public async Task BackOnLogin()
        {
            await Application.Current.MainPage.Navigation.PopAsync();
        }
    }
}

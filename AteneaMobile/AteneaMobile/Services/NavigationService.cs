using AteneaMobile.Views;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AteneaMobile.Services
{
    public class NavigationService
    {
        public async Task Navigate(string pageName)
        {
            switch (@pageName)
            {
                case "MainPage":
                    await Application.Current.MainPage.Navigation.PushAsync(new MainPage());
                    break;
                case "PacientesPage":
                    await Application.Current.MainPage.Navigation.PushAsync(new PacientesPage());
                    break;
            }
        }
    }
}

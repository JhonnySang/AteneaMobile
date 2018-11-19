using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using AteneaMobile.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AteneaMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : MasterDetailPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            App.Navigator = Navigator;
            App.Master = this;
        }
    }
}

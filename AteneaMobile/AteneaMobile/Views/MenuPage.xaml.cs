using System.Collections.Generic;
using AteneaMobile.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AteneaMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPage : ContentPage
    {
        AteneaMobile.Views.MainPage RootPage
        {
            get => Application.Current.MainPage as AteneaMobile.Views.MainPage;
        }

        List<HomeMenuItem> menuItems;

        public MenuPage()
        {
            InitializeComponent();

            menuItems = new List<HomeMenuItem>
            {
                new HomeMenuItem {Id = MenuItemType.ConsultarPaciente, Title = "Consultar Paciente"},
                new HomeMenuItem {Id = MenuItemType.Salir, Title = "Salir"}
            };

            ListViewMenu.ItemsSource = menuItems;

            ListViewMenu.SelectedItem = menuItems[0];
            ListViewMenu.ItemSelected += async (sender, e) =>
            {
                if (e.SelectedItem == null)
                    return;

                var id = (int) ((HomeMenuItem) e.SelectedItem).Id;
                await RootPage.NavigateFromMenu(id);
            };

        }
    }
}
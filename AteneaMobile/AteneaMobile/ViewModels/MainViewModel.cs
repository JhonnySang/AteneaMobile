﻿using System.Collections.ObjectModel;
using AteneaMobile.Models;

namespace AteneaMobile.ViewModels
{
    public class MainViewModel
    {
        #region ViewModels
        public ObservableCollection<Menu> MyMenu { get; set; }

        public LoginViewModel Login { get; set; }

        public PacientesViewModel Pacientes { get; set; }

        public PacienteViewModel Paciente { get; set; }

        #endregion

        #region Constructors

        public MainViewModel()
        {
            instance = this;
            this.Login = new LoginViewModel();
            LoadMenu();
        }

        #region Methods

        private void LoadMenu()
        {
            MyMenu = new ObservableCollection<Menu>
            {
                new Menu
                {
                    Icon = "paciente",
                    PageName = "Consultar Paciente",
                    Title = "Pacientes"
                },
                new Menu
                {
                    Icon = "setting",
                    PageName = "Configuracion",
                    Title = "Configuracion"
                },
                new Menu
                {
                    Icon = "ic_launcher",
                    PageName = "Salir",
                    Title = "Salir"
                }
            };
        }

        #endregion

        #endregion

        #region Singleton
        // vamos a poder llamar la pagina principal desde cualquier clase sin necesidad de tener q instanciarla
        private static MainViewModel instance;

        public static MainViewModel GetInstance()
        {
            if (instance==null)
            {
                return new MainViewModel();
            }

            return instance;
        }

        #endregion
    }
}

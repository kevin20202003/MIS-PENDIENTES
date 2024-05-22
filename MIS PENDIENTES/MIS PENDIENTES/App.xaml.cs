using MIS_PENDIENTES.Controller;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MIS_PENDIENTES
{
    public partial class App : Application
    {
        static TareasDatabase database;

        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new MainPage());
        }

        public static TareasDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new TareasDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Tareas.db3"));
                }
                return database;
            }
        }

        protected override void OnStart() { }

        protected override void OnSleep() { }

        protected override void OnResume() { }
    }
}

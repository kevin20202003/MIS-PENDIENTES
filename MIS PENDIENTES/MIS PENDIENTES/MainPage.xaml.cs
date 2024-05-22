using MIS_PENDIENTES.Models;
using MIS_PENDIENTES.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MIS_PENDIENTES
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            TareasListView.ItemsSource = await App.Database.GetTareasAsync();
        }

        async void OnAgregarTareaClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AgregarTareaPage
            {
                BindingContext = new Tarea()
            });
        }

        async void OnTareaSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new AgregarTareaPage
                {
                    BindingContext = e.SelectedItem as Tarea
                });
            }
        }
    }
}
using MIS_PENDIENTES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MIS_PENDIENTES.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AgregarTareaPage : ContentPage
    {
        public AgregarTareaPage()
        {
            InitializeComponent();
        }

        async void OnGuardarClicked(object sender, EventArgs e)
        {
            var tarea = (Tarea)BindingContext;
            await App.Database.SaveTareaAsync(tarea);
            await Navigation.PopAsync();
        }

        async void OnEliminarClicked(object sender, EventArgs e)
        {
            bool isConfirmed = await DisplayAlert("Confirmación", "¿Está seguro de eliminar el elemento?", "Aceptar", "Cancelar");
            if (isConfirmed)
            {
                var tarea = (Tarea)BindingContext;
                await App.Database.DeleteTareaAsync(tarea);
                await Navigation.PopAsync();
            }
        }
    }
}
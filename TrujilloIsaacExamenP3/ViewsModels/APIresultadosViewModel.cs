using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrujilloIsaacExamenP3.ViewsModels
{
    public class APIresultadosViewModel
    {
        public int IdBusqueda { get; set; }

        public string Nombreoficial { get; set; }

        public string Región { get; set; }

        public string LinkGoogle { get; set; }
    }
    /*
    public APIresultadosViewModel()
    {
        RegistrarBusquedaCommand = new Command(RegistrarBusqueda);
    }

    private async void RegistrarBusqueda()
    {
        var usuario = new Models.Mapa
        {
            Nombreoficial = this Nombreoficial,
            Región = this.Correo,
            LinkGoogle = this.FechaNacimiento
        };

        await App.Database.SaveVendedorAsync(usuario);
        await App.Current.MainPage.DisplayAlert("Éxito", "Usuario registrado correctamente.", "OK");
    }*/
}

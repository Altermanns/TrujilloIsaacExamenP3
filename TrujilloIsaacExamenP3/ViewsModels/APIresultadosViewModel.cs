using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using SQLite;
using TrujilloIsaacExamenP3.Models;

namespace TrujilloIsaacExamenP3.ViewsModels
{
    public class APIresultadosViewModel : INotifyPropertyChanged
    {
        private string _nombre;
        public string Nombre
        {
            get => _nombre;
            set
            {
                if (_nombre != value)
                {
                    _nombre = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand BuscarCommand { get; }
        public ICommand LimpiarCommand { get; }

        public event PropertyChangedEventHandler PropertyChanged;

        public APIresultadosViewModel()
        {
            BuscarCommand = new Command(async () => await BuscarPaisAsync());
            LimpiarCommand = new Command(() => Nombre = string.Empty);
        }

        private async Task BuscarPaisAsync()
        {
            if (string.IsNullOrWhiteSpace(Nombre))
            {
                await App.Current.MainPage.DisplayAlert("Error", "Ingresa un nombre de país.", "OK");
                return;
            }

            try
            {
                using var httpClient = new HttpClient();
                var url = $"https://restcountries.com/v3.1/name/{Nombre}?fields=name,region,maps";
                var resultado = await httpClient.GetFromJsonAsync<List<dynamic>>(url);

                if (resultado != null && resultado.Any())
                {
                    var pais = resultado.First();
                    var nuevoPais = new Mapa
                    {
                        Nombreoficial = pais.name.common,
                        Región = pais.region,
                        LinkGoogle = pais.maps.googleMaps,
                        NombreEstu = "ITrujillo"
                    };

                    // Guarda el nuevo país en la base de datos
                    await App.Database.InsertAsync(nuevoPais);
                    await App.Current.MainPage.DisplayAlert("Éxito", "País guardado correctamente.", "OK");
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Error", "No se encontró el país.", "OK");
                }
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
        }


        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}


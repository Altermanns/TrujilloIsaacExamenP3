using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TrujilloIsaacExamenP3.Models;

namespace TrujilloIsaacExamenP3.ViewsModels
{
    public class ListaViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<string> _paises;
        public ObservableCollection<string> Paises
        {
            get => _paises;
            set
            {
                if (_paises != value)
                {
                    _paises = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand CargarPaisesCommand { get; }

        public event PropertyChangedEventHandler PropertyChanged;

        public ListaViewModel()
        {
            Paises = new ObservableCollection<string>();
            CargarPaisesCommand = new Command(async () => await CargarPaisesAsync());
        }

        private async Task CargarPaisesAsync()
        {
            Paises.Clear();

            // Obtén todos los registros de la tabla `Mapa`
            var paises = await App.Database.Table<Mapa>().ToListAsync();

            foreach (var pais in paises)
            {
                Paises.Add($"Nombre País: {pais.Nombreoficial}, Región: {pais.Región}, Link: {pais.LinkGoogle}, NombreBD: {pais.NombreEstu}");
            }
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

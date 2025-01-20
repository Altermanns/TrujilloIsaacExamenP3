
using SQLite;

namespace TrujilloIsaacExamenP3.Models
{
    public class Mapa
    {
        [PrimaryKey, AutoIncrement]
        public int IdBusqueda { get; set; }

        public string Nombreoficial  { get; set; }

        public string Región { get; set; }

        public string LinkGoogle { get; set; }

        public string NombreEstu { get; set; }
    }
}

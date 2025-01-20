using SQLite;
using TrujilloIsaacExamenP3.Models;

namespace TrujilloIsaacExamenP3
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }

        public static SQLiteAsyncConnection Database;

        protected override void OnStart()
        {
            var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Trujillo.db3");
            Database = new SQLiteAsyncConnection(dbPath);
            Database.CreateTableAsync<Mapa>().Wait();
        }

    }
}

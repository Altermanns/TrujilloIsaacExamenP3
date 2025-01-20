using TrujilloIsaacExamenP3.ViewsModels;
namespace TrujilloIsaacExamenP3
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new APIresultadosViewModel();
        }
    }
}

using TrujilloIsaacExamenP3.ViewsModels;
namespace TrujilloIsaacExamenP3;

public partial class BuscarPais : ContentPage
{
	public BuscarPais()
	{
		InitializeComponent();
        BindingContext = new APIresultadosViewModel();

    }
}
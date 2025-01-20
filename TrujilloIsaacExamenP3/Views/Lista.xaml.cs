using TrujilloIsaacExamenP3.ViewsModels;

namespace TrujilloIsaacExamenP3;

public partial class Lista : ContentPage
{
    public Lista()
    {
        InitializeComponent();
        BindingContext = new ListaViewModel(); 
    }
}
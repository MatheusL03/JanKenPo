using MauiApp1.ViewModels;

namespace MauiApp1.View;

public partial class JankepoView : ContentPage
{
	public JankepoView()
	{
		BindingContext = new JankepoViewModel();

        InitializeComponent();
	}
}
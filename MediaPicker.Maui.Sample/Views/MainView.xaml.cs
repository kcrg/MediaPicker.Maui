using MediaPicker.Maui.Sample.ViewModels;

namespace MediaPicker.Maui.Sample.Views;

public partial class MainView : ContentPage
{
	public MainView(MainViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
	}
}
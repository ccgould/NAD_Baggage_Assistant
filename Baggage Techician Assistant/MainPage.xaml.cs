using Baggage_Technician_Assistant.Services;
using Baggage_Technician_Assistant.ViewModels;

namespace Baggage_Technician_Assistant;

public partial class MainPage : ContentPage
{

	public MainPage(MainPageViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
    }
}


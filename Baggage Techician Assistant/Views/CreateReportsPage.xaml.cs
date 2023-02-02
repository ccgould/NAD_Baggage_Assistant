using Baggage_Technician_Assistant.ViewModels;

namespace Baggage_Technician_Assistant.Views;

public partial class CreateReportsPage : ContentPage
{
	public CreateReportsPage(CreateReportsPageViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
    }
}
using Baggage_Technician_Assistant.ViewModels;

namespace Baggage_Technician_Assistant.Views;

public partial class SettingsPage : ContentPage
{
	public SettingsPage(SettingsPageViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}
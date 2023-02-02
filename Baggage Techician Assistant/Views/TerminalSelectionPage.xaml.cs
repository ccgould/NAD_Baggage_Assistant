using Baggage_Technician_Assistant.ViewModels;

namespace Baggage_Technician_Assistant.Views;

public partial class TerminalSelectionPage : ContentPage
{
	public TerminalSelectionPage(TerminalSelectionPageViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
    }
}
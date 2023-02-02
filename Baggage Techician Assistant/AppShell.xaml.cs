using Baggage_Technician_Assistant.Views;

namespace Baggage_Technician_Assistant;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute(nameof(TerminalSelectionPage),typeof(TerminalSelectionPage));
        Routing.RegisterRoute(nameof(TerminalPage), typeof(TerminalPage));
        Routing.RegisterRoute(nameof(CounterDetailsPage), typeof(CounterDetailsPage));
        Routing.RegisterRoute(nameof(ReportsPage), typeof(ReportsPage));
        Routing.RegisterRoute(nameof(CreateReportsPage), typeof(CreateReportsPage));
        Routing.RegisterRoute(nameof(BarcodeGenPage), typeof(BarcodeGenPage));
    }
}

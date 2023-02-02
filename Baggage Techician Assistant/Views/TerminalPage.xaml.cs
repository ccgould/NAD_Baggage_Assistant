using Baggage_Technician_Assistant.Services;
using Baggage_Technician_Assistant.ViewModels;

namespace Baggage_Technician_Assistant.Views;

public partial class TerminalPage : ContentPage
{
    private TerminalPageViewModel _viewModel;
    private TerminalService _service;

    public TerminalPage(TerminalService service, TerminalPageViewModel viewModel)
    {
		InitializeComponent();
        BindingContext = _viewModel = viewModel;
        _service = service;
    }

    protected async override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        await _service.Init();

        // Hack: Get the category Id
        _viewModel.Terminal = TerminalService.CurrentTerminal = GetCategoryIdFromRoute();

        _viewModel.GetCounters();

        base.OnNavigatedTo(args);

    }

    protected override void OnNavigatingFrom(NavigatingFromEventArgs args)
    {
        TerminalService.CurrentTerminal = string.Empty;
        base.OnNavigatingFrom(args);
    }

    private string GetCategoryIdFromRoute()
    {
        // Hack: As the shell can't define query parameters
        // in XAML, we have to parse the route. 
        // as a convention the last route section defines the category.
        // ugly but works for now :-(
        return Shell.Current.CurrentState.Location.OriginalString.LastOrDefault().ToString();
        
    }
}
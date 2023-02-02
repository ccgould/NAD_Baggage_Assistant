using Baggage_Technician_Assistant.Services;
using Baggage_Technician_Assistant.ViewModels;

namespace Baggage_Technician_Assistant.Views;

public partial class RandomGeneratorPage : ContentPage
{
    private RandomGeneratorPageViewModel _vm;
    private TerminalService _service;

    public RandomGeneratorPage(TerminalService service, RandomGeneratorPageViewModel vm)
	{
		InitializeComponent();
        BindingContext = _vm = vm;
        _service = service;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
    }

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        _vm.SetData();
        base.OnNavigatedTo(args);
    }
}
using Baggage_Technician_Assistant.Services;
using Baggage_Technician_Assistant.ViewModels;

namespace Baggage_Technician_Assistant.Views;

public partial class CounterDetailsPage : ContentPage
{
    private CounterDetailsPageViewModel _vm;

    public CounterDetailsPage(CounterDetailsPageViewModel vm)
	{
		InitializeComponent();
        BindingContext = _vm = vm;
    }

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        _vm.GetDetails();
        base.OnNavigatedTo(args);
    }
}
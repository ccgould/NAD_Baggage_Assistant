using Baggage_Technician_Assistant.ViewModels;

namespace Baggage_Technician_Assistant.Views;

public partial class BarcodeGenPage : ContentPage
{
    private readonly BarcodeGenPageViewModel _vm;

    public BarcodeGenPage(BarcodeGenPageViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
        _vm = vm;
    }

    private void InputView_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        string text = ((Entry)sender).Text;

        if (text.Length % 2 != 0)
        {

        }
    }
}
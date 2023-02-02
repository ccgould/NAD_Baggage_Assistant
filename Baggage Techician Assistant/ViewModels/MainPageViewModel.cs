using Baggage_Technician_Assistant.Services;
using Baggage_Technician_Assistant.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Baggage_Technician_Assistant.ViewModels
{
    public partial class MainPageViewModel : ObservableObject
    {
        private readonly TerminalService _service;

        public MainPageViewModel(TerminalService service)
        {
            _service = service;
        }

        [RelayCommand]
        async Task GoToTerminal()
        {
            await _service.Init();
            await Shell.Current.GoToAsync(nameof(TerminalSelectionPage));
        }
        
        [RelayCommand]
        async Task GoToReportsPage()
        {
            await _service.Init();
            await Shell.Current.GoToAsync(nameof(ReportsPage));
        }

        [RelayCommand]
        async Task GoToBarcodeGenPage()
        {
            await _service.Init();
            await Shell.Current.GoToAsync(nameof(BarcodeGenPage));
        }
    }
}

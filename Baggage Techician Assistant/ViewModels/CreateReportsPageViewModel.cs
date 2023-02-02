using Baggage_Technician_Assistant.Models;
using Baggage_Technician_Assistant.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Baggage_Technician_Assistant.ViewModels
{

    [QueryProperty("Counter", "Counter")]
    public partial class CreateReportsPageViewModel : ObservableObject
    {
        [ObservableProperty] Counter counter;
        [ObservableProperty] string title;
        [ObservableProperty] string message;
        public CreateReportsPageViewModel()
        {
            
        }

        [RelayCommand]
        private async Task  Submit()
        {
            TerminalService.main.AddReport(Counter, new Report
            {
                Terminal = Counter.Terminal,
                Title = title,
                Date =  DateTime.Now.ToShortDateString(),
                Time= DateTime.Now.ToShortTimeString(),
                Counter = Counter.CounterNumber,
                ReportDetails = message,
                IsCameraWorking= false,
                IsScaleWorking= false,
                IsScannerWorking=false,
                IsTabletWorking=false,
            });

            await Shell.Current.GoToAsync("..");
        }
    }
}

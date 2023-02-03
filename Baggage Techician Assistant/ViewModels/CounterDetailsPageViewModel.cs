using Baggage_Technician_Assistant.Models;
using Baggage_Technician_Assistant.Services;
using Baggage_Technician_Assistant.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using CommunityToolkit.Maui.Views;

namespace Baggage_Technician_Assistant.ViewModels
{
    [QueryProperty("Counter", "Counter")]
    [QueryProperty("Counters", "Counters")]
    public partial class CounterDetailsPageViewModel : ObservableObject
    {

        [ObservableProperty] int reportCount;
        [ObservableProperty] Counter counter;
        [ObservableProperty] ObservableCollection<Counter> counters;

        public CounterDetailsPageViewModel()
        {

        }

        internal void GetDetails()
        {
            ReportCount = TerminalService.main.GetReportCount(counter);
        }


        [RelayCommand]
        async Task AddReport()
        {
            var result = await App.Current.MainPage.ShowPopupAsync(new CreateReportsPage());

            if(result is string[] data)
            {
                TerminalService.main.AddReport(Counter, new Report
                {
                    Terminal = Counter.Terminal,
                    Title = data[0],
                    Date = DateTime.Now.ToShortDateString(),
                    Time = DateTime.Now.ToShortTimeString(),
                    Counter = Counter.CounterNumber,
                    ReportDetails = data[1],
                    IsCameraWorking = false,
                    IsScaleWorking = false,
                    IsScannerWorking = false,
                    IsTabletWorking = false,
                });

                GetDetails();
            }
        }

        [RelayCommand]
        async Task GoToPage(string direction)
        {

            var geth = counters.IndexOf(counter);

            if (direction.Equals("Left"))
            {
                geth += 1;
            }
            else
            {
                geth -= 1;
                if (geth < 0) geth = 0;
            }


            await Shell.Current.GoToAsync(nameof(CounterDetailsPage), new Dictionary<string, object>()
            {
                {"Counter",counters.ElementAt(geth)},
                {"Counters", counters}
            });
        }
    }
}

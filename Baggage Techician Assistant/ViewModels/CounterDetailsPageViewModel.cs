using Baggage_Technician_Assistant.Models;
using Baggage_Technician_Assistant.Services;
using Baggage_Technician_Assistant.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

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
            await Shell.Current.GoToAsync(nameof(CreateReportsPage), new Dictionary<string, object>()
            {
                {"Counter",counter}
            });
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

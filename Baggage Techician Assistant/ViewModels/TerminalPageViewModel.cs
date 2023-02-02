using System.Collections.ObjectModel;
using System.Net.Security;
using Baggage_Technician_Assistant.Models;
using Baggage_Technician_Assistant.Services;
using Baggage_Technician_Assistant.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Baggage_Technician_Assistant.ViewModels
{
    [QueryProperty("Terminal","Terminal")]
    public partial class TerminalPageViewModel : ObservableObject
    {
        [ObservableProperty]
        string terminal;

        [ObservableProperty]
        private ObservableCollection<Counter> counters = new();

        [ObservableProperty] int countersAmount;
        [ObservableProperty] int reportsAmount;

        private readonly TerminalService _service;

        public TerminalPageViewModel(TerminalService service)
        {
            _service = service;
        }

        public void GetCounters()
        {
           var counters = _service.GetCounters(Terminal);
            
            Counters.Clear();

            if (counters is not null)
            {
                

                foreach (Counter counter in counters)
                {
                    Counters.Add(counter);
                }
            }

            CountersAmount = counters?.Count() ?? 0;
            ReportsAmount = TerminalService.main.GetReportCount(Terminal);
        }

        [RelayCommand]
        async Task GoToDetailsPage(Counter counter)
        {
            await Shell.Current.GoToAsync(nameof(CounterDetailsPage), new Dictionary<string, object>
            {
                {"Counter",counter},
                {"Counters", counters}
            });
        }
    }
}

using Baggage_Technician_Assistant.Models;
using Baggage_Technician_Assistant.Services;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Baggage_Technician_Assistant.ViewModels
{
    [QueryProperty("Counter","Counter")]

    public partial class ReportsPageViewModel : ObservableObject
    {
        [ObservableProperty] Counter counter;

        private List<Report> GetReports()
        {
            if (string.IsNullOrWhiteSpace(TerminalService.CurrentTerminal))
            {
                return TerminalService.main.Reports.ToList();
            }
            else
            {
                return TerminalService.main.Reports.Where(x => x.Terminal.Equals(TerminalService.CurrentTerminal, StringComparison.OrdinalIgnoreCase)).ToList();
            }
        }

        public ReportsPageViewModel()
        {

        }
    }
}

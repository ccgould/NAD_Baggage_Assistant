using System.Collections.ObjectModel;
using Baggage_Technician_Assistant.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Baggage_Technician_Assistant.ViewModels;
    public partial class TerminalSelectionPageViewModel : ObservableObject
    {
        public TerminalSelectionPageViewModel()
        {
            
        }


        [ObservableProperty]
        ObservableCollection<string> items;

        [ObservableProperty]
        string terminal;

        [RelayCommand]
        async Task ShowDetails(string terminal)
        {
            await Shell.Current.GoToAsync(nameof(TerminalPage),
                new Dictionary<string, object>
                {
                    {"Terminal", terminal}
                });
        }
    }

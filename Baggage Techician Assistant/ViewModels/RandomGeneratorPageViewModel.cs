using Baggage_Technician_Assistant.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Baggage_Technician_Assistant.ViewModels
{
    public partial class RandomGeneratorPageViewModel : ObservableObject
    {
        [ObservableProperty] string pdf417;
        [ObservableProperty] string itf;
        

        public RandomGeneratorPageViewModel()
        {
            
        }


        [RelayCommand]
        internal void SetData()
        {
            var data = TerminalService.main.GenerateRandom();

            Pdf417 = data.Item2;
            Itf = data.Item1;
        }
    }
}

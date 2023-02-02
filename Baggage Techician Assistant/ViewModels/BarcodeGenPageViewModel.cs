using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Baggage_Technician_Assistant.ViewModels
{
    public partial class BarcodeGenPageViewModel : ObservableObject
    {
        [ObservableProperty]
        private string barcode = "0000000000";

        [ObservableProperty]
        private string text;
        public BarcodeGenPageViewModel()
        {
            
        }

        [RelayCommand]
        void GeneratePressed()
        {

            if (string.IsNullOrWhiteSpace(text)) return;

            if (text.Length % 2 == 0)
            {
                Barcode = text;
            }
            else
            {
                Barcode = "0000000000";
            }
        }


    }
}

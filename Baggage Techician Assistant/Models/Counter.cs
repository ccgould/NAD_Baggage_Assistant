using System.Collections.ObjectModel;
using Baggage_Technician_Assistant.Services;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Baggage_Technician_Assistant.Models
{
    public partial class Counter : ObservableObject
    {
        [ObservableProperty] string terminal;
        [ObservableProperty] int counterNumber;
        [ObservableProperty] string pdf417;
        [ObservableProperty] string itf;


        //[ObservableProperty]
        //[NotifyPropertyChangedFor(nameof(ReportCount))]
        //ObservableCollection<Report> reports = new();
        [ObservableProperty] int reportCount;


        public Counter(string terminal, int counterNumber, string itf, string pdf417)
        {
            this.terminal = terminal;
            this.counterNumber = counterNumber;

            //AddReport(new Report
            //{
            //    Title= "This is a test report",
            //    Date = DateTime.Now.ToShortDateString(),
            //    Time = DateTime.Now.ToShortTimeString(),
            //    Counter = counterNumber,
            //    Terminal = terminal,
            //    IsCameraWorking = true,
            //    IsScaleWorking = true,
            //    IsScannerWorking = true,
            //    IsTabletWorking = false,
            //    ReportDetails = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse ac urna sed sapien egestas malesuada. Fusce nunc ante, ornare vitae rhoncus nec, feugiat nec turpis. Duis porttitor sapien vel urna condimentum, pretium posuere augue pulvinar. Aliquam erat volutpat. Nulla vel metus est. Phasellus quis orci augue. Morbi tempor lorem in bibendum bibendum. Integer sollicitudin et dui nec condimentum. Maecenas pharetra metus mauris. Fusce dignissim gravida ipsum, in imperdiet quam tincidunt consequat. Duis semper porttitor ligula ac volutpat. Donec pharetra ac ligula ut cursus. Integer elementum interdum vulputate. Proin tincidunt metus quis lorem lacinia, lobortis condimentum nibh consequat. Aenean vel eros faucibus, ullamcorper quam elementum, ullamcorper risus. Nullam luctus sem non eleifend congue. "
            //});

            Pdf417 = pdf417;
            Itf = itf;
        }

        public void AddReport(Report report)
        {
            TerminalService.main.AddReport(this,report);
            //reports.Add(report);
        }

   

        public override string ToString()
        {
            return $"{itf} | {pdf417}";
        }

        internal string GetID()
        {
            return terminal + counterNumber;
        }
    }
}

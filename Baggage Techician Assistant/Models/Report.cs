namespace Baggage_Technician_Assistant.Models
{
    public class Report
    {
        public string Terminal { get; set; }
        public string Title { get; set; }
        public string Date { get; set; }
        public int Counter { get; set; }    
        public string ReportDetails { get; set; }
        public bool IsScannerWorking { get; set; }
        public bool IsScaleWorking { get; set; }
        public bool IsTabletWorking { get; set; }
        public bool IsCameraWorking { get; set; }
        public string Time { get; internal set; }
    }
}

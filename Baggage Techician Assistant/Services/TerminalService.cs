using Baggage_Technician_Assistant.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using MvvmHelpers;
using ObservableObject = CommunityToolkit.Mvvm.ComponentModel.ObservableObject;

namespace Baggage_Technician_Assistant.Services
{
    public partial class TerminalService : ObservableObject
    {
        Dictionary<string, List<Counter>> _terminals = new ();
        private Dictionary<string, string> barcodes = new();
        private Dictionary<string, string> randomBarcodes = new();
        [ObservableProperty] public static ObservableRangeCollection<Report> reports = new();
        public ObservableRangeCollection<Grouping<string, Report>> reportGroups { get; set; }
        public Action OnReportAdded { get; internal set; }

        private int _currentIncrement = 1;
        private int usedBarcodeIndex;
        internal static string CurrentTerminal;
        internal static TerminalService main;


        public TerminalService()
        {
            main = this;
        }

        private string[] letters = { "A", "B", "C", "D", "E", "F" };
        private bool _initialized;


        public async Task Init()
        {
            if (_initialized) return;
            await GenerateBarCodes();
            _initialized = true;
        }
        
        private async Task GenerateBarCodes()
        {
            await Task.Run((() =>
            {
                int currentLetterIndex = 0;

                for (int i = 0; i < 300; i++)
                {
                    barcodes.Add(GenerateITF(_currentIncrement), GeneratePDF417(_currentIncrement,letters[currentLetterIndex]));
                    _currentIncrement++;
                    currentLetterIndex++;

                    if (currentLetterIndex > 5)
                    {
                        currentLetterIndex = 0;
                    }
                }

                _terminals.Add("A", GenerateCounters("A", 49));
                _terminals.Add("C", GenerateCounters("C", 54));

            }));
        }

        private List<Counter> GenerateCounters(string terminal, int amount)
        {
            var f = new List<Counter>();

            int index = 0;

            for (int i = 0; i < amount; i++)
            {
                f.Add(new Counter(terminal, index + 1, barcodes.ElementAt(usedBarcodeIndex).Key, barcodes.ElementAt(usedBarcodeIndex).Value));
                usedBarcodeIndex++;
                index++;
            }

            return f;
        }

        private string GeneratePDF417(int currentIncrement,string incrementLetter)
        {
            var incrementNumber = currentIncrement >= 100 ? 2 : 1;
            var value = $"M1TEST PAX {currentIncrement:D3}/ZZ 0{incrementNumber:D3}EZQZ{currentIncrement:D3} NASNASZZ 0{incrementNumber:D3} 987Y001{incrementLetter}0{currentIncrement:D3} 1";
            return value;

        }

        private string GenerateITF(int currentIncrement)
        {
            var current = $"9000100{currentIncrement:D3}";
            return current;
        }

        public List<Counter> GetCounters(string terminal)
        {
            if (string.IsNullOrWhiteSpace(terminal))
            {
                return null;
            }
            return _terminals.ContainsKey(terminal) ? _terminals[terminal] : null;
        }


        public Tuple<string, string> GenerateRandom()
        {
            var itf = GenerateITF(_currentIncrement);
            var pdf = GeneratePDF417(_currentIncrement, "A");
            _currentIncrement++;

            return new Tuple<string, string>(itf, pdf);
        }

        internal void AddReport(Counter counter, Report report)
        {
            if (counter == null) return;

            var id = counter.GetID();

            Reports.Insert(0, report);

            OnReportAdded?.Invoke();
        }

        internal int GetReportCount()
        {
            return reports.Count();
        }

        internal int GetReportCount(string terminal)
        {
            return reports.Count(x=>x.Terminal.Equals(terminal,StringComparison.OrdinalIgnoreCase));
        }

        internal int GetReportCount(Counter counter)
        {
            return reports.Count(x => x.Terminal.Equals(counter.Terminal, StringComparison.OrdinalIgnoreCase) && x.Counter.Equals(counter.CounterNumber));
        }
    }
}

using Baggage_Technician_Assistant.Models;
using Baggage_Technician_Assistant.Services;
using Baggage_Technician_Assistant.ViewModels;
using System.Text;

namespace Baggage_Technician_Assistant.Views;

public partial class ReportsPage : ContentPage
{
    private ReportsPageViewModel _viewModel;
    private StringBuilder _sb = new StringBuilder();
    public ReportsPage(ReportsPageViewModel vm)
	{
		InitializeComponent();
        BindingContext = _viewModel = vm;
    }

    private async void MenuItem_Clicked(object sender, EventArgs e)
    {
        var report = ((MenuItem)sender).BindingContext as Report;
        if (report == null) return;
        bool anwser = await DisplayAlert("Delete Report", report.Title, "Yes","No");
        if(anwser)
        {
            TerminalService.main.Reports.Remove(report);
            await DisplayAlert("Report Deleted", string.Empty, "Ok");
        }
    }

    private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        var report = ((ListView)sender).SelectedItem as Report;
        if (report == null) return;
        _sb.Clear();
        _sb.Append(report.ReportDetails);
        _sb.Append(Environment.NewLine);
        _sb.Append(Environment.NewLine);
        _sb.Append($"Logged on {report.Date} at {report.Time}");


       await DisplayAlert($"Report: {report.Title}", _sb.ToString(), "Ok");
    }

    private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        ((ListView)sender).SelectedItem = null;
    }

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
    }

}
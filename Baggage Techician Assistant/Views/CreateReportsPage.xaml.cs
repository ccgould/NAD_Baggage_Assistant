using Baggage_Technician_Assistant.ViewModels;
using CommunityToolkit.Maui.Views;

namespace Baggage_Technician_Assistant.Views;

public partial class CreateReportsPage : Popup
{
	public CreateReportsPage()
	{
		InitializeComponent();
    }

    private void Submit_Clicked(object sender, EventArgs e)
    {
        this.Close(new[] { TitleTxt.Text, MessageTxt.Text});
    }

    private void Cancel_Clicked(object sender, EventArgs e)
    {
        this.Close();
    }
}
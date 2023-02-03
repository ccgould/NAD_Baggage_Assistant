using Baggage_Technician_Assistant.Services;
using Baggage_Technician_Assistant.ViewModels;
using Baggage_Technician_Assistant.Views;
using ZXing.Net.Maui.Controls;
using CommunityToolkit.Maui;

namespace Baggage_Technician_Assistant;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
            .UseBarcodeReader()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

        var services = builder.Services;


        services.AddSingleton<TerminalService>();

        services.AddSingleton<MainPage>();
        services.AddSingleton<MainPageViewModel>();

        services.AddSingleton<TerminalSelectionPage>();
        services.AddSingleton<TerminalSelectionPageViewModel>();

        services.AddSingleton<RandomGeneratorPage>();
        services.AddSingleton<RandomGeneratorPageViewModel>();

        services.AddTransient<CounterDetailsPage>();
        services.AddTransient<CounterDetailsPageViewModel>();

        services.AddTransient<TerminalPage>();
        services.AddTransient<TerminalPageViewModel>();

        services.AddTransient<ReportsPage>();
        services.AddTransient<ReportsPageViewModel>();

        services.AddTransient<BarcodeGenPage>();
        services.AddTransient<BarcodeGenPageViewModel>();

        services.AddTransient<SettingsPage>();
        services.AddTransient<SettingsPageViewModel>();

        return builder.Build();
	}
}

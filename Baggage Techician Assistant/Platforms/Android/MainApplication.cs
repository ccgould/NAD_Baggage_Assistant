using Android.App;
using Android.Runtime;
using Baggage_Technician_Assistant;

namespace Baggage_Techician_Assistant;

[Application]
public class MainApplication : MauiApplication
{
	public MainApplication(IntPtr handle, JniHandleOwnership ownership)
		: base(handle, ownership)
	{
	}

	protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
}

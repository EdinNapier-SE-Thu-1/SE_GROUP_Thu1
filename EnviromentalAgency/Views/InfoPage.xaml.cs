namespace EnviromentalAgency.Views;

public partial class InfoPage : ContentPage
{
	public InfoPage()
	{
		InitializeComponent();
	}

		private async void LearnMore_Clicked(object sender, EventArgs e)
{
    // Navigate to the specified URL in the system browser.
    await Launcher.Default.OpenAsync("https://aka.ms/maui");
}
}
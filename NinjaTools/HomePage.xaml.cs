using System.Text.Json;

namespace NinjaTools;

public partial class HomePage : ContentPage
{
    private const string RepoApiUrl = "https://api.github.com/repos/ninjaccoio/NinjaTools/releases/latest";
    public HomePage()
	{
		InitializeComponent();
        CheckForUpdate();
    }

    // Azione al clic sul pulsante "Start"
    private void OnStartButtonClicked(object sender, EventArgs e)
    {
        // Apre il FlyoutMenu (menu laterale)
        Shell.Current.FlyoutIsPresented = true;
    }

    private async void CheckForUpdate()
    {
        string currentVersion = "v0.1";

        using var client = new HttpClient();
        client.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0");

        try
        {
            var response = await client.GetStringAsync(RepoApiUrl);
            using var doc = JsonDocument.Parse(response);
            string latestVersion = doc.RootElement.GetProperty("tag_name").GetString();

            if (!string.IsNullOrEmpty(latestVersion) && latestVersion != currentVersion)
            {
                // Mostra il banner di aggiornamento
                MainThread.BeginInvokeOnMainThread(() =>
                {
                    UpdateLabel.Text = $"New version available: {latestVersion}";
                    UpdateBanner.IsVisible = true;
                });
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error checking updates: {ex.Message}");
        }
    }

    private async void OnUpdateButtonClicked(object sender, EventArgs e)
    {
        await Launcher.OpenAsync("https://github.com/ninjaccoio/NinjaTools/releases");
    }
}
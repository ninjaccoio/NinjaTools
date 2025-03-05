namespace NinjaTools
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            // Aggiunta dell'evento per gestire la navigazione
            Navigated += AppShell_Navigated;
        }

        private void AppShell_Navigated(object sender, ShellNavigatedEventArgs e)
        {
            // Aggiorna il titolo del menu con la pagina attiva
            var title = "NinjaTools";

            switch (e.Current.Location.OriginalString)
            {
                case "//HomePage":
                    title += " - Home";
                    break;
                case "//YoutubeDownloaderPage":
                    title += " - YouTube Downloader";
                    break;
                case "//SoundCloudPlayerPage":
                    title += " - SoundCloud Player";
                    break;
            }

            Title = title;
        }
    }
}

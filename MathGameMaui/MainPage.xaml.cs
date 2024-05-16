using Windows.Gaming.Input;

namespace MathGameMaui;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private void OnGameChosen(object sender, EventArgs args)
    {
        Button button = (Button)sender;
        
        Navigation.PushAsync(new GamePage(button.Text));
    }

    private void OnViewPreviousGamesChosen(object sender, EventArgs args)
    {
        Button button = (Button)sender;

        Navigation.PushAsync(new PreviousGames());
    }
}

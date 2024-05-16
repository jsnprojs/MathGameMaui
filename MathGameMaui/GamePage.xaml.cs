using System.Security.AccessControl;

namespace MathGameMaui;

public partial class GamePage : ContentPage
{
	public string GameType { get; set; }

	public GamePage(string gameType)
    {
		InitializeComponent();

        GameType = gameType;

        BindingContext = this;
			
	}
}
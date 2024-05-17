using System.Security.AccessControl;

namespace MathGameMaui;

public partial class GamePage : ContentPage
{
	public string GameType { get; set; }
    int firstNumber = 0;
    int secondNumber = 0;
    int score = 0;
    const int totalQuestions = 2;
    int gamesLeft = totalQuestions;

    public GamePage(string gameType)
    {
		InitializeComponent();

        GameType = gameType;

        BindingContext = this;
	    CreateNewQuestion();
	}

    private void CreateNewQuestion()
    {
        var random = new Random();

        firstNumber = GameType != "Division" ? random.Next(1, 9) : random.Next(1, 99);
        secondNumber = GameType != "Division" ? random.Next(1, 9) : random.Next(1, 99);

        if (GameType == "Division")
        {
            while (firstNumber < secondNumber || firstNumber % secondNumber != 0)
            {
                firstNumber = random.Next(1, 99);
                secondNumber = random.Next(1, 99);
            }
        }

        QuestionLabel.Text = $"{firstNumber} {GameType} {secondNumber}";
    }

    private void OnAnswerSubmitted(object sender, EventArgs e)
    {
        int answer = Int32.Parse(AnswerEntry.Text);
        
        bool isCorrect = false;
        switch (GameType)
        {
            case "+":
                isCorrect = answer == firstNumber + secondNumber;
                break;
            case "-":
                isCorrect = answer == firstNumber - secondNumber;
                break;
            case "�":
                isCorrect = answer == firstNumber * secondNumber;
                break;
            case "�":
                isCorrect = answer == firstNumber / secondNumber;
                break;
        };
        ProcessAnswer(isCorrect);
        gamesLeft--;
        AnswerEntry.Text = "";

        if(gamesLeft > 0)
        {
            CreateNewQuestion();
        }
        else
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        QuestionsArea.IsVisible = false;
        BackToMenuBtn.IsVisible = true;
        GameOverLabel.Text = $"Game over! Your got {score} out of {totalQuestions} right";
    }

    private void ProcessAnswer(bool isCorrect)
    {
            score = isCorrect ? score += 1 : score;
            AnswerLabel.Text = isCorrect ? "Correct!" : "Incorrect";
    }

    private void MainMenuBtn(object sender, EventArgs e)
    {
        Navigation.PushAsync(new MainPage());
    }

    private void OnBackToMenu(object sender, EventArgs e)
    {
        score = 0;
        gamesLeft = totalQuestions;

        Navigation.PushAsync(new MainPage());
    }
}
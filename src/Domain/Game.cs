namespace Domain;

internal class Game
{
    private List<int> _highscores = new();
    private Dice _dice1 = new();
    private Dice _dice2 = new();

    public int Eye1 => _dice1.Dots;
    public int Eye2
    {
        get { return _dice2.Dots; }
    }
    public bool HasSnakeEyes => Eye1 == 1 && Eye2 == 1;
    public IReadOnlyList<int> HighScores => _highscores.AsReadOnly();
    public int Total { get; set; }

    public Game()
    {
        Initialize();
    }

    private void Initialize()
    {
        _dice1 = new();
        _dice2 = new();
    }

    public void Play()
    {
        _dice1.Roll();
        _dice2.Roll();
        if (HasSnakeEyes)
        {
            _highscores.Add(Total);
            Total = 0;
        }
        else
        {
            Total += Eye1 + Eye2;
        }
    }
    public void Restart()
    {
        Initialize();
    }
}

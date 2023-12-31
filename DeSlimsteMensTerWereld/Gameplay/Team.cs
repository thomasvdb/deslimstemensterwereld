namespace DeSlimsteMensTerWereld.Gameplay;

public class Team
{
    public Team(string name)
    {
        Name = name;
        AmountOfSecondsLeft = 60;
    }
    
    public string Name { get; }
    public int AmountOfSecondsLeft { get; set; }
    public bool Active { get; set; } = true;
}
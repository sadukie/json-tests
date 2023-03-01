namespace src;
public class ComplexPerson
{
    public string Name { get; set; } = default!;
    public int Age { get; set; }
    public bool LikesGames { get; set; }
    public List<Game> GamesCollection { get; set;} = default!;
}

public class Game {
    public string Name {get; set;} = default!;
}
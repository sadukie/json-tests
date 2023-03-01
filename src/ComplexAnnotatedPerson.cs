using System.Text.Json.Serialization;

namespace src;
public class ComplexAnnotatedPerson
{
    [JsonPropertyName("personName")]
    public string Name { get; set; } = default!;
    public int Age { get; set; }
    public bool LikesGames { get; set; }
    public List<AnnotatedGame> GamesCollection { get; set;} = default!;
}

public class AnnotatedGame {
    [JsonPropertyName("gameName")]
    public string Name {get; set;} = default!;
}
using System.Text.Json.Serialization;

namespace src;
public class SimpleAnnotatedPerson
{
    [JsonPropertyName("personName")]
    public string Name { get; set; } = default!;
    public int Age { get; set; }
    public bool LikesGames { get; set; }
}

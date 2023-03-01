using Xunit;
using System.Text.Json;
using src;

namespace test;

public class TestComplexPersonJSON
{

    [Fact]
    public void ConfirmComplexSerialization(){
        ComplexPerson p = new ComplexPerson{ Name="Test", Age=25, LikesGames = true};
        p.GamesCollection = new List<Game>(){
            new Game(){Name="Chess"},
            new Game(){Name="Go"}
        };
        var serializedComplexPerson = JsonSerializer.Serialize(p);
        var desiredJson = $"{{\"Name\":\"{p.Name}\",\"Age\":{p.Age},\"LikesGames\":{JsonSerializer.Serialize(p.LikesGames)},\"GamesCollection\":[{{\"Name\":\"Chess\"}},{{\"Name\":\"Go\"}}]}}";
        Assert.Equal(desiredJson,serializedComplexPerson);
    }

        [Fact]
    public void ConfirmComplexAnnotatedSerialization(){
        ComplexAnnotatedPerson p = new ComplexAnnotatedPerson{ Name="Test", Age=25, LikesGames = true};
        p.GamesCollection = new List<AnnotatedGame>(){
            new AnnotatedGame(){Name="Chess"},
            new AnnotatedGame(){Name="Go"}
        };
        var serializedComplexPerson = JsonSerializer.Serialize(p);
        var desiredJson = $"{{\"personName\":\"{p.Name}\",\"Age\":{p.Age},\"LikesGames\":{JsonSerializer.Serialize(p.LikesGames)},\"GamesCollection\":[{{\"gameName\":\"Chess\"}},{{\"gameName\":\"Go\"}}]}}";
        Assert.Equal(desiredJson,serializedComplexPerson);
    }
    
}
using Xunit;
using System.Text.Json;
using src;

namespace test;

public class TestSimplePersonJSON
{

    [Fact]
    public void ConfirmSimpleSerialization(){
        SimplePerson p = new SimplePerson{ Name="Test", Age=25, LikesGames = false};
        var serializedPerson = JsonSerializer.Serialize(p);
        var desiredJson = $"{{\"Name\":\"{p.Name}\",\"Age\":{p.Age},\"LikesGames\":{JsonSerializer.Serialize(p.LikesGames)}}}";
        Assert.Equal(desiredJson,serializedPerson);
    }
    
    [Fact]
    public void ConfirmSimpleDeserialization(){
        var serializedPerson = "{\"Name\":\"Test\",\"Age\":42,\"LikesGames\":true}";
        SimplePerson? deserializedPerson = JsonSerializer.Deserialize<SimplePerson>(serializedPerson);
        Assert.Equal("Test",deserializedPerson?.Name);
        Assert.Equal(42,deserializedPerson?.Age);
        Assert.Equal(true,deserializedPerson?.LikesGames);
    }
    
    [Fact]
    public void ConfirmSimpleAnnotatedSerialization(){
        SimpleAnnotatedPerson p = new SimpleAnnotatedPerson{ Name="Test", Age=25, LikesGames = false};
        var serializedPerson = JsonSerializer.Serialize(p);
        var desiredJson = $"{{\"personName\":\"{p.Name}\",\"Age\":{p.Age},\"LikesGames\":{JsonSerializer.Serialize(p.LikesGames)}}}";
        Assert.Equal(desiredJson,serializedPerson);
    }

        [Fact]
    public void ConfirmSimpleAnnotatedDeserialization(){
        var serializedPerson = "{\"personName\":\"Test\",\"Age\":42,\"LikesGames\":true}";
        SimpleAnnotatedPerson? deserializedPerson = JsonSerializer.Deserialize<SimpleAnnotatedPerson>(serializedPerson);
        Assert.Equal("Test",deserializedPerson?.Name);
        Assert.Equal(42,deserializedPerson?.Age);
        Assert.Equal(true,deserializedPerson?.LikesGames);
    }
}
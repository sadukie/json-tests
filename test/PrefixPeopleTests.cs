using Xunit;
using System.Text.Json;
using src;

namespace test;

public class TestJsonPrefixesSimplePerson
{
    [Fact]
    public void ConfirmSimplePrefixedSerialization(){
        SimplePerson p = new SimplePerson{ Name="Test", Age=25, LikesGames = false};
        var prefix = "nbp";
        var options = new JsonSerializerOptions{
            PropertyNamingPolicy = new PrefixedNamingPolicy(){ Prefix=prefix}
        };
        var serializedPerson = JsonSerializer.Serialize(p,options);
        var desiredJson = $"{{\"{prefix}-Name\":\"{p.Name}\",\"{prefix}-Age\":{p.Age},\"{prefix}-LikesGames\":{JsonSerializer.Serialize(p.LikesGames)}}}";
        Assert.Equal(desiredJson,serializedPerson);
    }
    
    [Fact]
    public void ConfirmSimpleDeserialization(){
        var prefix = "nbp";
        var serializedPerson = $"{{\"{prefix}-Name\":\"Test\",\"{prefix}-Age\":42,\"{prefix}-LikesGames\":true}}";
        
        var options = new JsonSerializerOptions{
            PropertyNamingPolicy = new PrefixedNamingPolicy(){ Prefix=prefix}
        };
        SimplePerson? deserializedPerson = JsonSerializer.Deserialize<SimplePerson>(serializedPerson,options);
        Assert.Equal("Test",deserializedPerson?.Name);
        Assert.Equal(42,deserializedPerson?.Age);
        Assert.Equal(true,deserializedPerson?.LikesGames);
    }
}
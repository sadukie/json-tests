using System.Text.Json;

public class PrefixedNamingPolicy : JsonNamingPolicy{
    public string Prefix { get; init; } = default!;
    
    public override string ConvertName(string name) =>
        $"{Prefix}-{name}";
}
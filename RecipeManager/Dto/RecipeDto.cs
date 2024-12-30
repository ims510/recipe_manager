namespace RecipeManager;

public class RecipeDto
{
    public required string[] Directions { get; set; }
    public required string[] Ingredients { get; set; }
    public required string Language { get; set; }
    public required string Source { get; set; }
    public required string[] Tags { get; set; }
    public required string Title { get; set; }
    public required string Url { get; set; }
    public string[]? Notes { get; set; }
    public required string Categories { get; set; }
    public required string Allergens { get; set; }
}

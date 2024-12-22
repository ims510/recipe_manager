namespace RecipeManager;

public class RecipeDto
{
    public string[] Directions { get; set; }
    public string[] Ingredients { get; set; }
    public string Language { get; set; }
    public string Source { get; set; }
    public string[] Tags { get; set; }
    public string Title { get; set; }
    public string Url { get; set; }
    public List<string> Notes { get; set; }
    public string[] Categories { get; set; }
    public string[] Allergens { get; set; }
}

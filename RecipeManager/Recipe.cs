namespace RecipeManager;

public class Recipe(string title, string url, string language, string source, string[] ingredients, string[] directions, string[] tags, RecipeCategory categories, Allergen allergens)
{
    public string[] Directions { get; private set; } = directions;
    public string[] Ingredients { get; private set; } = ingredients;
    public string Language { get; private set; } = language;
    public string Source { get; private set; } = source;
    public string[] Tags { get; private set; } = tags;
    public string Title { get; private set; } = title;
    public string Url { get; private set; } = url;
    public List<string> Notes { get; private set; } = [];
    public RecipeCategory Categories { get; private set; } = categories;
    public Allergen Allergens { get; private set; } = allergens;
}

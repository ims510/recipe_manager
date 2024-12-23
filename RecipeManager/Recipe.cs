namespace RecipeManager;

public class Recipe
{
    public string[] Directions { get; private set; }
    public string[] Ingredients { get; private set; }
    public string Language { get; private set; }
    public string Source { get; private set; }
    public string[] Tags { get; private set; }
    public string Title { get; private set; }
    public string Url { get; private set; }
    public List<string> Notes { get; private set; }
    public RecipeCategory Categories { get; private set; }
    public Allergen Allergens { get; private set; }

    public Recipe(string title, string url, string language, string source, string[] ingredients, string[] directions, string[] tags, RecipeCategory categories, Allergen allergens)
    {
        Directions = directions;
        Ingredients = ingredients;
        Language = language;
        Source = source;
        Tags = tags;
        Title = title;
        Url = url;
        Notes = [];
        Categories = categories;
        Allergens = allergens;
    }

    public Recipe(RecipeDto dto)
    {
        Directions = dto.Directions;
        Ingredients = dto.Ingredients;
        Language = dto.Language;
        Source = dto.Source;
        Tags = dto.Tags;
        Title = dto.Title;
        Url = dto.Url;
        Notes = dto.Notes;
        Categories = (RecipeCategory) Enum.Parse(typeof(RecipeCategory), dto.Categories);
        Allergens = (Allergen) Enum.Parse(typeof(Allergen), dto.Allergens);
    }
}

using System.Text;
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
        if (dto.Notes is null)
        {
            Notes = [];
        }
        else
        {
        Notes = new List<string>(dto.Notes);
        }
        Categories = (RecipeCategory) Enum.Parse(typeof(RecipeCategory), dto.Categories);
        Allergens = (Allergen) Enum.Parse(typeof(Allergen), dto.Allergens);
    }

    public string GetText()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"Title: {Title}");
        sb.AppendLine($"Source: {Source}");
        sb.AppendLine($"Url: {Url}");
        sb.AppendLine($"Language: {Language}");
        sb.AppendLine($"Categories: {Categories}");
        sb.AppendLine($"Allergens: {Allergens}");
        sb.AppendLine("Ingredients:");
        foreach (string ingredient in Ingredients)
        {
            sb.AppendLine($"- {ingredient}");
        }
        sb.AppendLine("Directions:");
        foreach (string direction in Directions)
        {
            sb.AppendLine($"- {direction}");
        }
        sb.AppendLine("Tags:");
        foreach (string tag in Tags)
        {
            sb.AppendLine($"- {tag}");
        }
        sb.AppendLine("Notes:");
        
        foreach (string note in Notes)
        {
            sb.AppendLine($"- {note}");
        }
        return sb.ToString();
    }

    public string GetMarkdown()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"# {Title}");
        sb.AppendLine($"[{Url}]({Url})  ");
        sb.AppendLine($"**Source:** {Source}  ");
        sb.AppendLine($"**Language:** {Language}  ");
        sb.AppendLine($"**Categories:** {Categories}  ");
        sb.AppendLine($"**Allergens:** {Allergens}  ");
        sb.AppendLine("## Ingredients");
        foreach (string ingredient in Ingredients)
        {
            sb.AppendLine($"- {ingredient}");
        }
        sb.AppendLine("## Directions");
        foreach (string direction in Directions)
        {
            sb.AppendLine($"1. {direction}");
        }
        sb.AppendLine("## Tags");
        foreach (string tag in Tags)
        {
            sb.AppendLine($"- {tag}");
        }
        sb.AppendLine("## Notes");
        foreach (string note in Notes)
        {
            sb.AppendLine($"- {note}");
        }
        return sb.ToString();
    }

    public void AddNote(string note)
    {
        Notes.Add(note);
    }

    public void ClearNotes()
    {
        Notes.Clear();
    }
}

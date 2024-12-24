namespace RecipeManager;

public class SearchCommand : Command
{
    public SearchCommand(RecipeManager recipeManager, string[] arguments)
        : base(recipeManager, arguments)
    {
        if (arguments.Length < 2)
        {
            isValid = false;
        }
    }

    public override void Execute()
    {
        if (!isValid)
        {
            Console.WriteLine("Invalid command arguments");
            return;
        }

        string searchType = arguments[0];
        string searchTerm = arguments[1];
        Recipe[] searchResults;
        switch (searchType)
        {
            case "title":
                searchResults = recipeManager.SearchByTitle(searchTerm);
                break;
            case "ingredient":
                searchResults = recipeManager.SearchByIngredient(searchTerm);
                break;
            case "tag":
                searchResults = recipeManager.SearchByTag(searchTerm);
                break;
            case "category":
                RecipeCategory category;
                if (!Enum.TryParse(searchTerm, true, out category))
                {
                    Console.WriteLine($"Invalid category: {searchTerm}");
                    return;
                }
                searchResults = recipeManager.SearchByCategory(category);
                break;
            case "allergen":
                Allergen allergen;
                if (!Enum.TryParse(searchTerm, true, out allergen))
                {
                    Console.WriteLine($"Invalid allergen: {searchTerm}");
                    return;
                }
                searchResults = recipeManager.SearchByAllergen(allergen);
                break;
            default:
                Console.WriteLine($"Invalid search type: {searchType}");
                return;
        }
        if (searchResults.Length == 0)
        {
            Console.WriteLine("No recipes found");
        }
        else
        {
            Console.WriteLine($"Found {searchResults.Length} recipes:");
            foreach (Recipe recipe in searchResults)
            {
                Console.WriteLine($"{recipe.Id}: {recipe.Title}");
            }
        }

    }


}
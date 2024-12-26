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
            recipeManager.LocalisationService.PrintMessage("invalid-command-arguments");
            return;
        }

        string searchType = arguments[0];
        string searchTypeTag = recipeManager.LocalisationService.GetCommand(searchType);
        string searchTerm = arguments[1];
        Recipe[] searchResults;
        switch (searchTypeTag)
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
                    recipeManager.LocalisationService.PrintMessage("invalid-category", searchTerm);
                    return;
                }
                searchResults = recipeManager.SearchByCategory(category);
                break;
            case "allergen":
                Allergen allergen;
                if (!Enum.TryParse(searchTerm, true, out allergen))
                {
                    recipeManager.LocalisationService.PrintMessage("invalid-allergen", searchTerm);
                    return;
                }
                searchResults = recipeManager.SearchByAllergen(allergen);
                break;
            default:
                recipeManager.LocalisationService.PrintMessage("invalid-search-type", searchType);
                return;
        }
        if (searchResults.Length == 0)
        {
            recipeManager.LocalisationService.PrintMessage("no-recipes-found");
        }
        else
        {
            recipeManager.LocalisationService.PrintMessage("found-recipes", searchResults.Length);
            foreach (Recipe recipe in searchResults)
            {
                Console.WriteLine($"{recipe.Id}: {recipe.Title}");
            }
        }

    }


}
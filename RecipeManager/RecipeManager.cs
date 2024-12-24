namespace RecipeManager;

public class RecipeManager
{
    private List<Recipe> recipes = [];

    public int RecipeCount => recipes.Count;

    public void AddRecipe(Recipe recipe)
    {
        recipes.Add(recipe);
    }

    public Recipe GetRecipe(int index)
    {
        return recipes[index - 1];
    }

    public Recipe[] SearchByTitle(string title)
    {
        return recipes.Where(recipe => recipe.Title.Contains(title, StringComparison.CurrentCultureIgnoreCase)).ToArray();
    }

    public Recipe[] SearchByIngredient(string ingredient)
    {
        return recipes.Where(recipe => recipe.Ingredients.Any(i => i.Contains(ingredient, StringComparison.CurrentCultureIgnoreCase))).ToArray();
    }

    public Recipe[] SearchByTag(string tag)
    {
        return recipes.Where(recipe => recipe.Tags.Any(t => t.Equals(tag, StringComparison.CurrentCultureIgnoreCase))).ToArray();
    }

    public Recipe[] SearchByCategory(RecipeCategory category)
    {
        return recipes.Where(recipe => recipe.Categories.HasFlag(category)).ToArray();
    }

    public Recipe[] SearchByAllergen(Allergen allergen)
    {
        return recipes.Where(recipe => recipe.Allergens.HasFlag(allergen)).ToArray();
    }
    
}

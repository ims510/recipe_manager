namespace RecipeManager;

public class RecipeManager
{
    private List<Recipe> recipes = [];

    public void AddRecipe(Recipe recipe)
    {
        recipes.Add(recipe);
    }

    public int GetRecipeCount()
    {
        return recipes.Count;
    }

    public Recipe GetRecipe(int index)
    {
        return recipes[index];
    }
}

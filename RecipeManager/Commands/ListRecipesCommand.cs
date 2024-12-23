namespace RecipeManager;

public class ListRecipesCommand : Command
{
    public ListRecipesCommand(RecipeManager recipeManager, string[] arguments)
        : base(recipeManager, arguments)
    {
    }

    public override void Execute()
    {
        for (int i = 1; i <= recipeManager.GetRecipeCount(); i++)
        {
            Recipe recipe = recipeManager.GetRecipe(i);
            Console.WriteLine($"{i}. {recipe.Title}");
        }
    }
}
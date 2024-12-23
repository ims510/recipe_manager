namespace RecipeManager;

public class ShowRecipeCommand : Command
{
    public ShowRecipeCommand(RecipeManager recipeManager, string[] arguments)
        : base(recipeManager, arguments)
    {
        if (arguments.Length < 1)
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
        
        int id = int.Parse(arguments[0]);
        if (id > 0 && id <= recipeManager.GetRecipeCount())
        {
            Recipe recipe = recipeManager.GetRecipe(id);
            Console.WriteLine(recipe.GetText());
        }
        else
        {
            Console.WriteLine("Invalid recipe ID");
        }
    }
}
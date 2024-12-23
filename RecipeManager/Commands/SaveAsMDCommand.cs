namespace RecipeManager;

public class SaveAsMDCommand : Command
{
    public SaveAsMDCommand(RecipeManager recipeManager, string[] arguments)
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
        
        int id = int.Parse(arguments[0]);
        if (id > 0 && id <= recipeManager.GetRecipeCount())
        {
            Recipe recipe = recipeManager.GetRecipe(id);
            string recipeMD = recipe.GetMarkdown();
            string filepath = arguments[1];
            try
            {
                File.WriteAllText(filepath, recipeMD);
            }
            catch (Exception e)
            {
                Console.Error.WriteLine($"Error saving recipe: {e.Message}");
            }
        }
        else
        {
            Console.WriteLine("Invalid recipe ID");
        }

    }
}

    
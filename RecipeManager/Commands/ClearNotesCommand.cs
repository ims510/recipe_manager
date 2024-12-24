namespace RecipeManager;

public class ClearNotesCommand : Command
{
    public ClearNotesCommand(RecipeManager recipeManager, string[] arguments)
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
        if (id > 0 && id <= recipeManager.RecipeCount)
        {
            Recipe recipe = recipeManager.GetRecipe(id);
            recipe.ClearNotes();
        }
        else
        {
            Console.WriteLine("Invalid recipe ID");
        }

    }

}
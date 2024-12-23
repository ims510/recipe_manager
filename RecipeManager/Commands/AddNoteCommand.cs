namespace RecipeManager;

public class AddNoteCommand : Command
{
    public AddNoteCommand(RecipeManager recipeManager, string[] arguments)
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
            string[] noteWords = arguments.Skip(1).ToArray();
            string note = string.Join(" ", noteWords);
            recipe.AddNote(note);
        }
        else
        {
            Console.WriteLine("Invalid recipe ID");
        }

    }
}
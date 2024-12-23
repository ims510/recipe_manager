namespace RecipeManager;

public class CommandInterpreter
{
    RecipeManager recipeManager;
    public CommandInterpreter(RecipeManager recipeManager)
    {
        this.recipeManager = recipeManager;
    }

    public Command Interpret(string[] arguments)
        {
            if (arguments.Length < 1)
            {
                Console.Error.WriteLine("Not enough arguments!");

                // new NopCommand();
            }

            string commandName = arguments[0];
            //commandName = localizationService.GetText(commandName);
            string[] commandArguments = arguments.Skip(1).ToArray();

            switch (commandName)
            {
                case "load-recipes":
                    return new LoadRecipesCommand(recipeManager, commandArguments);
                case "show-recipe":
                    return new ShowRecipeCommand(recipeManager, commandArguments);
                case "save-as-md":
                    return new SaveAsMDCommand(recipeManager, commandArguments);
                case "add-note":
                    return new AddNoteCommand(recipeManager, commandArguments);
                case "clear-notes":
                    return new ClearNotesCommand(recipeManager, commandArguments);
                case "save-recipe":
                    return new SaveRecipeCommand(recipeManager, commandArguments);
                case "list-recipes":
                    return new ListRecipesCommand(recipeManager, commandArguments);
                default:
                    throw new CommandNotFoundException(commandName);
            }
        }
}
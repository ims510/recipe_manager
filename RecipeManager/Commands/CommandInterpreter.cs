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
                default:
                    throw new CommandNotFoundException(commandName);
                    

            }
        }
}
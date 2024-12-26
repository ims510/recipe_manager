namespace RecipeManager;

public class CommandNotFoundException : Exception
{
    public CommandNotFoundException() 
        : base()
    {
    }

    public CommandNotFoundException(string message)
        : base($"Invalid command: {message}")
    {
    }

    public CommandNotFoundException(string message, LocalisationService localisationService)
        : base($"{localisationService.GetMessage("invalid-command")}: {message}")
    {
    }
}
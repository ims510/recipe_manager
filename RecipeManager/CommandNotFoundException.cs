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
}
namespace RecipeManager;

public abstract class Command(RecipeManager recipeManager, string[] arguments)
{
    protected RecipeManager recipeManager = recipeManager;
    protected bool isValid = true;
    protected string[] arguments = arguments;
    public abstract void Execute();
}
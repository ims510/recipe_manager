namespace RecipeManager;

public class HelpCommand : Command
{
    public HelpCommand(RecipeManager recipeManager, string[] arguments)
        : base(recipeManager, arguments)
    {
    }

    public override void Execute()
    {
        recipeManager.LocalisationService.PrintHelp();
    }
}
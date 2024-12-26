namespace RecipeManager;

public class NoCommand : Command
{
    public NoCommand(RecipeManager recipeManager)
        : base(recipeManager, [])
    {
    }

    public override void Execute()
    {
        recipeManager.LocalisationService.PrintMessage("enter-command");
    }
}
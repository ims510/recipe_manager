namespace RecipeManager;

public class ChangeLanguageCommand : Command
{
    public ChangeLanguageCommand(RecipeManager recipeManager, string[] arguments)
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
            recipeManager.LocalisationService.PrintMessage("invalid-command-arguments");
            return;
        }

        string language = arguments[0];
        recipeManager.LocalisationService.CurrentLanguage = language;
        recipeManager.LocalisationService.PrintMessage("language-changed", recipeManager.LocalisationService.CurrentLanguageName);
    }
}
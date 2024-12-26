using System.Text.Json;
using System.Text.Unicode;
using System.Text.Encodings.Web;

namespace RecipeManager;

public class SaveRecipeCommand : Command
{
    public SaveRecipeCommand(RecipeManager recipeManager, string[] arguments)
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

        int id = int.Parse(arguments[0]);
        if (id > 0 && id <= recipeManager.RecipeCount)
        {
            Recipe recipe = recipeManager.GetRecipe(id);
            RecipeDto recipeDto = recipe.ToDto();
            JsonSerializerOptions options = new JsonSerializerOptions
        {
            WriteIndented = true,
            PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
            Encoder = JavaScriptEncoder.Create(UnicodeRanges.All)
        };

        string json = JsonSerializer.Serialize(recipeDto, options); 
        File.WriteAllText(recipe.Filename, json);

        }
        else
        {
            recipeManager.LocalisationService.PrintMessage("invalid-recipe-id");
        }
      
    }
}
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
namespace RecipeManager;

public class LoadRecipesCommand : Command
{
    public LoadRecipesCommand(RecipeManager recipeManager, string[] commandArguments) : base(recipeManager, commandArguments)
    {
        if (commandArguments.Length < 1)
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

        string directory = arguments[0];
        string path = $"{directory}/recipes.txt";

        if (!File.Exists(path))
        {
            Console.Error.WriteLine($"File [{path}] not found");

            return;
        }

        StreamReader reader = new StreamReader(path);
        int count = 0;
        while(!reader.EndOfStream)
        {
            string? line = reader.ReadLine();
            if (string.IsNullOrWhiteSpace(line))
            {
                continue;
            }
            try
            {
                string jsonpath = $"{directory}/{line}";
                Recipe recipe = ParseJsonRecipe(jsonpath, recipeManager.RecipeCount + 1);
                recipeManager.AddRecipe(recipe);
                count++;
            }
            catch (Exception e)
            {
                Console.Error.WriteLine($"Error loading recipe: {e.Message}");
            }
        }
        recipeManager.LocalisationService.PrintMessage("loaded-recipes", count);

    }

    private Recipe ParseJsonRecipe(string filename, int id)
    {
        JsonSerializerOptions options = new JsonSerializerOptions
        {
            WriteIndented = true,
            PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
            Encoder = JavaScriptEncoder.Create(UnicodeRanges.All)
        };

        try
        {
            string json = File.ReadAllText(filename);
            RecipeDto recipeDto = JsonSerializer.Deserialize<RecipeDto>(json, options);
            return new Recipe(recipeDto, filename, id);
        }
        catch (Exception e)
        {
            recipeManager.LocalisationService.PrintMessage("error-parsing-json", e.Message);
            throw;
        }
    }
}

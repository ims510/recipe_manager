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
            Console.WriteLine("Invalid command arguments");
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
                Recipe recipe = ParseJsonRecipe(jsonpath);
                recipeManager.AddRecipe(recipe);
                count++;
            }
            catch (Exception e)
            {
                Console.Error.WriteLine($"Error loading recipe: {e.Message}");
            }
        }
        Console.WriteLine($"Loaded {count} recipes");

    }

    private Recipe ParseJsonRecipe(string filename)
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
            return new Recipe(recipeDto, filename);
        }
        catch (Exception e)
        {
            Console.Error.WriteLine($"Error parsing JSON: {e.Message}");
            throw;
        }
    }
}

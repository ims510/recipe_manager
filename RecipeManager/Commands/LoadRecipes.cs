namespace RecipeManager;

public class LoadRecipes : Command
{
    public LoadRecipes(RecipeManager recipeManager, string[] commandArguments) : base(recipeManager, commandArguments)
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

        string path = arguments[0];

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
        Console.WriteLine($"Line {count}: {line}");
        count++;
        }

    }
}
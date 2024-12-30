namespace RecipeManager;

public class Program
{
    public static void Main(string[] args)
    {
        LocalisationService localisationService = new LocalisationService();
        RecipeManager recipeManager = new RecipeManager(localisationService);
        CommandInterpreter interpreter = new CommandInterpreter(recipeManager);

        while (true)
        {
            Console.Write("$ ");
            string? line = Console.ReadLine();
            if (line is null)
            {
                continue;
            }
            
            string[] commandArgs = line.Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

            try
            {
                Command command = interpreter.Interpret(commandArgs);
                command.Execute();
            }
            catch (CommandNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}

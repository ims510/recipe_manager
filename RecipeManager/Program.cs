namespace RecipeManager;

public class Program
{
    public static void Main(string[] args)
    {
        RecipeManager recipeManager = new RecipeManager();
        CommandInterpreter interpreter = new CommandInterpreter(recipeManager);

        while (true)
        {
            Console.Write("$ ");
            string? line = Console.ReadLine();
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

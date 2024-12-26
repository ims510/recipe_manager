using System.Globalization;
namespace RecipeManager;

public class LocalisationService
{
    Dictionary<string, Dictionary<string, string>> messages;
    Dictionary<string, Dictionary<string, string>> commands;
    Dictionary<string, Dictionary<string, string>> commandHelp;
    Dictionary<string, string> languages;
    string currentLanguage;
    public string CurrentLanguage
    {
        get { return currentLanguage; }
        set
        {
            if (languages.ContainsKey(value))
            {
                currentLanguage = value;
            }
            else
            {
                currentLanguage = "en";
                Console.WriteLine("Language not found, defaulting to English.");
            }
        }
    }

    public string CurrentLanguageName => languages[currentLanguage];

    public LocalisationService()
    {
        commands = new Dictionary<string, Dictionary<string, string>>()
        {
            {
                "fr", new Dictionary<string, string>()
                {
                    {"charge-recettes", "load-recipes"},
                    {"affiche-recette", "show-recipe"},
                    {"sauvegarde-md", "save-as-md"},
                    {"ajoute-note", "add-note"},
                    {"efface-notes", "clear-notes"},
                    {"sauvegarde-recette", "save-recipe"},
                    {"liste-recettes", "list-recipes"},
                    {"chercher", "search"},
                    {"change-langue", "change-language"},
                    {"aide", "help"},
                    {"titre", "title"},
                    {"ingrédient", "ingredient"},
                    {"ingredient", "ingredient"},
                    {"tag", "tag"},
                    {"catégorie", "category"},
                    {"categorie", "category"},
                    {"allergène", "allergen"},
                    {"allergene", "allergen"},
                }
            },
            {
                "en", new Dictionary<string, string>()
                {
                }
            }
        };

        commandHelp = new Dictionary<string, Dictionary<string, string>>()
        {
            {
                "fr", new Dictionary<string, string>()
                {
                    {"charge-recettes", "Charge les recettes à partir du dossier contenant des fichiers JSON, qui est donné comme argument. Vous devez appeler cette commande avant d'utiliser les autres commandes."},
                    {"affiche-recette", "Affiche une recette indexée au ID donné comme argument."},
                    {"sauvegarde-md", "Sauvegarde une recette au format Markdown. Le nom du fichier est donné comme argument."},
                    {"ajoute-note", "Ajoute une note à une recette dont l'ID est donné comme argument."},
                    {"efface-notes", "Efface les notes d'une recette dont l'ID est donné comme argument."},
                    {"sauvegarde-recette", "Sauvegarde une recette après avoir ajouté des notes au meme endroit que la recette originale."},
                    {"liste-recettes", "Liste les recettes qui ont été chargées et permet de voir leurs IDs."},
                    {"chercher", "Cherche des recettes, il faut donner le type de recherche (titre, ingredient, tag, categorie ou allergene) et le terme de recherche comme argument."},
                    {"change-langue", "Change la langue de l'application. Les langues disponibles sont: 'en' (anglais) et 'fr' (français)."},
                }
            },
            {
                "en", new Dictionary<string, string>()
                {
                    {"load-recipes", "Loads recipes from the folder containing JSON files, which is given as an argument. You must call this command before using the other commands."},
                    {"show-recipe", "Shows a recipe indexed at the given ID as an argument."},
                    {"save-as-md", "Saves a recipe in Markdown format. The filename is given as an argument."},
                    {"add-note", "Adds a note to a recipe with the ID given as an argument."},
                    {"clear-notes", "Clears the notes of a recipe with the ID given as an argument."},
                    {"save-recipe", "Saves a recipe after adding notes in the same place as the original recipe."},
                    {"list-recipes", "Lists the recipes that have been loaded and allows you to see their IDs."},
                    {"search", "Searches for recipes, you must give the search type (title, ingredient, tag, category or allergen) and the search term as arguments."},
                    {"change-language", "Changes the language of the application. Available languages are: 'en' (English) and 'fr' (French)."},
                }
            }
        };

        messages = new Dictionary<string, Dictionary<string, string>>()
        {
            {
                "fr", new Dictionary<string, string>()
                {
                    {"invalid-command-arguments", "Arguments de commande non valides"},
                    {"file-not-found", "Fichier pas trouvé"},
                    {"error-loading-recipe", "Erreur lors du chargement de la recette"},
                    {"loaded-recipes", "{0} recettes chargées"},
                    {"error-parsing-json", "Erreur lors de l'analyse du JSON: {0}"},
                    {"invalid-recipe-id", "ID de recette invalide"},
                    {"error-saving-recipe", "Erreur lors de la sauvegarde de la recette: {0}"},
                    {"invalid-category", "Catégorie invalide: {0}"},
                    {"invalid-allergen", "Allergène invalide: {0}"},
                    {"invalid-search-type", "Type de recherche invalide: {0}"},
                    {"no-recipes-found", "Aucune recette trouvée"},
                    {"found-recipes", "Trouvé {0} recettes:"},
                    {"invalid-command", "Commande invalide"},
                    {"enter-command", "Tapez une commande"},
                    {"language-changed", "Langue changée en {0}"},
                    {"available-commands", "Commandes disponibles:"},
                }
            },
            {
                "en", new Dictionary<string, string>()
                {
                    {"invalid-command-arguments", "Invalid command arguments"},
                    {"file-not-found", "File not found"},
                    {"error-loading-recipe", "Error loading recipe"},
                    {"loaded-recipes", "{0} recipes loaded"},
                    {"error-parsing-json", "Error parsing JSON: {0}"},
                    {"invalid-recipe-id", "Invalid recipe ID"},
                    {"error-saving-recipe", "Error saving recipe: {0}"},
                    {"invalid-category", "Invalid category: {0}"},
                    {"invalid-allergen", "Invalid allergen: {0}"},
                    {"invalid-search-type", "Invalid search type: {0}"},
                    {"no-recipes-found", "No recipes found"},
                    {"found-recipes", "Found {0} recipes:"},
                    {"invalid-command", "Invalid command"},
                    {"enter-command", "Enter a command"},
                    {"language-changed", "Language changed to {0}"},
                    {"available-commands", "Available commands:"},
                }
            }
        };

        languages = new Dictionary<string, string>()
        {
            {"en", "English"},
            {"fr", "Français"},
        };

        CurrentLanguage = CultureInfo.CurrentCulture.Name.Split("-")[0];
    }

    public string GetCommand(string input)
    {
        return commands[currentLanguage].GetValueOrDefault(input, input);
    }

    public string GetMessage(string key)
    {
        return messages[currentLanguage].GetValueOrDefault(key, $"[{key}]");
    }

    public void PrintMessage(string key, params object[] args)
    {
        Console.WriteLine(GetMessage(key), args);
    }

    public void PrintHelp()
    {
        PrintMessage("available-commands");
        Console.WriteLine();
        foreach (KeyValuePair<string, string> command in commandHelp[currentLanguage])
        {
            Console.WriteLine($"{command.Key}:");
            Console.WriteLine($"    {command.Value}");
            Console.WriteLine();
        }
    }

}

using System.Globalization;
namespace RecipeManager;

public class LocalisationService
{
    Dictionary<string, Dictionary<string, string>> messages;
    Dictionary<string, Dictionary<string, string>> commands;
    Dictionary<string, string> languages;
    string currentLanguage;
    public string CurrentLanguage {
        get { return currentLanguage; }
        set {
            if (languages.ContainsKey(value)) {
                currentLanguage = value;
            }
            else {
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
            { "fr" , new Dictionary<string, string>()
                {
                    {"charge-recettes", "load-recipes"},
                    {"affiche-recette", "show-recipe"},
                    {"sauvegarde-md", "save-as-md"},
                    {"ajoute-note", "add-note"},
                    {"efface-notes", "clear-notes"},
                    {"sauvegarde-recette", "save-recipe"},
                    {"liste-recettes", "list-recipes"},
                    {"chercher", "search"},
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
            { "en" , new Dictionary<string, string>()
                {
                }
            }
        };

        messages = new Dictionary<string, Dictionary<string, string>>()
        {
            { "fr" , new Dictionary<string, string>()
                {
                    {"invalid-command-arguments", "Arguments de commande non valides"},
                    {"file-not-found", "Fichier pas trouvé"},
                    {"error-loading-recipe", "Erreur lors du chargement de la recette"},
                    {"loaded-recipes", "{0} recettes chargées"},
                    {"error-parsing-json", "Erreur lors de l'analyse du JSON: {0}"},
                    {"invalid-recipe-id", "ID de recette invalide"},
                    {"error-saving-recipe", "Erreur lors de la sauvegarde de la recette"},
                    {"invalid-category", "Catégorie invalide: {0}"},
                    {"invalid-allergen", "Allergène invalide: {0}"},
                    {"invalid-search-type", "Type de recherche invalide: {0}"},
                    {"no-recipes-found", "Aucune recette trouvée"},
                    {"found-recipes", "Trouvé {0} recettes:"},
                    {"invalid-command", "Commande invalide"},
                    {"enter-command", "Tapez une commande"},
                    {"language-changed", "Langue changée en {0}"}
                    
                    
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
                    {"error-saving-recipe", "Error saving recipe"},
                    {"invalid-category", "Invalid category: {0}"},
                    {"invalid-allergen", "Invalid allergen: {0}"},
                    {"invalid-search-type", "Invalid search type: {0}"},
                    {"no-recipes-found", "No recipes found"},
                    {"found-recipes", "Found {0} recipes:"},
                    {"invalid-command", "Invalid command"},
                    {"enter-command", "Enter a command"},
                    {"language-changed", "Language changed to {0}"}
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
  
}

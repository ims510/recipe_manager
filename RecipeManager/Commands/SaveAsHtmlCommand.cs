using HtmlTags;
namespace RecipeManager;

public class SaveAsHtmlCommand : Command
{
    public SaveAsHtmlCommand(RecipeManager recipeManager, string[] arguments)
        : base(recipeManager, arguments)
    {
        if (arguments.Length < 2)
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
            string html = GetHtml(recipe);
            string filepath = arguments[1];
            try
            {
                File.WriteAllText(filepath, html);
                recipeManager.LocalisationService.PrintMessage("recipe-saved-html", filepath);
            }
            catch (Exception e)
            {
                recipeManager.LocalisationService.PrintMessage("error-saving-recipe", e.Message);
            }

        }
        else
        {
            recipeManager.LocalisationService.PrintMessage("invalid-recipe-id");
        }
    }

    private string GetHtml(Recipe recipe)
    {
        HtmlTag html = new HtmlTag("html");
        html.Append(new HtmlTag("head").Append(new HtmlTag("title").Text(recipe.Title)));
        HtmlTag body = new HtmlTag("body");
        body.Append(new HtmlTag("h1").Text(recipe.Title));
        body.Append(new HtmlTag("a").Attr("href", recipe.Url).Text(recipe.Url));
        body.Append(new HtmlTag("br"));
        body.Append(new HtmlTag("b").Text("Source: "));
        body.Append(new HtmlTag("span").Text(recipe.Source));
        body.Append(new HtmlTag("br"));
        body.Append(new HtmlTag("b").Text("Language: "));
        body.Append(new HtmlTag("span").Text(recipe.Language));
        body.Append(new HtmlTag("br"));
        body.Append(new HtmlTag("b").Text("Categories: "));
        body.Append(new HtmlTag("span").Text(recipe.Categories.ToString()));
        body.Append(new HtmlTag("br"));
        body.Append(new HtmlTag("b").Text("Allergens: "));
        body.Append(new HtmlTag("span").Text(recipe.Allergens.ToString()));
        body.Append(new HtmlTag("br"));
        body.Append(new HtmlTag("h2").Text("Ingredients"));
        HtmlTag ingredientsList = new HtmlTag("ul");
        foreach (string ingredient in recipe.Ingredients)
        {
            ingredientsList.Append(new HtmlTag("li").Text(ingredient));
        }
        body.Append(ingredientsList);
        body.Append(new HtmlTag("h2").Text("Directions"));
        HtmlTag directionsList = new HtmlTag("ol");
        foreach (string direction in recipe.Directions)
        {
            directionsList.Append(new HtmlTag("li").Text(direction));
        }
        body.Append(directionsList);
        body.Append(new HtmlTag("h2").Text("Tags"));
        HtmlTag tagsList = new HtmlTag("ul");
        foreach (string tag in recipe.Tags)
        {
            tagsList.Append(new HtmlTag("li").Text(tag));
        }
        body.Append(tagsList);
        body.Append(new HtmlTag("h2").Text("Notes"));
        HtmlTag notesList = new HtmlTag("ul");
        foreach (string note in recipe.Notes)
        {
            notesList.Append(new HtmlTag("li").Text(note));
        }
        body.Append(notesList);
        html.Append(body);

        return html.ToString();
    }
}
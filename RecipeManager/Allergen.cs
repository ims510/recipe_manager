namespace RecipeManager;
[Flags]
public enum Allergen
{
    DairyFree = 1 << 0,
    GlutenFree = 1 << 1,
    NutFree = 1 << 2,
    SoyFree = 1 << 3,
}
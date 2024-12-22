namespace RecipeManager;

public enum RecipeCategory
{
    Dessert = 1 << 0,
    Dinner = 1 << 1,
    Brunch = 1 << 2,
    Lunch = 1 << 3,
    Healthy = 1 << 4,
    Breakfast = 1 << 5,
    Snack = 1 << 6,
}
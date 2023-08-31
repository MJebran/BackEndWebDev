using Microsoft.AspNetCore.Mvc;

namespace Recapi.Controllers;

[ApiController]
[Route("[controller]")]
public class RecipeController : ControllerBase
{
    private readonly ILogger<RecipeController> _logger;
    private static List<Recipe> _recipes = new(); // List to store recipe data static list 

    public RecipeController(ILogger<RecipeController> logger)
    {
        _logger = logger;
    }

    [HttpGet()]
    public IEnumerable<Recipe> Get() // HTTP GET method to retrieve all recipes
    {
        return _recipes;
    }

    [HttpGet("{id}")]
    public Recipe Get(int id) // HTTP GET method to retrieve a specific recipe by ID
    {
        return _recipes[id];
    }

    [HttpPost]
    public Recipe Post([FromBody] Recipe recipe) // HTTP POST method to add a new recipe
    {
        recipe.Id = _recipes.Count; // Assign a unique ID to the new recipe
        _recipes.Add(recipe); // Add the new recipe to the list
        return recipe; // Return the added recipe
    }
}


public class Recipe
{
    public int Id { get; set; }  // Unique identifier for the recipe
    public string Name { get; set; }  // Name of the recipe
    public string Instructions { get; set; }  // Cooking instructions for the recipe
    public List<Ingredient> Ingredients { get; set; }  // List of ingredients in the recipe
}

public class Ingredient
{
    public string Name { get; set; }  // Name of the ingredient
    public decimal Quantity { get; set; }  // Quantity of the ingredient needed
    public string Unit { get; set; }  // Unit of measurement for the ingredient quantity
}
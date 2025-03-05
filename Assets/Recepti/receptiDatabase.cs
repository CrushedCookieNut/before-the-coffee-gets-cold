using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RecipeDatabase", menuName = "ScriptableObjects/RecipeDatabase", order = 1)]
public class RecipeDatabase : ScriptableObject {
    [System.Serializable]
    public class Recipe {
        public string name;
        public List<string> ingredients;

        public int difficulty;
    }

    public List<Recipe> recipes = new List<Recipe>();

    public List<string> GetRecipeIngredients(string recipeName) {
        foreach (var recipe in recipes) {
            if (recipe.name == recipeName) {
                return recipe.ingredients;
            }
        }

        Debug.LogWarning($"Recipe '{recipeName}' not found!");
        return null;
    }

    public int GetDifficulty(string recipeName) {
        foreach (var recipe in recipes) {
            if (recipe.name == recipeName) {
                return recipe.difficulty;
            }
        }
        Debug.LogWarning($"Recipe '{recipeName}' not found!");
        return 0;
    }
}

using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class IngredientDatabase : MonoBehaviour {
    public static IngredientDatabase Instance;

    [System.Serializable]
    public class Ingredient {
        public string name;
        public int amount;
    }

    [System.Serializable]
    private class IngredientList {
        public List<Ingredient> ingredients;
    }

    public List<Ingredient> ingredients = new List<Ingredient>();
    private string filePath;

    void Awake() {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            Debug.Log("IngredientDatabase initialized.");
        } else {
            Destroy(gameObject);
        }

        filePath = Path.Combine(Application.streamingAssetsPath, "ingredientDatabase.json");

        LoadIngredients();
        if (ingredients.Count > 0) {
            ResetIngredients();
        } else {
            Debug.LogWarning("No ingredients found to reset.");
        }
    }

    private void LoadIngredients()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            IngredientList ingredientList = JsonUtility.FromJson<IngredientList>(json);
            if (ingredientList != null)
            {
                ingredients = ingredientList.ingredients;
                Debug.Log("Ingredients loaded successfully.");
            }
            else
            {
                Debug.LogError("Failed to parse ingredients JSON.");
            }
        } else {
            Debug.LogWarning($"Ingredients file not found at {filePath}. Make sure the file exists in the StreamingAssets folder.");
        }
    }

    private void SaveIngredients() {
        string json = JsonUtility.ToJson(new IngredientList { ingredients = ingredients });
        File.WriteAllText(filePath, json);
        Debug.Log("Ingredients saved.");
    }

    public void UpdateIngredientAmount(string ingredientName, int amountToAdd) {
        Ingredient ingredient = ingredients.Find(i => i.name == ingredientName);
        if (ingredient != null) {
            ingredient.amount += amountToAdd;
            SaveIngredients();
        } else {
            Debug.LogError($"Ingredient {ingredientName} not found in the database.");
        }
    }

    public void ResetIngredients() {
        foreach (var ingredient in ingredients) {
            ingredient.amount = 0;
        }
        SaveIngredients();
    }
}

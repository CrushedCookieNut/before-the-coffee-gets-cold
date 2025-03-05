using UnityEngine;

public class RandomRecipeGenerator : MonoBehaviour {
    public RecipeDatabase recipeDatabase;

    private string selectedRecipe;

    private void Start() {
        if (Obvestilo.customerOrdered==true) {
            GenerateRandomRecipe();
        } else if (PlayerRecipeMaker.numberOfMadeRecipes==0) {
            Debug.Log("No customers have entered yet!");
        } else if (PlayerRecipeMaker.prevOrderMade==false) {
            Debug.Log("The customer has already ordered!");
        } else {
            Debug.Log("Customer hasn't ordered!");
        }
    }

    [HideInInspector]
    public static bool recipeWasGenerated=false;

    public void GenerateRandomRecipe() {
        int randomIndex = Random.Range(0, recipeDatabase.recipes.Count);
        selectedRecipe = recipeDatabase.recipes[randomIndex].name;

        PlayerPrefs.SetString("SelectedRecipe", selectedRecipe);
        Debug.Log($"Selected Recipe: {selectedRecipe}");
        recipeWasGenerated=true;
    }
}

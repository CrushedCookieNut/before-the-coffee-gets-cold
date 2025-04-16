using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

public class PlayerRecipeMaker : MonoBehaviour {
    public RecipeDatabase recipeDatabase;
    private GroupManager groupManager;
    private IngredientDatabase ingredientDatabase;
    private List<string> clickedAssets = new List<string>();
    private List<string> correctRecipe;
    private int recipeDifficulty;

    public static bool prevOrderMade;
    public static int numberOfMadeRecipes;

    private void Start() {

        ingredientDatabase = IngredientDatabase.Instance;
        string selectedRecipeName = PlayerPrefs.GetString("SelectedRecipe", "No Recipe Selected");

        if (!RandomRecipeGenerator.recipeWasGenerated) {
            Debug.LogError("Recipe has not been selected! Please check what the customer wants.");
            SceneManager.LoadScene("MainGame", LoadSceneMode.Single);
            return;
        }

        correctRecipe = recipeDatabase.GetRecipeIngredients(selectedRecipeName);
        recipeDifficulty = recipeDatabase.GetDifficulty(selectedRecipeName);

        if (correctRecipe == null) {
            Debug.LogError("Correct recipe not found! Ensure the RecipeDatabase is set up properly.");
            return;
        }

        Debug.Log($"Correct Recipe: {string.Join(", ", correctRecipe)}");

        groupManager = FindFirstObjectByType<GroupManager>();
        if (groupManager == null) {
            Debug.LogError("GroupManager not found!");
        }
    }

    public void CompareRecipes() {
        if (groupManager == null) {
            Debug.LogError("GroupManager is not set!");
            return;
        }

        List<string> clickedAssets = groupManager.clickedAssets;
        Debug.Log($"Clicked Assets: {string.Join(", ", clickedAssets)}");
        Debug.Log($"Correct Recipe: {string.Join(", ", correctRecipe)}");

        if (clickedAssets.Count != correctRecipe.Count) {
            Debug.LogError("Incorrect recipe! Mismatch in number of items.");
            SceneManager.LoadScene("MainGame", LoadSceneMode.Single);
            clickedAssets.Clear();
            groupManager.clickedAssets.Clear();
            correctRecipe.Clear();
            RandomRecipeGenerator.recipeWasGenerated = false;
            Debug.Log($"Total Points: {tocke.st_tock}");
            PlayerPrefs.SetInt("StTock", tocke.st_tock);
            PlayerPrefs.Save();

            prevOrderMade = true;
            numberOfMadeRecipes += 1;

            Obvestilo.customerOrdered = false;
            return;
        }

        if (clickedAssets.OrderBy(x => x).SequenceEqual(correctRecipe.OrderBy(x => x))) {
            switch (recipeDifficulty) {
                case 1:
                    tocke.st_tock += 100;
                    break;
                case 2:
                    tocke.st_tock += 200;
                    break;
                case 3:
                    tocke.st_tock += 300;
                    break;
            }
            Debug.Log("Correct recipe! Points awarded based on difficulty.");
        } else {
            Debug.LogError("Incorrect recipe! Items do not match.");
        }

        SceneManager.LoadScene("MainGame", LoadSceneMode.Single);

        clickedAssets.Clear();
        groupManager.clickedAssets.Clear();
        correctRecipe.Clear();
        RandomRecipeGenerator.recipeWasGenerated = false;
        Debug.Log($"Total Points: {tocke.st_tock}");
        PlayerPrefs.SetInt("StTock", tocke.st_tock);
        PlayerPrefs.Save();

        prevOrderMade = true;
        numberOfMadeRecipes += 1;

        Obvestilo.customerOrdered = false;
    }

    private void OnApplicationQuit() {
        ingredientDatabase.ResetIngredients();
    }
}

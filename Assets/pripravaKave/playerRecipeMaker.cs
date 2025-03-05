using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

public class PlayerRecipeMaker : MonoBehaviour {
    public RecipeDatabase recipeDatabase;
    private GroupManager groupManager;
    private List<string> clickedAssets = new List<string>();
    private List<string> correctRecipe;
    private int recipeDifficulty;

    public static bool prevOrderMade;

    public static int numberOfMadeRecipes;

    [System.Obsolete]
    private void Start() {
        string selectedRecipeName = PlayerPrefs.GetString("SelectedRecipe", "No Recipe Selected");
        if (RandomRecipeGenerator.recipeWasGenerated==false) {
            Debug.LogError("Recipe has not been selected! Please check what the customer wants.");
            SceneManager.LoadScene("MainGame", LoadSceneMode.Single);
            return;
        }
        correctRecipe = recipeDatabase.GetRecipeIngredients(selectedRecipeName);
        recipeDifficulty = recipeDatabase.GetDifficulty(selectedRecipeName);

        if (correctRecipe == null) {
            Debug.LogError("Correct recipe not found! Make sure the RecipeDatabase is set up.");
        } else {
            Debug.Log($"Correct Recipe: {string.Join(", ", correctRecipe)}");
        }

        groupManager = FindObjectOfType<GroupManager>();

        if (groupManager == null) {
            Debug.LogError("GroupManager not found!");
        }
    }

    public void AddClickedAsset(string assetName) {
        clickedAssets.Add(assetName);
        Debug.Log($"Clicked Asset Added: {assetName}");
    }

    public void CompareRecipes() {
        if (groupManager == null) {
            Debug.LogError("GroupManager is not set!");
            return;
        }

        List<string> clickedAssets = groupManager.clickedAssets;
        Debug.Log($"Clicked Assets: {string.Join(", ", clickedAssets)}");
        Debug.Log($"Current Recipe: {string.Join(", ", correctRecipe)}");

        if (clickedAssets.Count != correctRecipe.Count) {
            tocke.st_tock=tocke.st_tock-150;
            Debug.LogError("Incorrect recipe! Mismatch in number of items."); //odštejemo točke za napačen recept
            return;
        }

        if (clickedAssets.OrderBy(x => x).SequenceEqual(correctRecipe.OrderBy(x => x))) {
            if (recipeDifficulty==1) {
                tocke.st_tock=tocke.st_tock+100;
            } else if (recipeDifficulty==2) {
                tocke.st_tock=tocke.st_tock+200;
            } else if (recipeDifficulty==3) {
                tocke.st_tock=tocke.st_tock+300;
            }
            Debug.Log("Correct recipe!"); //prištejemo točke odvisno od težavnosti
        } else {
            tocke.st_tock=tocke.st_tock-150;
            Debug.LogError("Incorrect recipe! Items do not match."); //odštejemo točke za napačen recept
        }
        SceneManager.LoadScene("MainGame", LoadSceneMode.Single);
        clickedAssets.Clear();
        groupManager.clickedAssets.Clear();
        correctRecipe.Clear();
        RandomRecipeGenerator.recipeWasGenerated=false;
        Debug.Log($"Stevilo tock: {tocke.st_tock}");
        prevOrderMade=true;
        numberOfMadeRecipes+=1;
        Obvestilo.customerOrdered=false;
    }

}

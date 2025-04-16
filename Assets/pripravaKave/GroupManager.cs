using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;

public class GroupManager : MonoBehaviour {
    public IngredientDatabase ingredientDatabase;
    public List<GameObject> groups;
    private int currentGroupIndex = 0;
    public List<string> clickedAssets = new List<string>();
    public TextMeshProUGUI clickedAssetsText;

    private void Start() {
        UpdateGroupVisibility();
        ingredientDatabase = IngredientDatabase.Instance;
    }

    private void UpdateGroupVisibility() {
        for (int i = 0; i < groups.Count; i++) {
            groups[i].SetActive(i == currentGroupIndex);
        }
    }

    public void SwitchGroup(int direction) {
        currentGroupIndex = (currentGroupIndex + direction + groups.Count) % groups.Count;
        UpdateGroupVisibility();
    }

    public void AddClickedAsset(string assetName) {
        IngredientDatabase.Ingredient ingredient = ingredientDatabase.ingredients.FirstOrDefault(i => i.name == assetName);

        if (ingredient != null) {
            if (ingredient.amount > 0) {
                ingredient.amount -= 1;
                clickedAssets.Add(assetName);
                Debug.Log($"Clicked Asset Added: {assetName}");
                clickedAssetsText.text = "Dodano je bilo " + assetName;
                Debug.Log($"Reduced amount of {assetName}. New amount: {ingredient.amount}");
            } else {
                Debug.LogWarning($"Not enough of {assetName} to reduce.");
            }
        } else {
            Debug.LogError($"Ingredient '{assetName}' not found in the IngredientDatabase!");
        }
    }
}

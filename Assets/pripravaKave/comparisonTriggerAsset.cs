using UnityEngine;

public class ComparisonTriggerAsset : MonoBehaviour {
    private PlayerRecipeMaker playerRecipeMaker;

    [System.Obsolete]
    private void Start() {
        playerRecipeMaker = FindObjectOfType<PlayerRecipeMaker>();

        if (playerRecipeMaker == null) {
            Debug.LogError("PlayerRecipeMaker not found in the scene!");
        }
    }

    private void OnMouseDown() {
        if (playerRecipeMaker != null) {
            playerRecipeMaker.CompareRecipes();
        } else {
            Debug.LogError("PlayerRecipeMaker script is missing!");
        }
    }
}

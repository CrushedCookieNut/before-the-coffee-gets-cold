using UnityEngine;
using TMPro;

public class tapioca : MonoBehaviour {
    public static int st_tapioce;
    public TextMeshProUGUI text;

    void Start() {
        st_tapioce = 0;
    }

    private void OnMouseDown() {
        System.Random random = new System.Random();
        int amountToAdd = random.Next(1, 4);

        IngredientDatabase ingredientDatabase = IngredientDatabase.Instance;


        if (st_tapioce < 20) {
            st_tapioce += amountToAdd;

            if (ingredientDatabase != null) {
                ingredientDatabase.UpdateIngredientAmount("tapioca", amountToAdd);
                Debug.Log("Tapioca: " + st_tapioce);
                text.text = "Imate " + st_tapioce + " tapioke!";
            } else {
                Debug.LogError("IngredientDatabase is not assigned in the Inspector!");
            }
        }
    }
}

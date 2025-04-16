using UnityEngine;
using TMPro;

public class drevo2 : MonoBehaviour {
    public static int st_malin;
    public static int st_robid;
    public TextMeshProUGUI text;

    void Start() {
        st_malin = 0;
        st_robid = 0;
    }

    private void OnMouseDown() {
        System.Random random = new System.Random();
        int malin_ali_robid = random.Next(1, 3);

        IngredientDatabase ingredientDatabase = IngredientDatabase.Instance;

        if (malin_ali_robid == 1) {
            if (st_malin < 20) {
                int amountToAdd = random.Next(1, 4);
                st_malin += amountToAdd;

                if (ingredientDatabase != null) {
                    ingredientDatabase.UpdateIngredientAmount("malina", amountToAdd);
                    Debug.Log("Malina: " + st_malin);
                    text.text = "Imate " + st_malin + " malin!";
                } else {
                    Debug.LogError("IngredientDatabase is not available!");
                }
            }
        } else {
            if (st_robid < 20) {
                int amountToAdd = random.Next(1, 4);
                st_robid += amountToAdd;

                if (ingredientDatabase != null) {
                    ingredientDatabase.UpdateIngredientAmount("robida", amountToAdd);
                    Debug.Log("Robida: " + st_robid);
                    text.text = "Imate " + st_robid + " robid!";
                } else {
                    Debug.LogError("IngredientDatabase is not available!");
                }
            }
        }
    }
}

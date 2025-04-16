using UnityEngine;
using TMPro;

public class drevo1 : MonoBehaviour {
    public static int st_jagode;
    public static int st_manga;
    public TextMeshProUGUI text;

    void Start() {
        st_jagode = 0;
        st_manga = 0;
    }

    private void OnMouseDown() {
        System.Random random = new System.Random();
        int jagode_ali_manga = random.Next(1, 3);

        IngredientDatabase ingredientDatabase = IngredientDatabase.Instance;

        if (jagode_ali_manga == 1) {
            if (st_jagode < 20) {
                int amountToAdd = random.Next(1, 4);
                st_jagode += amountToAdd;

                if (ingredientDatabase != null) {
                    ingredientDatabase.UpdateIngredientAmount("jagoda", amountToAdd);
                    text.text = "Imate " + st_jagode + " jagod!";
                    Debug.Log("Jagode: " + st_jagode);
                } else {
                    Debug.LogError("IngredientDatabase is not assigned in the Inspector!");
                }
            }
        } else {
            if (st_manga < 20) {
                int amountToAdd = random.Next(1, 4);
                st_manga += amountToAdd;

                if (ingredientDatabase != null) {
                    ingredientDatabase.UpdateIngredientAmount("mango", amountToAdd);
                    Debug.Log("Mango: " + st_manga);
                    text.text = "Imate " + st_manga + " manga!";
                } else {
                    Debug.LogError("IngredientDatabase is not assigned in the Inspector!");
                }
            }
        }
    }
}

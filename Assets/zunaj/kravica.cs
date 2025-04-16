using UnityEngine;
using TMPro;

public class kravica : MonoBehaviour {
    public static int st_mleka;
    public static int st_smetane;
    public TextMeshProUGUI text;

    void Start() {
        st_mleka = 0;
        st_smetane = 0;
    }

    private void OnMouseDown() {
        System.Random random = new System.Random();
        int mlek_ali_smet = random.Next(1, 3);

        IngredientDatabase ingredientDatabase = IngredientDatabase.Instance;


        if (mlek_ali_smet == 1) {
            if (st_mleka < 20) {
                int amountToAdd = random.Next(1, 4);
                st_mleka += amountToAdd;

                if (ingredientDatabase != null) {
                    ingredientDatabase.UpdateIngredientAmount("mleko", amountToAdd);
                    Debug.Log("Mleko: " + st_mleka);
                    text.text = "Imate " + st_mleka + " mleka!";
                } else {
                    Debug.LogError("IngredientDatabase is not assigned in the Inspector!");
                }
            }
        } else {
            if (st_smetane < 20) {
                int amountToAdd = random.Next(1, 4);
                st_smetane += amountToAdd;

                if (ingredientDatabase != null) {
                    ingredientDatabase.UpdateIngredientAmount("smetana", amountToAdd);
                    Debug.Log("Smetana: " + st_smetane);
                    text.text = "Imate " + st_smetane + " smetane!";
                } else {
                    Debug.LogError("IngredientDatabase is not assigned in the Inspector!");
                }
            }
        }
    }
}

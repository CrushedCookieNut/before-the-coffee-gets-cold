using UnityEngine;
using TMPro;

public class kava : MonoBehaviour {
    public static int st_kave;
    public static int st_coko_sirupa;
    public TextMeshProUGUI text;
    void Start() {
        st_kave = 0;
        st_coko_sirupa = 0;
    }

    private void OnMouseDown() {
        System.Random random = new System.Random();
        int kava_ali_sirup = random.Next(1, 3);

        IngredientDatabase ingredientDatabase = IngredientDatabase.Instance;


        if (kava_ali_sirup == 1) {
            if (st_kave < 20) {
                int amountToAdd = random.Next(1, 4);
                st_kave += amountToAdd;

                if (ingredientDatabase != null) {
                    ingredientDatabase.UpdateIngredientAmount("kava", amountToAdd);
                    Debug.Log("Kava: " + st_kave);
                    text.text = "Imate " + st_kave + " kave!";
                } else {
                    Debug.LogError("IngredientDatabase is not assigned in the Inspector!");
                }
            }
        } else {
            if (st_coko_sirupa < 20) {
                int amountToAdd = random.Next(1, 4);
                st_coko_sirupa += amountToAdd;

                if (ingredientDatabase != null) {
                    ingredientDatabase.UpdateIngredientAmount("cokoSirup", amountToAdd);
                    Debug.Log("Coko sirup: " + st_coko_sirupa);
                    text.text = "Imate " + st_coko_sirupa + " coko sirupa!";
                } else {
                    Debug.LogError("IngredientDatabase is not assigned in the Inspector!");
                }
            }
        }
    }
}

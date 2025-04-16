using UnityEngine;
using TMPro;

public class mini_drev : MonoBehaviour {
    public static int st_matche;
    public static int st_kamilice;
    public static int st_crnega;
    public static int st_mete;
    public static int st_melise;
    public TextMeshProUGUI text;

    void Start() {
        st_matche = 0;
        st_kamilice = 0;
        st_crnega = 0;
        st_mete = 0;
        st_melise = 0;
    }

    private void OnMouseDown() {
        System.Random random = new System.Random();
        int match_ali_kamil_ali_crni_ali_met_ali_mel = random.Next(1, 6);

        int amountToAdd = random.Next(1, 4);

        IngredientDatabase ingredientDatabase = IngredientDatabase.Instance;


        if (match_ali_kamil_ali_crni_ali_met_ali_mel == 1) {
            if (st_matche < 20) {
                st_matche += amountToAdd;

                if (ingredientDatabase != null) {
                    ingredientDatabase.UpdateIngredientAmount("matcha", amountToAdd);
                    Debug.Log("Matcha: " + st_matche);
                    text.text = "Imate " + st_matche + " matcha!";
                } else {
                    Debug.LogError("IngredientDatabase is not assigned in the Inspector!");
                }
            }
        } else if (match_ali_kamil_ali_crni_ali_met_ali_mel == 2) {
            if (st_kamilice < 20) {
                st_kamilice += amountToAdd;

                if (ingredientDatabase != null) {
                    ingredientDatabase.UpdateIngredientAmount("kamilica", amountToAdd);
                    Debug.Log("Kamilica: " + st_kamilice);
                    text.text = "Imate " + st_kamilice + " kamilice!";
                } else {
                    Debug.LogError("IngredientDatabase is not assigned in the Inspector!");
                }
            }
        } else if (match_ali_kamil_ali_crni_ali_met_ali_mel == 3) {
            if (st_crnega < 20) {
                st_crnega += amountToAdd;

                if (ingredientDatabase != null) {
                    ingredientDatabase.UpdateIngredientAmount("crni", amountToAdd);
                    Debug.Log("Crni: " + st_crnega);
                    text.text = "Imate " + st_crnega + " črnega!";
                } else {
                    Debug.LogError("IngredientDatabase is not assigned in the Inspector!");
                }
            }
        } else if (match_ali_kamil_ali_crni_ali_met_ali_mel == 4) {
            if (st_mete < 20) {
                st_mete += amountToAdd;

                if (ingredientDatabase != null) {
                    ingredientDatabase.UpdateIngredientAmount("meta", amountToAdd);
                    Debug.Log("Meta: " + st_mete);
                    text.text = "Imate " + st_mete + " mete!";
                } else {
                    Debug.LogError("IngredientDatabase is not assigned in the Inspector!");
                }
            }
        } else {
            if (st_melise < 20) {
                st_melise += amountToAdd;

                if (ingredientDatabase != null) {
                    ingredientDatabase.UpdateIngredientAmount("melisa", amountToAdd);
                    Debug.Log("Melisa: " + st_melise);
                    text.text = "Imate " + st_melise + " melise!";
                } else {
                    Debug.LogError("IngredientDatabase is not assigned in the Inspector!");
                }
            }
        }
    }
}

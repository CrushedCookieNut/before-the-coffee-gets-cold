using UnityEngine;

public class Obvestilo : MonoBehaviour {
    private int rnd;
    public static bool customerOrdered;
    private int counter;

    void Start() {
        if ((PlayerRecipeMaker.prevOrderMade && customerOrdered==false) || (customerOrdered==false && PlayerRecipeMaker.numberOfMadeRecipes == 0)) {
            rnd = GenerateRandom();
            counter = rnd;
            InvokeRepeating("LoopStep", 0f, 0.1f);
        }
        gameObject.SetActive(false); 
    }

    void Update() {
        if (customerOrdered) {
            CancelInvoke("LoopStep");
            gameObject.SetActive(false);
            return;
        }
        
        if (counter == 0) {
            rnd = GenerateRandom();
            counter = rnd;
            if (!customerOrdered) {
                InvokeRepeating("LoopStep", 0f, 0.1f);
            }
        }
    }

    void LoopStep() {
        if (customerOrdered) {
            CancelInvoke("LoopStep");
            gameObject.SetActive(false);
            return;
        }

        if (counter > 0) {
            counter--;
        } else {
            if ((PlayerRecipeMaker.prevOrderMade || PlayerRecipeMaker.numberOfMadeRecipes == 0) && !customerOrdered) {
                gameObject.SetActive(true);
            }
            CancelInvoke("LoopStep");
        }
    }

    int GenerateRandom() {
        return Random.Range(30, 101);
    }
}

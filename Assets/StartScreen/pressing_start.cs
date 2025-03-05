using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class start : MonoBehaviour {
    private void OnMouseDown() {
        SceneManager.LoadScene("ConnectScene", LoadSceneMode.Single);
        Obvestilo.customerOrdered=false;
        PlayerRecipeMaker.prevOrderMade=false;
        PlayerRecipeMaker.numberOfMadeRecipes=0;
    }
}
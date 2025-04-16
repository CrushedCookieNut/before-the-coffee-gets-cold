using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class narocanje : MonoBehaviour {
    private void OnMouseDown() {
        if (Obvestilo.obvestiloPrikazano) {
            Obvestilo.customerOrdered=true;
            PlayerRecipeMaker.prevOrderMade=false;
            SceneManager.LoadScene("Narocanje", LoadSceneMode.Single);
        } else {
            Debug.Log("Nobena stranka ne naroča.");
        }
    }
}
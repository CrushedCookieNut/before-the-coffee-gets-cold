using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class narocanje : MonoBehaviour {
    private void OnMouseDown() {
        Obvestilo.customerOrdered=true;
        PlayerRecipeMaker.prevOrderMade=false;
        SceneManager.LoadScene("Narocanje", LoadSceneMode.Single);
    }
}
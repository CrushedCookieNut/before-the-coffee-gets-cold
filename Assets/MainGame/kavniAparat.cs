using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class kavica : MonoBehaviour {
    private void OnMouseDown() {
        SceneManager.LoadScene("pripravakave", LoadSceneMode.Single);
    }
}
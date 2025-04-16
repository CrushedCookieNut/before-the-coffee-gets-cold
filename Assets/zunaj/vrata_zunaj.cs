using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class vrata_zunaj : MonoBehaviour {
    private void OnMouseDown() {
        SceneManager.LoadScene("MainGame", LoadSceneMode.Single);
    }
}
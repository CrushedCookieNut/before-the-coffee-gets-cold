using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class press_option : MonoBehaviour {
    private void OnMouseDown() {
        SceneManager.LoadScene("optionsScene", LoadSceneMode.Single);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class leave : MonoBehaviour {
    private void OnMouseDown() {
        SceneManager.LoadScene("StartScreen", LoadSceneMode.Single);
    }
}
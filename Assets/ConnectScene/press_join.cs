using UnityEngine;
using UnityEngine.SceneManagement;

public class press_join : MonoBehaviour {
    private void OnMouseDown() {
        SceneManager.LoadScene("ClientScene", LoadSceneMode.Single);

    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class receptiRun : MonoBehaviour {

    void Update() {
        if (Input.GetKeyDown(KeyCode.R)) {
            Debug.Log("R key pressed");
            SceneManager.LoadScene("Recepti", LoadSceneMode.Additive);
        } else if (Input.GetKeyDown(KeyCode.Escape)) {
            Debug.Log("Escape key pressed");
            SceneManager.UnloadSceneAsync("Recepti");
        }
    }
}

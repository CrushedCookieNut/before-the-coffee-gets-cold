using UnityEngine;
using UnityEngine.SceneManagement;

public class press_host : MonoBehaviour {
    private void OnMouseDown() {
        SceneManager.LoadScene("HostScene", LoadSceneMode.Single);

    }
}

using UnityEngine;

public class StartClient : MonoBehaviour {
    public ClientManager clientManager;

    private void OnMouseDown() {
        if (clientManager != null) {
            clientManager.ConnectToServer();
        } else {
            Debug.LogError("ClientManager not assigned in StartClient script!");
        }
    }
}
using UnityEngine;

public class StartHost : MonoBehaviour {
    public HostManager hostManager;

    private void OnMouseDown() {
        if (hostManager != null) {
            hostManager.StartHost();
        } else {
            Debug.LogError("HostManager not assigned in StartHost script!");
        }
    }
}
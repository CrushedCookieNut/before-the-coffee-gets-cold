using UnityEngine;

public class ClickableAsset : MonoBehaviour {
    private GroupManager groupManager;

    [System.Obsolete]
    private void Start() {
        groupManager = FindObjectOfType<GroupManager>();
        if (groupManager == null) {
            Debug.LogError("GroupManager not found in the scene!");
        }
    }

    private void OnMouseDown() {
        if (groupManager != null) {
            groupManager.AddClickedAsset(gameObject.name);
        }
    }
}

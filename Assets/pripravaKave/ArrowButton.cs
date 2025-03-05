using UnityEngine;

public class ArrowButton : MonoBehaviour {
    public GroupManager groupManager;
    public int direction; // 1 za desno, -1 za levo

    private void OnMouseDown() {
        if (groupManager != null){
            groupManager.SwitchGroup(direction);
        }
    }
}

using System.Collections.Generic;
using UnityEngine;

public class GroupManager : MonoBehaviour {
    public List<GameObject> groups;
    private int currentGroupIndex = 0;
    public List<string> clickedAssets = new List<string>();

    private void Start() {
        UpdateGroupVisibility();
    }

    private void UpdateGroupVisibility() {
        for (int i = 0; i < groups.Count; i++) {
            groups[i].SetActive(i == currentGroupIndex);
        }
    }

    public void SwitchGroup(int direction) {
        currentGroupIndex = (currentGroupIndex + direction + groups.Count) % groups.Count;
        UpdateGroupVisibility();
    }

    public void AddClickedAsset(string assetName) {
        clickedAssets.Add(assetName);
        Debug.Log($"Asset clicked: {assetName}");
    }
}

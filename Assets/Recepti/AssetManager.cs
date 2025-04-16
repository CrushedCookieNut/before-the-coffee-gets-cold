using UnityEngine;

public class AssetSwitcher : MonoBehaviour {
    public GameObject[] assets;
    private int currentIndex = 0;

    void Start() {
        ShowOnlyCurrentAsset();
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.RightArrow)) {
            SwitchToNext();
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow)){
            SwitchToPrevious();
        }
    }

    void SwitchToNext() {
        assets[currentIndex].SetActive(false);
        currentIndex = (currentIndex + 1) % assets.Length;
        assets[currentIndex].SetActive(true);
    }

    void SwitchToPrevious() {
        assets[currentIndex].SetActive(false);
        currentIndex = (currentIndex - 1 + assets.Length) % assets.Length;
        assets[currentIndex].SetActive(true);
    }

    void ShowOnlyCurrentAsset() {
        for (int i = 0; i < assets.Length; i++)
        {
            assets[i].SetActive(i == currentIndex);
        }
    }
}

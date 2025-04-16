using TMPro;
using UnityEngine;

public class tocke : MonoBehaviour {
    public TextMeshProUGUI st_tock_TMP;
    public static int st_tock=0;
    void Start() {
        st_tock = PlayerPrefs.GetInt("StTock", 0);
        st_tock_TMP.text = $"St. tock: {st_tock}";
    }
}

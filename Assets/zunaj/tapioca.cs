using UnityEngine;

public class tapioca : MonoBehaviour {
    public static int st_tapioce;
    void Start() {
        st_tapioce=0;
    }

    private void OnMouseDown() {
        System.Random random = new System.Random();
        if (st_tapioce<20) {
            st_tapioce = st_tapioce+random.Next(1, 4);
        }
    }
}

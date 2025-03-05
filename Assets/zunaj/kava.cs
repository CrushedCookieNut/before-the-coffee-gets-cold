using UnityEngine;

public class kava : MonoBehaviour {
    public static int st_kave;
    public static int st_coko_sirupa;
    void Start() {
        st_kave=0;
        st_coko_sirupa=0;
    }

    private void OnMouseDown() {
        System.Random random = new System.Random();
        int kava_ali_sirup = random.Next(1, 3);
        if (kava_ali_sirup==1) {
            if (st_kave<20) {
                st_kave = st_kave+random.Next(1, 4);
            }
        } else {
            if (st_coko_sirupa<20) {
                st_coko_sirupa = st_coko_sirupa+random.Next(1, 4);
            }
        }
    }
}

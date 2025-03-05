using UnityEngine;

public class drevo1 : MonoBehaviour {
    public static int st_jagode;
    public static int st_manga;
    void Start() {
        st_jagode=0;
        st_manga=0;
    }

    private void OnMouseDown() {
        System.Random random = new System.Random();
        int jagode_ali_manga = random.Next(1, 3);
        if (jagode_ali_manga==1) {
            if (st_jagode<20) {
                st_jagode = st_jagode+random.Next(1, 4);
            }
        } else {
            if (st_manga<20) {
                st_manga = st_manga+random.Next(1, 4);
            }
        }
    }
}

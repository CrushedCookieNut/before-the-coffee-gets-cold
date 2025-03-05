using UnityEngine;

public class drevo2 : MonoBehaviour {
    public static int st_malin;
    public static int st_robid;
    void Start() {
        st_malin=0;
        st_robid=0;
    }

    private void OnMouseDown() {
        System.Random random = new System.Random();
        int malin_ali_robid = random.Next(1, 3);
        if (malin_ali_robid==1) {
            if (st_malin<20) {
                st_malin = st_malin+random.Next(1, 4);
            }
        } else {
            if (st_robid<20) {
                st_robid = st_robid+random.Next(1, 4);
            }
        }
    }
}

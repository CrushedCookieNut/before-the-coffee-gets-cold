using UnityEngine;

public class kravica : MonoBehaviour {
    public static int st_mleka;
    public static int st_smetane;
    void Start() {
        st_mleka=0;
        st_smetane=0;
    }

    private void OnMouseDown() {
        System.Random random = new System.Random();
        int mlek_ali_smet = random.Next(1, 3);
        if (mlek_ali_smet==1) {
            if (st_mleka<20) {
                st_mleka = st_mleka+random.Next(1, 4);
            }
        } else {
            if (st_smetane<20) {
                st_smetane = st_smetane+random.Next(1, 4);
            }
        }
    }
}

using UnityEngine;

public class mini_drev : MonoBehaviour {
    public static int st_matche;
    public static int st_kamilice;
    public static int st_crnega;
    public static int st_mete;
    public static int st_melise;
    void Start() {
        st_matche=0;
        st_kamilice=0;
        st_crnega=0;
        st_mete=0;
        st_melise=0;
    }

    private void OnMouseDown() {
        System.Random random = new System.Random();
        int match_ali_kamil_ali_crni_ali_met_ali_mel = random.Next(1, 6);
        if (match_ali_kamil_ali_crni_ali_met_ali_mel==1) {
            if (st_matche<20) {
                st_matche = st_matche+random.Next(1, 4);
            }
        } else if (match_ali_kamil_ali_crni_ali_met_ali_mel==2) {
            if (st_kamilice<20) {
                st_kamilice = st_kamilice+random.Next(1, 4);
            }
        } else if (match_ali_kamil_ali_crni_ali_met_ali_mel==3) {
            if (st_crnega<20) {
                st_crnega = st_crnega+random.Next(1, 4);
            }
        } else if (match_ali_kamil_ali_crni_ali_met_ali_mel==4) {
            if (st_mete<20) {
                st_mete = st_mete+random.Next(1, 4);
            }
        } else {
            if (st_melise<20) {
                st_melise = st_melise+random.Next(1, 4);
            }
        }   
    }
}

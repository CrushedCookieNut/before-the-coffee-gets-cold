using Unity.Netcode;
using UnityEngine;

public class networkManager : MonoBehaviour {
    void Awake() {
        DontDestroyOnLoad(gameObject);
    }
}
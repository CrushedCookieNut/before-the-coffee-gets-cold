using UnityEngine;
using Unity.Netcode;
using TMPro;
using UnityEngine.SceneManagement;
using System.Net;

public class ClientManager : MonoBehaviour {
    public TMP_InputField ipInputField;

    public void ConnectToServer() {
        if (!string.IsNullOrEmpty(ipInputField.text)) {
            NetworkManager.Singleton.GetComponent<Unity.Netcode.Transports.UTP.UnityTransport>().ConnectionData.Address = ipInputField.text;
            NetworkManager.Singleton.StartClient();
            //SceneManager.LoadScene("MainGame", LoadSceneMode.Single);
        }
    }
}



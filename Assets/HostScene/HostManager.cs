using UnityEngine;
using Unity.Netcode;
using UnityEngine.SceneManagement;
using TMPro;
using System.Net;

public class HostManager : MonoBehaviour {
    public GameObject playerPrefab;
    public TextMeshProUGUI ipDisplay;
    
    public void StartHost() {
        string localIP = GetLocalIPAddress();
        if (ipDisplay != null) {
            ipDisplay.text = $"Host IP: {localIP}";
        }
        
        NetworkManager.Singleton.StartHost();
        NetworkManager.Singleton.OnClientConnectedCallback += OnClientConnected;
        SpawnPlayer(NetworkManager.Singleton.LocalClientId);
    }

    private void OnClientConnected(ulong clientId) {
        SpawnPlayer(clientId);
        if (NetworkManager.Singleton.ConnectedClients.Count > 1) {
            Debug.Log("Both players connected, loading game scene...");
            NetworkManager.Singleton.SceneManager.LoadScene("MainGame", LoadSceneMode.Single);
        }
    }

    private void SpawnPlayer(ulong clientId) {
        GameObject player = Instantiate(playerPrefab);
        player.GetComponent<NetworkObject>().SpawnAsPlayerObject(clientId);
    }
    
    private string GetLocalIPAddress() {
        string localIP = "Not Available";
        foreach (var address in Dns.GetHostAddresses(Dns.GetHostName())) {
            if (address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork) {
                localIP = address.ToString();
                break;
            }
        }
        return localIP;
    }
}
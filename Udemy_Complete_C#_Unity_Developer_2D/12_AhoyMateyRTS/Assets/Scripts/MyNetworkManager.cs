using UnityEngine;
using UnityEngine.Networking;

public class MyNetworkManager : NetworkManager {
    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    public void MyStartHost() {
        StartHost();
    }

    public override void OnStartHost() {
        Debug.Log(Time.timeSinceLevelLoad + " Start Host " + networkAddress);
        base.OnStartHost();
    }

    public override void OnStopHost() {
        Debug.Log(Time.timeSinceLevelLoad + " Stop Host " + networkAddress);
        base.OnStartHost();
    }

    public override void OnStartClient(NetworkClient client) {
        Debug.Log(Time.timeSinceLevelLoad + " Client start requested.");
        InvokeRepeating("PrintDot", 0f, 1f);
        base.OnStartClient(client);
    }

    public override void OnClientConnect(NetworkConnection conn) {
        Debug.Log(Time.timeSinceLevelLoad + " Client is connect to IP: " + conn.address);
        CancelInvoke();
    }

    public void PrintDot() {
        Debug.Log(".");
    }
}

using UnityEngine;
using System.Collections;

public class WallBump : MonoBehaviour {

    GameObject socket;
	// Use this for initialization
	void Start () {
        socket = GameObject.FindGameObjectWithTag("Socket");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter()
    {
        socket.SendMessage("WallCollide");
    }
}

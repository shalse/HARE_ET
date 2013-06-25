using UnityEngine;
using System.Collections;

public class MazeFinish : MonoBehaviour {

    GameObject mazeGUI, player, socket;
	// Use this for initialization
	void Start () {
        mazeGUI = GameObject.FindGameObjectWithTag("GUI");
        player = GameObject.FindGameObjectWithTag("Player");
        socket = GameObject.FindGameObjectWithTag("Socket");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("You win");
            mazeGUI.SendMessage("ChangeGS", "restart");
            player.SendMessage("StopPlaying");
            socket.SendMessage("MazeEnded");
            socket.SendMessage("PostData");
        }
    }
}

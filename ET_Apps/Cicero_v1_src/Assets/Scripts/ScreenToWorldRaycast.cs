using UnityEngine;
using System.Collections;

public class ScreenToWorldRaycast : MonoBehaviour {

    Vector3 mouseWorldPos;
    RaycastHit outClick;
    public GameObject shane;

    bool isShaneSpeak = true;
    public int numClicks;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log("blargh");
        mouseWorldPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 20f)); //translation from the world to the game
	
        if(Input.GetMouseButtonDown(0)){//When you left mouse click
            if(numClicks > 0 && !isShaneSpeak && Physics.Raycast(transform.position, mouseWorldPos-transform.position, out outClick, 30f))
            {
                //Debug.Log(int.Parse(outClick.collider.name));
                numClicks--;
                outClick.collider.SendMessage("LightUp");
                shane.SendMessage("Repeat", int.Parse(outClick.collider.name));
            }

            //Debug.Log("X: " + mouseWorldPos.x + "   Y: " + mouseWorldPos.y + "   Z: " + mouseWorldPos.z);
        }
	}

    void ShaneSpeak()
    {
        //Debug.Log("Shane is Speaking");
        isShaneSpeak = true;
    }

    void ShaneStop()
    {
        //Debug.Log("Shane is not speaking");
        isShaneSpeak = false;
    }

    void SetClicks(int num)
    {
        numClicks = num;
    }
}

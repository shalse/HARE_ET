using UnityEngine;
using System.Collections;

public class ScreenToWorldRaycast : MonoBehaviour
{

    Vector3 mouseWorldPos, posDifference;
    bool isPlaying = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isPlaying)
            MoveBall();
    }

    void MoveBall()
    {
        mouseWorldPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 49.5f)); //translation from the world to the game
        posDifference = mouseWorldPos - transform.position;

        if (posDifference.sqrMagnitude > 3)
            rigidbody.AddForce(posDifference.normalized, ForceMode.VelocityChange);
    }

    void StartPlaying()
    {
        isPlaying = true;
    }

    void StopPlaying()
    {
        isPlaying = false;
    }
}

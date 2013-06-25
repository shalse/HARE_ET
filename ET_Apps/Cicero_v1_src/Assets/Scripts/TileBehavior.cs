using UnityEngine;
using System.Collections;

public class TileBehavior : MonoBehaviour {

    public Material shiny;      //Shiny overlay
    public Material transparent;//Not shiny overlay
    //public Material[] materialSet;

    public Color brightColor;
    public Color darkColor;

	// Use this for initialization
	void Start () {
	    //materialSet = renderer.materials;
        //darkColor = renderer.material.color;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    IEnumerator LightUp()//Brightens this object for a second
    {
        audio.Play();
        darkColor = renderer.material.color;
        brightColor = new Color(darkColor.r * 4, darkColor.g * 4, darkColor.b * 4);

        renderer.material.color = brightColor;
        yield return new WaitForSeconds(.5f);
        renderer.material.color = darkColor;

        //Debug.Log("LightUp");
        //materialSet[1] = shiny;
        //renderer.materials = materialSet;
        //materialSet[1] = transparent;
        //renderer.materials = materialSet;
    }
}

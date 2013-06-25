using UnityEngine;
using System.Collections;

public class ShaneSez : MonoBehaviour
{

    public GameObject[] tiles = new GameObject[4];  //The four clicking boxes players must interact with

    public Color[] tileColors = new Color[4];       //The four colors, one for each box
    public Vector3[] tilePos = new Vector3[4];      //The four positions, one for each box
    AudioClip[] tileSounds = new AudioClip[4];      //The four sounds played when a box is selected e.g. RED, BLUE etc...

    public GameObject player;   //The empty which handles raycasting
    public GameObject shaneGUI; //GUI controller
    public GameObject socket;   //web socket LinkSyncSCR
    public GameObject bigWhiteX;//the big X that appears when you incorrectly answer

    public int[] repeatMe;      //Pre-generated sequence
    public int difficulty = 1500; //How many before the game is done

    public int sequence;        //How many for this stage of gameplay
    public int seqStep = 3;     //How many are added to each stage at completion of a particular stage
    public int answers = 0;     //How many answered correctly for this stage
    public int failures = 0;    //How many times missed a pattern (3 max)
    public int failureMax = 3;  //Max times a player can fail

    public bool isColorDifferent = false;
    public bool isPosDifferent = false;

    public GUISkin defaultSkin;
    int screenWidth;
    int screenHeight;

    //Raycast variable section, transcluded from "ScreenToWorldRaycast.cs"
    Vector3 mouseWorldPos;
    RaycastHit outClick;
    //public GameObject shane;

    bool isShaneSpeak = true;
    int numClicks;

    // Use this for initialization
    void Start()
    {
        screenWidth = Screen.width;
        screenHeight = Screen.height;
        isShaneSpeak = true;
    }

    // Update is called once per frame
    void Update()
    {
        mouseWorldPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 20f)); //translation from the world to the game

        if (Input.GetMouseButtonDown(0))
        {//When you left mouse click
            if (numClicks > 0 && !isShaneSpeak && Physics.Raycast(transform.position, mouseWorldPos - transform.position, out outClick, 30f))
            {
                //Debug.Log(int.Parse(outClick.collider.name));
                numClicks--;
                outClick.collider.SendMessage("LightUp");
                Repeat(int.Parse(outClick.collider.name));
                //shane.SendMessage("Repeat", int.Parse(outClick.collider.name));
            }

            //Debug.Log("X: " + mouseWorldPos.x + "   Y: " + mouseWorldPos.y + "   Z: " + mouseWorldPos.z);
        }
    }

    void StartGame()
    {
        repeatMe = new int[difficulty];
        sequence = seqStep;
        failures = failureMax;

        for (int i = 0; i < difficulty; i++)
        {//Fills it with random numbers
            repeatMe[i] = Random.Range(0, 4);
        }

        for (int j = 0; j < 4; j++)//initialize the positions and colors that could change later
        {
            tileColors[j] = tiles[j].renderer.material.color;
            tilePos[j] = tiles[j].transform.position;
            tileSounds[j] = tiles[j].audio.clip;
        }

        StartCoroutine(Say(false));
    }

    IEnumerator Say(bool sayAgain)//Go through sequence to repeat
    {
        //player.SendMessage("ShaneSpeak");
        isShaneSpeak = true;
        yield return new WaitForSeconds(2f);//Give a small pause

        if (!sayAgain)//Not a simple repeat in case of a fail; change either colors or positions, based on options
        {
            if (isColorDifferent)//Moves colors around, but the relationship of the pattern is still same
            {                    //Attempts to keep the sounds matched upon the colors e.g. RED = red colored tile
                Color tempColor;
                AudioClip tempAudio;
                int tempIndex;
                for (int i = 0; i < 4; i++)//Randomize the colors
                {
                    tempIndex = Random.Range(0, 3);

                    tempColor = tileColors[i];
                    tileColors[i] = tileColors[tempIndex];
                    tileColors[tempIndex] = tempColor;

                    tempAudio = tileSounds[i];
                    tileSounds[i] = tileSounds[tempIndex];
                    tileSounds[tempIndex] = tempAudio;
                }

                for (int j = 0; j < 4; j++)//Set the gameobject colors and sounds
                {
                    tiles[j].renderer.material.color = tileColors[j];
                    tiles[j].audio.clip = tileSounds[j];
                }
            }

            if (isPosDifferent)//Moves the relationship of the pattern, but keeps colors in the same relative positions
            {
                Vector3 tempPos;
                int tempIndex;
                //for (int i = 0; i < 4; i++)//Remember original color scheme
                //{
                //    tileColors[i] = tiles[i].renderer.material.color;
                //}

                for (int j = 0; j < 4; j++)//Randomize the positions
                {
                    tempIndex = Random.Range(0, 3);
                    tempPos = tilePos[j];
                    tilePos[j] = tilePos[tempIndex];
                    tilePos[tempIndex] = tempPos;
                }

                for (int k = 0; k < 4; k++)//Set the gameobject positions
                {
                    tiles[k].transform.position = tilePos[k];
                }
            }
        }

        for (int i = 0; i < sequence; i++)//Actually say the sequence
        {
            //Debug.Log("sequence" + i);
            yield return new WaitForSeconds(1);
            tiles[repeatMe[i]].SendMessage("LightUp");
        }

        //player.SendMessage("SetClicks", sequence);
        numClicks = sequence;

        yield return new WaitForSeconds(1);

        //player.SendMessage("ShaneStop");
        isShaneSpeak = false;
    }

    void Repeat(int answer)//Reception of an answer from the raycasting player
    {
        //player.SendMessage("ShaneSpeak");
        isShaneSpeak = true;
        if (answer == repeatMe[answers])//answered correctly
        {
            //Debug.Log("good!");
            answers++;
            if (answers == sequence)//answered the whole pattern, thus far
            {
                answers = 0;
                sequence += seqStep;
                StartCoroutine(Say(false));
            }
        }
        else
        {
            StartCoroutine(FailureAlert());
            audio.Play();
            failures--;
            socket.SendMessage("Fail", sequence);
            if (failures == 0)//messed up failureMax times over the course of a whole game
            {
                socket.SendMessage("PuzzleEnded");
                socket.SendMessage("PostData");                 //Game over, just gonna send data
                shaneGUI.SendMessage("ChangeGS", "restart");    //Starts game over
                //player.SendMessage("ShaneSpeak");               //Player cannot move, now
                isShaneSpeak = true;                            //Player cannot move, now
            }
            else
            {//Not the third failure, repeats the sequence to date without randomizing
                answers = 0;
                StartCoroutine(Say(true));
            }

            //Debug.Log("bad...");
        }
        //player.SendMessage("ShaneStop");
        isShaneSpeak = false;
    }

    void OnGUI()
    {
        GUI.skin = defaultSkin;
        if(failures > 0)
        {
            GUI.Box(new Rect(75, 75, 100, 100), "Lives");
            GUI.Label(new Rect(90, 115, 71, 40), failures.ToString());
        }
    }

    IEnumerator FailureAlert()
    {
        bigWhiteX.renderer.enabled = true;
        yield return new WaitForSeconds(1);
        bigWhiteX.renderer.enabled = false;
    }

    void SetColor(bool isDiff)//Colors set to move, but pattern remains same
    {
        isColorDifferent = isDiff;
    }

    void SetPos(bool isDiff)//Patter set to move, but colors remain same order
    {
        isPosDifferent = isDiff;
    }

    void SetIncremental(int step)//How many more things to repeat each time
    {
        seqStep = step;
        //Debug.Log("Step is " + step);
    }

}

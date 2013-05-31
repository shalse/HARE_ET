using UnityEngine;
using System.Collections;

public class ShaneSez : MonoBehaviour
{

    public GameObject[] tiles = new GameObject[4];  //The four clicking boxes players must interact with

    public Color[] tileColors = new Color[4];       //The four colors, one for each box
    public Vector3[] tilePos = new Vector3[4];      //The four positions, one for each box

    public GameObject player;   //The empty which handles raycasting
    public GameObject shaneGUI; //GUI controller
    public GameObject socket;   //web socket LinkSyncSCR

    public int[] repeatMe;      //Pre-generated sequence
    public int difficulty = 1500; //How many before the game is done

    public int sequence;        //How many for this stage of gameplay
    public int seqStep = 3;     //How many are added to each stage at completion of a particular stage
    public int answers = 0;     //How many answered correctly for this stage
    public int failures = 0;    //How many times missed a pattern (3 max)

    public bool isColorDifferent = false;
    public bool isPosDifferent = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void StartGame()
    {
        repeatMe = new int[difficulty];
        sequence = seqStep;

        for (int i = 0; i < difficulty; i++)
        {//Fills it with random numbers
            repeatMe[i] = Random.Range(0, 4);
        }

        for (int j = 0; j < 4; j++)//initialize the positions and colors that could change later
        {
            tileColors[j] = tiles[j].renderer.material.color;
            tilePos[j] = tiles[j].transform.position;
        }

        StartCoroutine(Say(false));
    }

    IEnumerator Say(bool sayAgain)//Go through sequence to repeat
    {
        player.SendMessage("ShaneSpeak");
        yield return new WaitForSeconds(2f);//Give a small pause

        if (!sayAgain)//Not a simple repeat in case of a fail
        {
            if (isColorDifferent)//Moves colors around, but the relationship of the pattern is still same
            {
                Color tempColor;
                int tempIndex;
                for (int i = 0; i < 4; i++)//Randomize the colors
                {
                    tempIndex = Random.Range(0, 3);
                    tempColor = tileColors[i];
                    tileColors[i] = tileColors[tempIndex];
                    tileColors[tempIndex] = tempColor;
                }

                for (int j = 0; j < 4; j++)//Set the gameobject colors
                {
                    tiles[j].renderer.material.color = tileColors[j];
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

        player.SendMessage("SetClicks", sequence);

        yield return new WaitForSeconds(1);

        player.SendMessage("ShaneStop");
    }

    void Repeat(int answer)//Reception of an answer from the raycasting player
    {
        player.SendMessage("ShaneSpeak");
        if (answer == repeatMe[answers])
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
            failures++;
            socket.SendMessage("Fail", sequence);
            if (failures == 3)//messed up 3 times over the course of a whole game
            {
                socket.SendMessage("PuzzleEnded");
                socket.SendMessage("PostData");                 //Game over, just gonna send data
                shaneGUI.SendMessage("ChangeGS", "restart");    //Starts game over
                player.SendMessage("ShaneSpeak");               //Player cannot move, now
            }
            else
            {//Not the third failure, repeats the sequence to date without randomizing
                answers = 0;
                StartCoroutine(Say(true));
            }

            //Debug.Log("bad...");
        }
        player.SendMessage("ShaneStop");
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

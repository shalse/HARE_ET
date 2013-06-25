using UnityEngine;
using System.Collections;
using System.Net;
using System.Net.Sockets;

public class ShaneGUI : MonoBehaviour
{
    string gameState = "start";
    int pattern = 0, puzzleStep = 0;
    string serverIP = "127.0.0.1";
    public GameObject gameGenerator, socket, nittanySplash;
    //string[] stepStrings = new string[] { "1", "2", "3", "4" };
    GUIContent[] stepStrings = new GUIContent[]{new GUIContent("1", "One at a time"),
                                                new GUIContent("2", "Two at a time"),
                                                new GUIContent("3", "Three at a time"),
                                                new GUIContent("4", "Four at a time")};
    //string[] pattStrings = new string[] { "Normal", "Color Only", "Position Only" };
    GUIContent[] pattStrings = new GUIContent[] {new GUIContent("Normal", "Everything stays the same"),
                                                 new GUIContent("Color Only", "Colors change and relative positions stay the same"),
                                                 new GUIContent("Position Only", "Positions change and colors stay the same")};

    int screenWidth;
    int screenHeight;
    public GUISkin defaultSkin; //Skin is a combination of all the GUI elements' properties

    // Use this for initialization
    void Start()
    {
        screenWidth = Screen.width;
        screenHeight = Screen.height;
        IPHostEntry host;
        string localIP = "";
        host = Dns.GetHostEntry(Dns.GetHostName());
        foreach (IPAddress ip in host.AddressList)
        {
            if (ip.AddressFamily == AddressFamily.InterNetwork)
            {
                localIP = ip.ToString();
            }
        }
        serverIP = localIP;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))//pressing escape will open the menu while playing
        {
            if (gameState != "start")//escape only works when the game is being played
            {
                StopAllCoroutines();
                gameState = "escape";
            }
        }
    }

    void OnGUI()
    {
        GUI.skin = defaultSkin;

        switch (gameState)
        {
            case "start":
                StartMenu();
                break;
            case "restart":
                RestartMenu();
                break;
            case "options":
                OptionsMenu();
                break;
            case "adminoptions":
                AdminOptionsMenu();
                break;
            case "escape":
                EscapeMenu();
                break;
            case "credits":
                CreditsMenu();
                break;
            default:
                break;
        }
    }

    void StartMenu()//Only at beginning, gets confirmation you want to play and then begins the pattern
    {
        GUI.Box(new Rect(screenWidth / 2 - 150, screenHeight / 2 - 50, 300, 220), "Cicero Dicit Fac Hoc");

        if (GUI.Button(new Rect(screenWidth / 2 - 100, screenHeight / 2, 200, 30), "Start Game"))
        {
            StartGame();
        }

        if (GUI.Button(new Rect(screenWidth / 2 - 100, screenHeight / 2 + 40, 200, 30), "Game Options"))
        {
            gameState = "options";
        }

        if (GUI.Button(new Rect(screenWidth / 2 - 100, screenHeight / 2 + 80, 200, 30), "Quit Game"))
        {
            Application.Quit();
        }

        if (GUI.Button(new Rect(screenWidth / 2 - 100, screenHeight / 2 + 120, 200, 30), "Credits"))
        {
            gameState = "credits";
        }
    }

    void RestartMenu()//Every time you fail a maze, asks to start a new one
    {
        GUI.Box(new Rect(screenWidth / 2 - 150, screenHeight / 2 - 75, 300, 150), "Game Over");

        if (GUI.Button(new Rect(screenWidth / 2 - 120, screenHeight / 2 - 20, 240, 30), "Click here to start a new game"))
        {
            StartGame();
        }

        if (GUI.Button(new Rect(screenWidth / 2 - 100, screenHeight / 2 + 20, 200, 30), "Main Menu"))
        {
            gameState = "start";
        }
    }

    void OptionsMenu()
    {        
        GUI.Box(new Rect(screenWidth / 2 - 150, screenHeight / 2 - 150, 300, 360), "Game Options");

        GUI.Label(new Rect(screenWidth / 2 - 60, screenHeight / 2 - 25, 120, 35), new GUIContent("Increment", "How many more each round"));
        puzzleStep = GUI.Toolbar(new Rect(screenWidth / 2 - 65, screenHeight / 2 + 20, 130, 20), puzzleStep, stepStrings);

        GUI.Label(new Rect(screenWidth / 2 - 60, screenHeight / 2 + 50, 120, 35), new GUIContent("Patterns", "What changes each round"));
        pattern = GUI.SelectionGrid(new Rect(screenWidth / 2 - 60, screenHeight / 2 + 100, 120, 90), pattern, pattStrings, 1);

        //GUI.Label(new Rect(screenWidth / 2 - 125, screenHeight / 2 + 100, 120, 35), "Master volume:");
        //audioVolume = GUI.HorizontalSlider(new Rect(screenWidth / 2 + 10, screenHeight / 2 + 110, 100, 25), audioVolume, 0.0f, 1.0f);

        if (GUI.Button(new Rect(screenWidth / 2 - 100, screenHeight / 2 - 105, 200, 30), "Main Menu"))
        {
            gameState = "start";
        }

        if (GUI.Button(new Rect(screenWidth / 2 - 100, screenHeight / 2 - 70, 200, 30), "Network Options"))
        {
            gameState = "adminoptions";
        }

        if (!GUI.tooltip.Equals(""))
        {
            GUI.Label(new Rect(Input.mousePosition.x + 15, screenHeight - Input.mousePosition.y, 150, 40), GUI.tooltip);//label for the tooltip
        }
    }

    void AdminOptionsMenu()
    {
        GUI.Box(new Rect(screenWidth / 2 - 150, screenHeight / 2 - 75, 300, 225), "Network Options");

        GUI.Label(new Rect(screenWidth / 2 - 120, screenHeight / 2 + 60, 120, 35), "Server IP:");
        serverIP = GUI.TextField(new Rect(screenWidth / 2 + 10, screenHeight / 2 + 65, 115, 25), serverIP, 20);

        if (GUI.Button(new Rect(screenWidth / 2 - 100, screenHeight / 2 + 5, 200, 30), "Game Options"))
        {
            gameState = "options";
        }

        if (GUI.Button(new Rect(screenWidth / 2 - 100, screenHeight / 2 - 30, 200, 30), "Main Menu"))
        {
            gameState = "start";
        }
    }

    void EscapeMenu()
    {
        GUI.Box(new Rect(screenWidth / 2 - 150, screenHeight / 2 - 75, 300, 250), "Paused");

        if (GUI.Button(new Rect(screenWidth / 2 - 100, screenHeight / 2, 200, 30), "Resume Game"))
        {
            gameState = "";
        }

        if (GUI.Button(new Rect(screenWidth / 2 - 100, screenHeight / 2 + 40, 200, 30), "Start new game"))
        {
            StartGame();
        }

        if (GUI.Button(new Rect(screenWidth / 2 - 100, screenHeight / 2 + 80, 200, 30), "Quit to Main Menu"))
        {
            gameState = "start";
        }
    }

    void CreditsMenu()
    {
        nittanySplash.renderer.enabled = true;

        GUI.Label(new Rect(screenWidth / 2 - 120, screenHeight / 2 - 80, 240, 50), "School of Humanities and Social Sciences");
        GUI.Label(new Rect(screenWidth / 2 - 120, screenHeight / 2 - 20, 240, 50), "School of Engineering");
        GUI.Label(new Rect(screenWidth / 2 - 120, screenHeight / 2 + 40, 240, 50), "Office of Research and Outreach");

        if (GUI.Button(new Rect(screenWidth / 2 - 100, screenHeight / 2 + 180, 200, 30), "Return to Main Menu"))
        {
            nittanySplash.renderer.enabled = false;
            gameState = "start";
        }
    }

    void StartGame()
    {
        gameGenerator.SendMessage("SetIncremental", int.Parse(stepStrings[puzzleStep].text));

        switch (pattStrings[pattern].text)//sets the options to true based on the pattern request
        {
            case "Color Only":
                gameGenerator.SendMessage("SetColor", true);
                gameGenerator.SendMessage("SetPos", false);
                socket.SendMessage("SetColor", true);
                socket.SendMessage("SetPos", false);
                break;
            case "Position Only":
                gameGenerator.SendMessage("SetColor", false);
                gameGenerator.SendMessage("SetPos", true);
                socket.SendMessage("SetColor", false);
                socket.SendMessage("SetPos", true);
                break;
            case "Normal":
                gameGenerator.SendMessage("SetColor", false);
                gameGenerator.SendMessage("SetPos", false);
                socket.SendMessage("SetColor", false);
                socket.SendMessage("SetPos", false);
                break;
        }

        if (!serverIP.Equals("127.0.0.1"))//if this didn't change, no point trying
        {
            socket.SendMessage("SetNetIP", serverIP);
            //socket.SendMessage("AttemptConnect");
        }

        socket.SendMessage("PuzzleBegun", int.Parse(stepStrings[puzzleStep].text));
        gameGenerator.SendMessage("StartGame");

        gameState = "";
    }

    void ChangeGS(string gs)
    {
        gameState = gs;
    }
}

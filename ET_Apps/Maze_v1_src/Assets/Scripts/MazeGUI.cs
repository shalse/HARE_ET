using UnityEngine;
using System.Collections;
using System.Net;
using System.Net.Sockets;

public class MazeGUI : MonoBehaviour
{

    string gameState = "start";
    string countdown = "";
    int M = 10, N = 10, CAMDIST = 10;
    float difficulty = 0.5f, audioVolume = 1.0f;
    string serverIP = "127.0.0.1";
    public GameObject mazeGenerator, player, mainCam, socket, nittanySplash, nittanyBackDrop;

    int screenWidth;
    int screenHeight;
    public GUISkin defaultSkin; //font used for the countdown

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
                player.SendMessage("StopPlaying");
                StopAllCoroutines();
                countdown = "";
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

        if (countdown.Length > 0)
        {
            GUI.Box(new Rect(screenWidth / 2 - 150, screenHeight / 2 - 50, 300, 220), "");
            GUI.Label(new Rect(screenWidth / 2 - 50, screenHeight / 2 - 00, 100, 30), countdown);
            GUI.Label(new Rect(screenWidth / 2 - 82, screenHeight / 2 + 70, 165, 60), "Just look where you want  to go!");
        }
    }

    void StartMenu()//Only at beginning, gets confirmation you want to play and counts down so you can find the starting position
    {
        GUI.Box(new Rect(screenWidth / 2 - 150, screenHeight / 2 - 50, 300, 220), "Gaze Maze");

        if (GUI.Button(new Rect(screenWidth / 2 - 100, screenHeight / 2, 200, 30), "Start Game"))
        {
            StartCoroutine(Countdown(3f));
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

    void RestartMenu()//Every time you finish a maze, asks different questions
    {
        GUI.Box(new Rect(screenWidth / 2 - 150, screenHeight / 2 - 75, 300, 150), "Gaze Maze");

        if (GUI.Button(new Rect(screenWidth / 2 - 110, screenHeight / 2- 30, 220, 30), "Click here to restart the game"))
        {
            StartCoroutine(Countdown(3f));
        }

        if (GUI.Button(new Rect(screenWidth / 2 - 100, screenHeight / 2 + 10, 200, 30), "Main Menu"))
        {
            gameState = "start";
        }
    }

    void OptionsMenu()
    {
        GUI.Box(new Rect(screenWidth / 2 - 150, screenHeight / 2 - 75, 300, 230), "Game Options");

        GUI.Label(new Rect(screenWidth / 2 - 125, screenHeight / 2 + 70, 120, 35), "Difficulty");
        difficulty = GUI.HorizontalSlider(new Rect(screenWidth / 2 + 10, screenHeight / 2 + 80, 100, 25), difficulty, 0.0f, 1.0f);

        //GUI.Label(new Rect(screenWidth / 2 - 125, screenHeight / 2 + 100, 120, 35), "Master volume:");
        //audioVolume = GUI.HorizontalSlider(new Rect(screenWidth / 2 + 10, screenHeight / 2 + 110, 100, 25), audioVolume, 0.0f, 1.0f);

        if (GUI.Button(new Rect(screenWidth / 2 - 100, screenHeight / 2 - 30, 200, 30), "Main Menu"))
        {
            gameState = "start";
        }

        if (GUI.Button(new Rect(screenWidth / 2 - 100, screenHeight / 2 + 5, 200, 30), "Network Options"))
        {
            gameState = "adminoptions";
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
            player.SendMessage("StartPlaying");
            gameState = "";
        }

        if (GUI.Button(new Rect(screenWidth / 2 - 100, screenHeight / 2 + 40, 200, 30), "Start new game"))
        {
            StartCoroutine(Countdown(3f));
        }

        if (GUI.Button(new Rect(screenWidth / 2 - 100, screenHeight / 2 + 80, 200, 30), "Quit to Main Menu"))
        {
            GameObject[] mazePieces = GameObject.FindGameObjectsWithTag("MazeObjects");

            foreach (GameObject piece in mazePieces)
            {
                Destroy(piece);
            }

            gameState = "start";
        }
    }

    void CreditsMenu()
    {
        nittanySplash.renderer.enabled = true;
        nittanyBackDrop.renderer.enabled = true;
        //GUI.Box(new Rect(screenWidth / 2 - 150, screenHeight / 2 - 75, 300, 280), "Credits");

        GUI.Label(new Rect(screenWidth / 2 - 120, screenHeight / 2 - 80, 240, 50), "School of Humanities and Social Sciences");
        GUI.Label(new Rect(screenWidth / 2 - 120, screenHeight / 2 - 20, 240, 50), "School of Engineering");     
        GUI.Label(new Rect(screenWidth / 2 - 120, screenHeight / 2 + 40, 240, 50), "Office of Research and Outreach");
        //GUI.Label(new Rect(screenWidth / 2 - 60, screenHeight / 2 + 90, 120, 25), "Deanna Pettigrew");
        //GUI.Label(new Rect(screenWidth / 2 - 60, screenHeight / 2 + 120, 120, 25), "Tyler something...");

        if (GUI.Button(new Rect(screenWidth / 2 - 100, screenHeight / 2 + 180, 200, 30), "Return to Main Menu"))
        {
            nittanySplash.renderer.enabled = false;
            nittanyBackDrop.renderer.enabled = false;
            gameState = "start";
        }
    }

    IEnumerator Countdown(float t)//counts down for t seconds, then starts the maze
    {
        gameState = "";//no menus are up, now

        //int n = Mathf.Clamp((int)N, 3, 40), //clamping the size of the maze to between 3-40
        //    m = Mathf.Clamp((int)M, 3, 40),
        //    camDist = Mathf.Clamp((int)CAMDIST, 10, 50); //clamping camera distance between 10-50

        N = (int)(5 + difficulty * 35);
        M = (int)(5 + difficulty * 35);
        CAMDIST = (int)(25 + difficulty * 10);

        socket.SendMessage("SetNetIP", serverIP);
        socket.SendMessage("MazeBegun", difficulty);

        mazeGenerator.SendMessage("setM", M);
        mazeGenerator.SendMessage("setN", N);

        mainCam.transform.position = new Vector3(mainCam.transform.position.x, CAMDIST, mainCam.transform.position.z);
        mazeGenerator.SendMessage("GenMaze");
        AudioListener.volume = audioVolume;

        for (float i = 0; i <= t; i++)
        {
            countdown = (t - i).ToString();
            yield return new WaitForSeconds(1f);
        }

        countdown = "PLAY!";
        yield return new WaitForSeconds(1f);
        countdown = "";
        player.SendMessage("StartPlaying");
    }

    void ChangeGS(string gs)
    {
        gameState = gs;
    }
}

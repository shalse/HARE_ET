/*
 * Matthew Kenny
 * ENGR397B
 * 3/26/2013
 * Version 1.0
 * */

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Tree
{//array of nodes, the cost to go up/right and whether it's been visited by the array yet
    public int up;
    public int right;
    public int visited;//0==not visited, 1==visited, -1==never visit
}

public class Maze
{//array of boolean, is there a path up or right on any node
    public bool up;
    public bool right;
}

public class MazeStatic : MonoBehaviour
{
    //public const int M = 20;//Columns
    //public const int N = 10;//Rows
    public int M = 3;
    public int N = 3;

    public float wallStep = 3;

    //public struct Tree
    //{//array of nodes, the cost to go up/right and whether it's been visited by the array yet
    //    public int up;
    //    public int right;
    //    public int visited;//0==not visited, 1==visited, -1==never visit
    //};

    public struct MinNode
    {//not used as an array, the next node to build in the maze array
        public int i;
        public int j;
        public int cost;
        public string dir;
    };

    //public struct Maze
    //{//array of boolean, is there a path up or right on any node
    //    public bool up;
    //    public bool right;
    //};

    public MinNode min;
    //public Tree[,] tree = new Tree[M + 1, N + 1];
    //public Maze[,] maze = new Maze[M + 1, N + 1];

    public List<List<Tree>> tree = new List<List<Tree>>();
    public List<List<Maze>> maze = new List<List<Maze>>();
    public List<Tree> tempTreeList = new List<Tree>();
    public List<Maze> tempMazeList = new List<Maze>();

    public GameObject lateralWall;
    public GameObject verticalWall;
    public GameObject nodeCenter;

    public GameObject player;
    public GameObject begin;
    public GameObject end;

    GameObject[] mazePieces;

    void Start()
    {
    }

    void Update()
    {

    }

    void GenMaze()
    {
        mazePieces = GameObject.FindGameObjectsWithTag("MazeObjects");

        foreach (GameObject piece in mazePieces)
        {
            Destroy(piece);
        }

        tree = new List<List<Tree> >();
        maze = new List<List<Maze> >();
        Tree tempTree;
        Maze tempMaze;
        for (int i = 0; i <= M; i++)
        {
            tempTreeList = new List<Tree>();
            tempMazeList = new List<Maze>();
            for (int j = 0; j <= N; j++)
            {
                tempTree = new Tree();
                tempTree.right = (int)(Random.Range(1, 100));
                tempTree.up = (int)(Random.Range(1, 100));
                tempTree.visited = 0;
                tempTreeList.Add(tempTree);

                tempMaze = new Maze();
                tempMaze.right = false;
                tempMaze.up = false;
                tempMazeList.Add(tempMaze);
            }
            tree.Add(tempTreeList);
            maze.Add(tempMazeList);
        }

        for (int i = 0; i <= M; i++)//top row are there so that i+1 doesn't error out
        {
            tree[i][N].visited = -1;//setting to negative one so algorithm doesn't try to make a path there
            tree[i][N - 1].up = 1000000;//setting next to top row up direction to higher than max, and thus will never be used
        }

        for (int j = 0; j <= N; j++)//far right column are there so that j+1 doesn't error out
        {
            tree[M][j].visited = -1;//setting to negative one so algorithm doesn't try to make a path there
            tree[M - 1][j].right = 1000000;//setting next to far right column right direction to higher than max, and thus will never be used
        }

        min.cost = 1000;

        tree[(int)(Random.Range(0, M - 1))][(int)(Random.Range(0, N - 1))].visited = 1;//some random tree node gets to be the beginning 

        for (int num = 0; num < M * N - 1; num++)
        {//M*N-1 edges need generated
            min.cost = 1000; //need to reset minimum cost
            for (int i = 0; i < M; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    //Debug.Log("ON: (" + i + "," + j + ") VISITED: " + tree[i][j].visited);
                    if (tree[i][j].visited == 1)
                    {//Are we on a visited node, 
                        if (tree[i + 1][j].visited == 0)
                        {//looking to a node not visited to our right
                            if (tree[i][j].right < min.cost)
                            {
                                min.i = i;
                                min.j = j;
                                min.cost = tree[i][j].right;
                                min.dir = "right";
                            }
                        }
                    }
                    if (tree[i][j].visited == 1)
                    {//Are we on a visited node,
                        if (tree[i][j + 1].visited == 0)
                        {//looking to a node not visited above us
                            if (tree[i][j].up < min.cost)
                            {
                                min.i = i;
                                min.j = j;
                                min.cost = tree[i][j].up;
                                min.dir = "up";
                            }
                        }
                    }
                    if (tree[i][j].visited == 0)
                    {//Are we on a not visited node,
                        if (tree[i + 1][j].visited == 1)
                        {//looking to a node we've visited to our right
                            if (tree[i][j].right < min.cost)
                            {
                                min.i = i;
                                min.j = j;
                                min.cost = tree[i][j].right;
                                min.dir = "right";
                            }
                        }
                    }
                    if (tree[i][j].visited == 0)
                    {//Are we on a not visited node, 
                        if (tree[i][j + 1].visited == 1)
                        {//looking to a node we've visited above us
                            if (tree[i][j].up < min.cost)
                            {
                                min.i = i;
                                min.j = j;
                                min.cost = tree[i][j].up;
                                min.dir = "up";
                            }
                        }
                    }
                }
            }
            if (min.dir == "up")
            {
                maze[min.i][min.j].up = true;
                tree[min.i][min.j].visited = 1;//node I'm on is now visited
                tree[min.i][min.j + 1].visited = 1;//node I'm moving to is visited
                //Debug.Log("--------------NODE: (" + min.i + "," + min.j + ") MOVING UP");
            }
            if (min.dir == "right")
            {
                maze[min.i][min.j].right = true;
                tree[min.i][min.j].visited = 1;//node I'm on now is visited
                tree[min.i + 1][min.j].visited = 1;//node I'm moving to is visited
                //Debug.Log("--------------NODE: (" + min.i + "," + min.j + ") MOVING RIGHT");
            }
            //min.cost = 10000;
        }

        for (int i = 0; i < M; i++)//direction values set to true mean an open path
        {                          //false means a wall is instantiated
            for (int j = 0; j < N; j++)
            {
                if (!maze[i][j].right)
                {
                    Instantiate(verticalWall, new Vector3((wallStep * i) + wallStep / 2, 0, wallStep * j), Quaternion.identity);
                }
                if (!maze[i][j].up)
                {
                    Instantiate(lateralWall, new Vector3(wallStep * i, 0, (wallStep * j) + wallStep / 2), Quaternion.identity);
                }
                //Instantiate(nodeCenter, new Vector3(wallStep * i, 0, wallStep * j), Quaternion.identity);
                //Debug.Log("Node " + i + ", " + j + ": UP=" + maze[i][j].up + " VALUE: " + tree[i][j].up + " RIGHT: " + maze[i][j].right + " VALUE: " + tree[i][j].right);
            }
        }
        for (int i = 0; i < M; i++)
        {
            Instantiate(lateralWall, new Vector3(wallStep * i, 0, -(wallStep / 2)), Quaternion.identity);
        }
        for (int j = 0; j < N; j++)
        {
            Instantiate(verticalWall, new Vector3(-(wallStep / 2), 0, wallStep * j), Quaternion.identity);
        }

        int beginM = Random.Range(0, M);//spots for instantiating the 
        int beginN = Random.Range(0, N);//prefabs that are the beginning
        int endM = Random.Range(0, M);  //and end of the maze
        int endN = Random.Range(0, N);

        while ((beginM == endM) && (beginN == endN))//make sure the beginning and end aren't same spot
        {
            endM = Random.Range(0, M);  //recalc a random spot for the end
            endN = Random.Range(0, N);
        }

        player.transform.position = new Vector3(beginM * wallStep, 0, beginN * wallStep);
        Instantiate(begin, new Vector3(beginM * wallStep, 0, beginN * wallStep), Quaternion.identity);
        Instantiate(end, new Vector3(endM * wallStep, 0, endN * wallStep), Quaternion.identity);
    }

    public void setM(int m)
    {
        M = m;
    }

    public int getM()
    {
        return M;
    }

    public void setN(int n)
    {
        N = n;
    }

    public int getN()
    {
        return N;
    }
}
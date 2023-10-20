using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class WalkerGenerator : MonoBehaviour
{
    public enum Grid
    {
        FLOOR,

        WALL,

        EMPTY,

    }

    public int me = 1;
    public int ry = 1;
    public int em = 1;
    public int galp = 1;

    FollowEnemy  spawn;
    
    public GameObject altin;
    public GameObject elmas;
    public GameObject ametist;
    public GameObject demir;
    public GameObject titanyum;
    public GameObject mayýn;
    public GameObject drone;
    public GameObject allahaakbar;

    private GameObject instantiatedObj;

    public List<Vector3> EnemyTiles;

    public Grid[,] gridHandler;

    public List<WalkerObject> Walkers;

    public Tilemap tileMap;

    public Tilemap tileMapC;

    public Tile Floor;

    public Tile Wall;

    public int MapWidth = 30;

    public int MapHeight = 30;

    public int MaximumWalkers = 10;

    public int TileCount = default;

    public float FillPercentage = 0.4f;

    public float WaitTime = 0.05f;


    void Start()
    {
        InitializeGrid();
    }

    void InitializeGrid()
    {
        gridHandler = new Grid[MapWidth, MapHeight];
        for (int x=0; x < gridHandler.GetLength(0); x++ )
        {
            for (int y=0; y < gridHandler.GetLength(1); y++)
            {
                gridHandler[x, y] = Grid.EMPTY;
            }
        }

        Walkers = new List<WalkerObject>();

        Vector3Int TileCenter = new Vector3Int(gridHandler.GetLength(0) / 2, gridHandler.GetLength(1) / 2, 0);

        WalkerObject curWalker = new WalkerObject(new Vector2(TileCenter.x, TileCenter.y), GetDirection(), 0.5f);   
        gridHandler[TileCenter.x, TileCenter.y] = Grid.FLOOR;
        tileMap.SetTile(TileCenter, Floor);
        Walkers.Add(curWalker);

        TileCount++;

        StartCoroutine(CreateFloors());
    }

    Vector2 GetDirection()
    {
        int choice = Mathf.FloorToInt(UnityEngine.Random.value * 3.99f);

        switch (choice)
        {
            case 0:
                return Vector2.down;
            case 1:
                return Vector2.left;
            case 2:
                return Vector2.up;
            case 3:
                return Vector2.right;
            default:
                return Vector2.zero;
        }
    }

    IEnumerator CreateFloors()
    {
        while ((float)TileCount / (float)gridHandler.Length < FillPercentage)
        {
            bool hasCreatedFloor = false;
            foreach (WalkerObject curWalker in Walkers)
            {
                Vector3Int curPos = new Vector3Int((int)curWalker.Position.x, (int)curWalker.Position.y, 0);

                if (gridHandler[curPos.x, curPos.y] != Grid.FLOOR)
                {
                    tileMap.SetTile(curPos, Floor);
                    TileCount++;
                    gridHandler[curPos.x, curPos.y] = Grid.FLOOR;
                    hasCreatedFloor = true;
                    EnemyTiles.Add(curPos);
                }
            }

            ChanceToRemove();
            ChanceToRedirect();
            ChanceToCreate();
            UpdatePosition();


            if (hasCreatedFloor)
            {
                yield return new WaitForSeconds(WaitTime);
            }
        
        }
        StartCoroutine(CreateWalls());
    }

    void ChanceToRemove()
    {
        int updatedCount = Walkers.Count;
        for (int i = 0; i < updatedCount; i++)
        {
            if(UnityEngine.Random.value < Walkers[i].ChanceToChange && Walkers.Count > 1)
            {
                Walkers.RemoveAt(i);
                break;
            }
        }
    }

    void ChanceToRedirect()
    {
        for (int i = 0; i < Walkers.Count; i++)
        {
            if (UnityEngine.Random.value < Walkers[i].ChanceToChange)
            {
                WalkerObject curWalker = Walkers[i];
                curWalker.Direction = GetDirection();
                Walkers[i] = curWalker;
            }
        }
    }

    void ChanceToCreate()
    {
        int updatedCount = Walkers.Count;
        for (int i = 0; i < updatedCount; i++)
        {
            if(UnityEngine.Random.value < Walkers[i].ChanceToChange && Walkers.Count < MaximumWalkers)
            {
                Vector2 newDirection = GetDirection();
                Vector2 newPosition = Walkers[i].Position;

                WalkerObject newWalker = new WalkerObject(newPosition, newDirection, 0.5f);
                Walkers.Add(newWalker);
            }
        }
    }

    void UpdatePosition()
    {
        for(int i = 0; i < Walkers.Count; i++)
        {
            WalkerObject FoundWalker = Walkers[i];
            FoundWalker.Position += FoundWalker.Direction;
            FoundWalker.Position.x = Mathf.Clamp(FoundWalker.Position.x, 1, gridHandler.GetLength(0) - 2);
            FoundWalker.Position.y = Mathf.Clamp(FoundWalker.Position.y, 1, gridHandler.GetLength(1) - 2);
            Walkers[i] = FoundWalker;
        }
    }

   
       


    IEnumerator CreateWalls()
    {
        for(int x = 0; x < gridHandler.GetLength(0) - 1; x++)
        {
            for (int y = 0; y < gridHandler.GetLength(1) - 1; y++)
            {
                if(gridHandler[x,y]== Grid.FLOOR)
                {
                    bool hasCreatedWall = false;

                    if (gridHandler[x + 1, y] == Grid.EMPTY)
                    {
                        tileMapC.SetTile(new Vector3Int(x + 1, y, 0), Wall);
                        gridHandler[x + 1, y] = Grid.WALL;
                        hasCreatedWall = true;
                    }
                    if (gridHandler[x - 1, y] == Grid.EMPTY)
                    {
                        tileMapC.SetTile(new Vector3Int(x - 1, y, 0), Wall);
                        gridHandler[x - 1, y] = Grid.WALL;
                        hasCreatedWall = true;
                    }
                    if (gridHandler[x, y + 1] == Grid.EMPTY)
                    {
                        tileMapC.SetTile(new Vector3Int(x, y + 1 , 0), Wall);
                        gridHandler[x , y + 1] = Grid.WALL;
                        hasCreatedWall = true;
                    }
                    if (gridHandler[x, y - 1] == Grid.EMPTY)
                    {
                        tileMapC.SetTile(new Vector3Int(x, y - 1, 0), Wall);
                        gridHandler[x , y - 1] = Grid.WALL;
                        hasCreatedWall = true;
                    }
                    if (hasCreatedWall)
                    {
                        yield return new WaitForSeconds(WaitTime);
                    }
                } 
            }
        }
    }

    void SpawnOres()
    {
        //Spawn Gold
        for (int m = 0; m < 10; m++)
        {        
            var TileToSpawn = Random.Range(0, EnemyTiles.Count);
            Instantiate(elmas, transform.position = EnemyTiles[TileToSpawn], Quaternion.identity);      
            Debug.Log("ikinci yer ok");
            EnemyTiles.Remove(transform.position = EnemyTiles[TileToSpawn]);         
        }
        for (int e = 0; e < 10; e++)
        {
            var TileToSpawn = Random.Range(0, EnemyTiles.Count);
            Instantiate(ametist, transform.position = EnemyTiles[TileToSpawn], Quaternion.identity);
            Debug.Log("ikinci yer ok");
            EnemyTiles.Remove(transform.position = EnemyTiles[TileToSpawn]);
        }
        for (int r = 0; r < 10; r++)
        {
            var TileToSpawn = Random.Range(0, EnemyTiles.Count);
            Instantiate(demir, transform.position = EnemyTiles[TileToSpawn], Quaternion.identity);
            Debug.Log("ikinci yer ok");
            EnemyTiles.Remove(transform.position = EnemyTiles[TileToSpawn]);
        }
        for (int y = 0; y < 10; y++)
        {
            var TileToSpawn = Random.Range(0, EnemyTiles.Count);
            Instantiate(titanyum, transform.position = EnemyTiles[TileToSpawn], Quaternion.identity);
            Debug.Log("ikinci yer ok");
            EnemyTiles.Remove(transform.position = EnemyTiles[TileToSpawn]);
        }
        for (int mm = 0; mm < 10; mm++)
        {
            var TileToSpawn = Random.Range(0, EnemyTiles.Count);
            Instantiate(altin, transform.position = EnemyTiles[TileToSpawn], Quaternion.identity);
            Debug.Log("ikinci yer ok");
            EnemyTiles.Remove(transform.position = EnemyTiles[TileToSpawn]);
        }
        for (int mmn = 0; mmn < 12; mmn++)
        {
            var TileToSpawn = Random.Range(0, EnemyTiles.Count);
            Instantiate(mayýn, transform.position = EnemyTiles[TileToSpawn], Quaternion.identity);
            Debug.Log("ikinci yer ok");
            EnemyTiles.Remove(transform.position = EnemyTiles[TileToSpawn]);
        }
        for (int mmnn = 0; mmnn < 12; mmnn++)
        {
            var TileToSpawn = Random.Range(0, EnemyTiles.Count);
            Instantiate(drone, transform.position = EnemyTiles[TileToSpawn], Quaternion.identity);
            Debug.Log("ikinci yer ok");
            EnemyTiles.Remove(transform.position = EnemyTiles[TileToSpawn]);
        }
        for (int gs = 0; gs < 8; gs++)
        {
            var TileToSpawn = Random.Range(0, EnemyTiles.Count);
            Instantiate(allahaakbar, transform.position = EnemyTiles[TileToSpawn], Quaternion.identity);
            Debug.Log("ikinci yer ok");
            EnemyTiles.Remove(transform.position = EnemyTiles[TileToSpawn]);
        }

    }

     public void Update()
     {     
        if(EnemyTiles.Count >= 19900)
        {
            Debug.Log("ilk yer ok");
            SpawnOres();
        }
       if(FollowEnemy.caniyok == 0)
       {
            instantiatedObj = (GameObject)Instantiate(allahaakbar, transform.position, Quaternion.identity); ;
            Destroy(instantiatedObj);

       }

     }







}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GenerateLevel : MonoBehaviour
{
    public enum Grid
    {
        PASSMAN,
        BRICK,
        EMPTY
    }

    [Header("Grid Size & Position")]
    public int mapWidth;
    public int mapHeight;
    public int widthOffset;
    public int heightOffset;
    [Header("GameObjects")]
    public GameObject PassManager;
    public GameObject Firewall;
    public GameObject[] Bricks;
    protected Grid[,] grid;
    protected GameObject prent;
    protected List<WalkerObject> Walkers;
    [Header("Information Variables (DO NOT MANUALLY ALTER)")]
    [SerializeField] protected int brickCount = 0;
    [SerializeField] protected int spawnCount = 0;
    [SerializeField] protected int brickValue;
    [SerializeField] protected bool passManInCenter = false;
    [Header("Item Spawn Variables")]
    public int maxWalkers = 10;
    public float fillPercentage = 0.3f;
    public float passManInCenterChance = 0.4f;
    public float firewallSpawnChance = 0.2f;
    public float waitTime = 0.05f;
    [Range(1,100)]
    public float smoothness;

    // Start is called before the first frame update
    void Start()
    {
        brickValue = Bricks.Length / 2;
        prent = Instantiate(new GameObject("Parent"), new Vector3Int(0,0,0), Quaternion.identity);
        InitialiseLevel();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) && brickCount == 0)
        { 
            InitialiseLevel();
        } else if (Input.GetKeyDown(KeyCode.D))
        {
            for( int i = 0;  i < prent.transform.childCount; i++ )
            {
                Destroy(prent.transform.GetChild(i).gameObject);
            }
            brickCount = 0;
            spawnCount = 0;
        }
    }

    

    private void InitialiseLevel()
    {
        ShuffleBricksArray(); // randomise list of bricks to increase diversity between levels

        grid = new Grid[mapWidth, mapHeight];

        for (int x = 0; x < grid.GetLength(0); x++)
        {
            for (int y = 0; y < grid.GetLength(1); y++) 
            {
                grid[x, y] = Grid.EMPTY;
            }
        }

        Walkers = new List<WalkerObject>();

        Vector3Int tileCenter = new Vector3Int(mapWidth / 2, mapHeight / 2, 0);

        WalkerObject newWalker = new WalkerObject(new Vector2(tileCenter.x, tileCenter.y), GetDirection(), 0.5f);

        //Debug.Log("tileCenter = " + tileCenter.x + ", " + tileCenter.y);

        //SpawnSingleBrick(tileCenter);
        
        
        Walkers.Add(newWalker);

        StartCoroutine(PopulateGrid());

    }


    private void ShuffleBricksArray()
    {
        var rng = new System.Random();
        GameObject[] shuffledBricks = Bricks.OrderBy(a => rng.Next()).ToArray();
        Bricks = shuffledBricks;
    }


    

    IEnumerator PopulateGrid()
    {
        // Potentially spawn PM in the center of the grid
        MaybeSpawnPMInCenter();

        // Spawn bricks and firewalls in half of the available space
        while ((float)brickCount / (float)grid.Length < (fillPercentage / 2.0f)) // while amount of tiles < fill percentage...
        {
            bool hasCreatedFloor = false;
            foreach (WalkerObject walker in Walkers)
            {
                Vector3Int position = new Vector3Int((int)walker.position.x, (int)walker.position.y, 0);

                hasCreatedFloor |= SpawnSingleBrick(position);

            }

            // Walker Methods
            ChanceToRemove();
            ChanceToRedirect();
            ChanceToCreate();
            UpdatePosition();

            if (hasCreatedFloor)
            {
                yield return new WaitForSeconds(waitTime);
            }
        }


        // Spawn a Password Manager if not already spawned
        if (!passManInCenter) SpawnPasswordManager();


        // Spawn the rest of the bricks and firewalls
        while ((float)brickCount / (float)grid.Length < fillPercentage) // while amount of tiles < fill percentage...
        {
            bool hasCreatedFloor = false;
            foreach (WalkerObject walker in Walkers)
            {
                Vector3Int position = new Vector3Int((int)walker.position.x, (int)walker.position.y, 0);

                hasCreatedFloor |= SpawnSingleBrick(position);

            }

            // Walker Methods
            ChanceToRemove();
            ChanceToRedirect();
            ChanceToCreate();
            UpdatePosition();

            if (hasCreatedFloor)
            {
                yield return new WaitForSeconds(waitTime);
            }
        }

    }

    private void MaybeSpawnPMInCenter()
    {
        if (UnityEngine.Random.value < passManInCenterChance)
        {
            int x = grid.GetLength(0) / 2;
            int y = grid.GetLength(1) / 2;

            grid[x, y] = Grid.PASSMAN;
            grid[x, y - 1] = Grid.PASSMAN;
            grid[x, y - 2] = Grid.PASSMAN;
            grid[x, y + 1] = Grid.PASSMAN;
            grid[x, y + 2] = Grid.PASSMAN;

            grid[x - 1, y] = Grid.PASSMAN;
            grid[x - 1, y - 1] = Grid.PASSMAN;
            grid[x - 1, y - 2] = Grid.PASSMAN;
            grid[x - 1, y + 1] = Grid.PASSMAN;
            grid[x - 1, y + 2] = Grid.PASSMAN;

            grid[x - 2, y] = Grid.PASSMAN;
            grid[x - 2, y - 1] = Grid.PASSMAN;
            grid[x - 2, y - 2] = Grid.PASSMAN;
            grid[x - 2, y + 1] = Grid.PASSMAN;
            grid[x - 2, y + 2] = Grid.PASSMAN;

            grid[x - 3, y] = Grid.PASSMAN;
            grid[x - 3, y - 1] = Grid.PASSMAN;
            grid[x - 3, y - 2] = Grid.PASSMAN;
            grid[x - 3, y + 1] = Grid.PASSMAN;
            grid[x - 3, y + 2] = Grid.PASSMAN;

            grid[x + 1, y] = Grid.PASSMAN;
            grid[x + 1, y - 1] = Grid.PASSMAN;
            grid[x + 1, y - 2] = Grid.PASSMAN;
            grid[x + 1, y + 1] = Grid.PASSMAN;
            grid[x + 1, y + 2] = Grid.PASSMAN;

            grid[x + 2, y] = Grid.PASSMAN;
            grid[x + 2, y - 1] = Grid.PASSMAN;
            grid[x + 2, y - 2] = Grid.PASSMAN;
            grid[x + 2, y + 1] = Grid.PASSMAN;
            grid[x + 2, y + 2] = Grid.PASSMAN;

            grid[x + 3, y] = Grid.PASSMAN;
            grid[x + 3, y - 1] = Grid.PASSMAN;
            grid[x + 3, y - 2] = Grid.PASSMAN;
            grid[x + 3, y + 1] = Grid.PASSMAN;
            grid[x + 3, y + 2] = Grid.PASSMAN;

            Instantiate(PassManager, new Vector3Int(x + widthOffset, y + heightOffset, 0), Quaternion.identity, prent.transform);
            brickCount += 25;
            passManInCenter = true;

        } 
        else
        {
            passManInCenter = false;
        }
    }

    private void SpawnPasswordManager()
    {
        for (int x = grid.GetLength(0) - 1; x >= 0 ; x--)
        {
            for (int y = grid.GetLength(1) - 1; y >= 0 ; y--)
            {
                if (grid[x, y] == Grid.EMPTY)
                {
                    if (x - 3 >= 0 && y - 2 >= 0 && x + 3 < mapWidth && y + 2 < mapHeight)
                    {
                        if (
                            grid[x, y - 1] == Grid.EMPTY &&
                            grid[x, y + 1] == Grid.EMPTY &&
                            grid[x, y - 2] == Grid.EMPTY &&
                            grid[x, y + 2] == Grid.EMPTY &&

                            grid[x - 1, y] == Grid.EMPTY &&
                            grid[x - 1, y - 1] == Grid.EMPTY &&
                            grid[x - 1, y + 1] == Grid.EMPTY &&
                            grid[x - 1, y - 2] == Grid.EMPTY &&
                            grid[x - 1, y + 2] == Grid.EMPTY &&

                            grid[x - 2, y] == Grid.EMPTY &&
                            grid[x - 2, y - 1] == Grid.EMPTY &&
                            grid[x - 2, y + 1] == Grid.EMPTY &&
                            grid[x - 2, y - 2] == Grid.EMPTY &&
                            grid[x - 2, y + 2] == Grid.EMPTY &&

                            grid[x - 3, y] == Grid.EMPTY &&
                            grid[x - 3, y - 1] == Grid.EMPTY &&
                            grid[x - 3, y + 1] == Grid.EMPTY &&
                            grid[x - 3, y - 2] == Grid.EMPTY &&
                            grid[x - 3, y + 2] == Grid.EMPTY &&

                            grid[x + 1, y] == Grid.EMPTY &&
                            grid[x + 1, y - 1] == Grid.EMPTY &&
                            grid[x + 1, y + 1] == Grid.EMPTY &&
                            grid[x + 1, y - 2] == Grid.EMPTY &&
                            grid[x + 1, y + 2] == Grid.EMPTY &&

                            grid[x + 2, y] == Grid.EMPTY &&
                            grid[x + 2, y - 1] == Grid.EMPTY &&
                            grid[x + 2, y + 1] == Grid.EMPTY &&
                            grid[x + 2, y - 2] == Grid.EMPTY &&
                            grid[x + 2, y + 2] == Grid.EMPTY &&

                            grid[x + 3, y] == Grid.EMPTY &&
                            grid[x + 3, y - 1] == Grid.EMPTY &&
                            grid[x + 3, y + 1] == Grid.EMPTY &&
                            grid[x + 3, y - 2] == Grid.EMPTY &&
                            grid[x + 3, y + 2] == Grid.EMPTY
                            )
                        {
                            grid[x, y] = Grid.PASSMAN;
                            grid[x, y - 1] = Grid.PASSMAN;
                            grid[x, y - 2] = Grid.PASSMAN;
                            grid[x, y + 1] = Grid.PASSMAN;
                            grid[x, y + 2] = Grid.PASSMAN;

                            grid[x - 1, y] = Grid.PASSMAN;
                            grid[x - 1, y - 1] = Grid.PASSMAN;
                            grid[x - 1, y - 2] = Grid.PASSMAN;
                            grid[x - 1, y + 1] = Grid.PASSMAN;
                            grid[x - 1, y + 2] = Grid.PASSMAN;

                            grid[x - 2, y] = Grid.PASSMAN;
                            grid[x - 2, y - 1] = Grid.PASSMAN;
                            grid[x - 2, y - 2] = Grid.PASSMAN;
                            grid[x - 2, y + 1] = Grid.PASSMAN;
                            grid[x - 2, y + 2] = Grid.PASSMAN;

                            grid[x - 3, y] = Grid.PASSMAN;
                            grid[x - 3, y - 1] = Grid.PASSMAN;
                            grid[x - 3, y - 2] = Grid.PASSMAN;
                            grid[x - 3, y + 1] = Grid.PASSMAN;
                            grid[x - 3, y + 2] = Grid.PASSMAN;

                            grid[x + 1, y] = Grid.PASSMAN;
                            grid[x + 1, y - 1] = Grid.PASSMAN;
                            grid[x + 1, y - 2] = Grid.PASSMAN;
                            grid[x + 1, y + 1] = Grid.PASSMAN;
                            grid[x + 1, y + 2] = Grid.PASSMAN;

                            grid[x + 2, y] = Grid.PASSMAN;
                            grid[x + 2, y - 1] = Grid.PASSMAN;
                            grid[x + 2, y - 2] = Grid.PASSMAN;
                            grid[x + 2, y + 1] = Grid.PASSMAN;
                            grid[x + 2, y + 2] = Grid.PASSMAN;

                            grid[x + 3, y] = Grid.PASSMAN;
                            grid[x + 3, y - 1] = Grid.PASSMAN;
                            grid[x + 3, y - 2] = Grid.PASSMAN;
                            grid[x + 3, y + 1] = Grid.PASSMAN;
                            grid[x + 3, y + 2] = Grid.PASSMAN;

                            Debug.Log("Spawn Point found");
                            Instantiate(PassManager, new Vector3Int(x + widthOffset, y + heightOffset, 0), Quaternion.identity, prent.transform);
                            brickCount += 25;

                            return;
                        }
                    }
                }
            }
        }
    }


    private bool SpawnSingleBrick(Vector3Int vector)
    {
        if (grid[vector.x, vector.y] != Grid.BRICK && grid[vector.x, vector.y] != Grid.PASSMAN && (vector.x - 1 >= 0 && vector.y >= 0) && (vector.x + 1 < mapWidth && vector.y < mapHeight))
        {
            if (vector.x - 2 >= 0) // if this grid reference is in-bounds...
            {
                if (grid[vector.x - 2, vector.y] != Grid.BRICK && grid[vector.x - 2, vector.y] != Grid.PASSMAN) // ... and it is not already labelled brick ...
                {
                    grid[vector.x - 2, vector.y] = Grid.BRICK; // ... label it a brick
                } 
                else // if the grid reference is already labelled brick... 
                {
                    return false; // ... don't place current brick; too close to another one
                }
            }

            grid[vector.x - 1, vector.y] = Grid.BRICK;
            grid[vector.x, vector.y] = Grid.BRICK;
            grid[vector.x + 1, vector.y] = Grid.BRICK;

            if (UnityEngine.Random.value < firewallSpawnChance)
            {
                Instantiate(Firewall, new Vector3Int(vector.x + widthOffset, vector.y + heightOffset, 0), Quaternion.identity, prent.transform);
            } else
            {
                Instantiate(Bricks[GenerateInteger(vector.x, vector.y)], new Vector3Int(vector.x + widthOffset, vector.y + heightOffset, 0), Quaternion.identity, prent.transform);
                spawnCount += 1;
            }
            
            brickCount += 3;
            return true;
        }
        return false;

    }


    private int GenerateInteger(int x, int y) {
        float pnoise = Mathf.PerlinNoise1D(x+y / smoothness);
        int value = Mathf.RoundToInt((Bricks.Length - 1) * pnoise);
        if (pnoise < 0.1f) return 0;
        return value;
    }

    private void ChanceToRemove()
    {
        int updateCount = Walkers.Count;
        for (int i = 0; i < updateCount; i++)
        {
            if (UnityEngine.Random.value < Walkers[i].chanceToChange && Walkers.Count > 1)
            {
                Walkers.RemoveAt(i);
                break;
            }
        }
    }

    private void ChanceToRedirect()
    {
        for (int i = 0; i < Walkers.Count; i++)
        {
            if (UnityEngine.Random.value < Walkers[i].chanceToChange)
            {
                WalkerObject walker = Walkers[i];
                walker.direction = GetDirection();
                Walkers[i] = walker;
            }
        }
    }

    private void ChanceToCreate()
    {
        int updatedCount = Walkers.Count;
        for (int i = 0; i < updatedCount; i++)
        {
            if (UnityEngine.Random.value < Walkers[i].chanceToChange && Walkers.Count < maxWalkers)
            {
                Vector2 newDirection = GetDirection();
                Vector2 newPosition = Walkers[i].position;

                WalkerObject newWalker = new WalkerObject(newPosition, newDirection, 0.5f);
                Walkers.Add(newWalker);
            }
        }
    }

    private void UpdatePosition()
    {
        for (int i = 0; i < Walkers.Count; i++)
        {
            WalkerObject walker = Walkers[i];
            walker.position += walker.direction;
            walker.position.x = Mathf.Clamp(walker.position.x, 1, grid.GetLength(0) - 2);
            walker.position.y = Mathf.Clamp(walker.position.y, 1, grid.GetLength(1) - 2);
            Walkers[i] = walker;
        }
    }

    private Vector2 GetDirection()
    {
        int direction = Mathf.FloorToInt(UnityEngine.Random.value * 3.99f);

        switch (direction)
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
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class Grid 
{
    private int width;
    private int height;
    private float cellSize;
    private int[,] gridArray;

    public Grid(int width, int height, float cellSize)
    {
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;

        gridArray = new int[width, height];

        for(int x = 0; x < gridArray.GetLength(0); x++)
        {
            for(int y = 0; y < gridArray.GetLength(1); y++)
            {
                gridArray[x, y] = 0;
            }
        }
    }

    public Vector3 returnFreePosition()
    {
        for (int x = 0; x < gridArray.GetLength(0); x++)
        {
            for (int y = 0; y < gridArray.GetLength(1); y++)
            {
             
                if (gridArray[x, y] == 0)
                {
                    gridArray[x, y] = 1;
                    return GetWorldPosition(x, y);
                }
            }
        }
        return new Vector3(0,0);
    }

    public Vector3 getPosition(int id)
    {
        int x = id / 2;
        int y = id % 2;
        return GetWorldPosition(x, y);
    }

    private Vector3 GetWorldPosition(int x, int y)
    {
        Vector3 vector =  new Vector3(x, y);
        //vector = Quaternion.Euler(0, 0, 29) * vector;
        vector = vector * cellSize;
        return vector;
    }
  
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSystem : MonoBehaviour
{
    // all the tile gameObjects
    public GameObject[] tiles;

    //no. of rows and columns
    public int rows;
    public int columns;

    public int[] rowends;
    public int[] rowStarts;

    void Start()
    {
        rowStarts = new int[rows];
        rowends = new int[rows];
        //checks if the rows and columns are entered correctly
        if (rows * columns != tiles.Length)
        {
            Debug.Log("bruh");
        }

        rowends[0] = columns - 1;
        for (int i = 1; i < rows; i++)
        {
            rowends[i] = rowends[i - 1] + columns;
        }

        rowStarts[0] = 0;
        for (int i = 1; i < rows; i++)
        {
            rowStarts[i] = rowStarts[i - 1] + columns;
        }
    }
}

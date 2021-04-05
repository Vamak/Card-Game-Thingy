using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //takes the GridSystem script from the tile parent
    public GridSystem grid;

    //the current tile our player is standing in
    public int currentTile = 0;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if(!(currentTile >= grid.rowStarts[grid.rows - 1]))
            {
                currentTile += grid.columns;
            }
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if(!(currentTile <= grid.rowends[0]))
            {
                currentTile -= grid.columns;
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if(!(currentTile % grid.columns == 0))
            {
                currentTile--;
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (!((currentTile + 1) % grid.columns == 0))
            {
                currentTile++;
            }
        }
    }

    void LateUpdate()
    {
        if(currentTile < 0)
        {
            currentTile = 0;
        }
       if (currentTile + 1 > grid.tiles.Length)
        {
            currentTile = grid.tiles.Length - 1;
        }

        if (currentTile <= (grid.rows * grid.columns) - 1 && currentTile >= 0)
        {
            transform.position = grid.tiles[currentTile].transform.position;
        }
    }
}

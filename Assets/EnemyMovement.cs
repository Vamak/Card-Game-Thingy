using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float minWaitTime;
    public float maxWaitTime;
    float waitTime;

    public GridSystem grid;
    public int currentTile;

    bool canMove = true;

    public float minAttackWaitTime;
    public float maxAttackWaitTime;
    float attackWaitTime;

    public GameObject bullet;

    private void Update()
    {
        if (attackWaitTime <= 0)
        {
            bullet.GetComponent<bullet>().MoveX = -1;
            bullet.GetComponent<bullet>().shooter = gameObject;
            bullet.GetComponent<bullet>().damageMulti = Random.Range(1f, 2f);
            bullet.GetComponent<bullet>().enemyName = "Player";
            Instantiate(bullet, transform.position, bullet.transform.rotation);
            attackWaitTime = Random.Range(minAttackWaitTime, maxAttackWaitTime);
        }
        else attackWaitTime -= Time.deltaTime;

        if(waitTime <= 0 && canMove)
        {
            int moveNo = Random.Range(0, 4);
            //0 = up
            //1 = down
            //2 = right
            //3 = left

            Debug.Log(moveNo);

            if (moveNo == 0)
            {
                if (!((currentTile - grid.rows + 1) < 0))
                {
                    currentTile -= grid.columns;
                }
            }
            if(moveNo == 1)
            {
                if (!((currentTile + grid.rows) > grid.rows * grid.columns))
                {
                    currentTile += grid.columns;
                }
            }
            if(moveNo == 2)
            {
                if (!((currentTile + 1) % grid.columns == 0))
                {
                    currentTile++;
                }
            }
            if(moveNo == 3)
            {
                if (!(currentTile % grid.columns == 0))
                {
                    currentTile--;
                }
            }

            waitTime = Random.Range(maxWaitTime,minWaitTime);
        }
        else
        {
            waitTime -= Time.deltaTime;
        }
    }


    void LateUpdate()
    {
        if (currentTile < 0)
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

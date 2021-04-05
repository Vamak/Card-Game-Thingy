using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject bullet;
    public Transform shootPoint;

    public float maxWaitTime;
    float waitTime;

    public float maxChargeTime;
    float chargeTime;

    // Update is called once per frame
    void Update()
    {
        if(waitTime > 0)
        {
            waitTime -= Time.deltaTime;
        }

        if (Input.GetKeyUp(KeyCode.Z) && waitTime <= 0)
        {
            bullet.GetComponent<bullet>().MoveX = 1;
            bullet.GetComponent<bullet>().damageMulti = chargeTime;
            bullet.GetComponent<bullet>().enemyName = "Enemy";
            bullet.GetComponent<bullet>().shooter = gameObject;
            Instantiate(bullet, shootPoint.position, transform.rotation);
            chargeTime = 0;
            waitTime = maxWaitTime;
        }
        if(Input.GetKey(KeyCode.Z) && waitTime <= 0 && chargeTime <= maxChargeTime)
        {
            chargeTime += Time.deltaTime;
        }
    }
}

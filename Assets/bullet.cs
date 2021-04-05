using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float damageMulti;
    Rigidbody2D rb;
    public int speed;
    public float damage;
    public string enemyName;
    public GameObject shooter;
    public int MoveX;

    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = transform.localScale * damageMulti * 3;
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.right * speed * MoveX;
        damage *= damageMulti;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == enemyName)
        {
            other.GetComponent<Health>().TakeDamage(damage);
        }
        if (!(other.tag == shooter.tag))
        {
            Destroy(gameObject);
        }
    }
}

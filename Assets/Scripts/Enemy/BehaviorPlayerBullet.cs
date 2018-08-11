using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviorPlayerBullet : MonoBehaviour {

    public Collider2D enemyBullet;
    public Collider2D playerBullet;

    void destroyBullet()
    {
        Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Wall" || collision.gameObject.tag == "EnemyBullet")
        {
            destroyBullet();
        }
    }
}

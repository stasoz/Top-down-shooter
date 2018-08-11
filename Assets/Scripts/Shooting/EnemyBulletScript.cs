using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletScript : MonoBehaviour {

    public float speed;

    private Transform player;
    private Vector2 target;

	void Start () {
        installValues();
	}
	void Update () {
        directionOfBullet();
	}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Wall" || collision.gameObject.tag == "PlayerBullet")
        {
            destroyBullet();
        }
    }
    void destroyBullet()
    {
        Destroy(gameObject);
    }
    public void installValues()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector2(player.position.x, player.position.y);
    }
    public void directionOfBullet()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        if (transform.position.x == target.x && transform.position.y == target.y)
        {
            destroyBullet();
        }
    }
}

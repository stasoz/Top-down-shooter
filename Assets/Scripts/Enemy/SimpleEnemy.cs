using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemy : AbstractEnemy {

    public float speed;
    public float stoppingDistance;
    public float retreatDistance;

    private Transform player;

    protected float timeBetweenShots;
    [SerializeField]
    protected float startTimeBetweenShots;

    public GameObject projectTile;
    private float health = 20;
	void Start ()
    {
        installValues();
	}
	void Update ()
    {
        moveForPlayer();
        creatingBullets();
    }
    public override void installValues()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        timeBetweenShots = startTimeBetweenShots;
    }
    public override void moveForPlayer()
    {
            if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            }
            else if (Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > retreatDistance)
            {
                transform.position = this.transform.position;
            }
            else if (Vector2.Distance(transform.position, player.position) < retreatDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
            }
    }
    public override void creatingBullets()
    {
        if (timeBetweenShots <= 0)
        {
            Instantiate(projectTile, transform.position, Quaternion.identity);
            timeBetweenShots = startTimeBetweenShots;
        }
        else
        {
            timeBetweenShots -= Time.deltaTime;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PlayerBullet") takeDamageAndCheckOnDie();
    }
    void takeDamageAndCheckOnDie()
    {
        health -= 10;
        if (health <= 0) Destroy(this.gameObject);
    }
}

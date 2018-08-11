using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using System.Linq;
public class PlayerMove : MonoBehaviour {

    private Rigidbody2D rb;
    private float speed=3.0f;
    private GameObject[] enemies;

    public static bool isFire = false;

    public float health = 100;
    public float maxHealth = 100;

    void Start()
    {
        this.rb = GetComponent<Rigidbody2D>();  
    }
    void Update()
    {
        getEnemies();
        findEnemiesAndLookAtThem();
        checkOnTapFireButton();
    }
    void FixedUpdate()
    {
        movePlayerFunction();
    }
    void findEnemiesAndLookAtThem()
    {
        if (enemies != null)
        {
         var tempArrayOfEnemies = enemies.OrderBy(x => Vector3.Distance(rb.transform.position, x.transform.position));
         GameObject[] tempEnemies = tempArrayOfEnemies.ToArray();

         Vector3 diff = tempEnemies[0].transform.position - transform.position;
         diff.Normalize();
 
         float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
         transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
        }
    }
    void movePlayerFunction()
    {

        float h = CrossPlatformInputManager.GetAxis("Horizontal");
        float v = CrossPlatformInputManager.GetAxis("Vertical");

        Vector2 direction = new Vector2(h, v) * speed;
        rb.velocity = direction;
    }
    void getEnemies()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
    }
    void checkOnTapFireButton()
    {
        if(CrossPlatformInputManager.GetButtonDown("Fire"))
        {
            isFire = true;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "EnemyBullet")
        {
            takeDamageAndCheckOnDie();
        }
    }
    void takeDamageAndCheckOnDie()
    {
        HealthBar.health -= 10;
        if (HealthBar.health <= 0) Destroy(this.gameObject);
    }
}

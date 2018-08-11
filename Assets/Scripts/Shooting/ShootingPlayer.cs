using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class ShootingPlayer : MonoBehaviour {

    public Transform bullet;
    public int speedOfBullet = 2;
    private float nextShooting=0;
    public float intervalBetweenShooting=2;
    private float currentTime = 0;

	void Update ()
    {
        shooting();
	}
    void shooting()
    {
        currentTime += Time.deltaTime;
        if (PlayerMove.isFire && currentTime>intervalBetweenShooting)
        {
            currentTime = 0;
            Transform temp = (Transform)Instantiate(bullet, transform.position, transform.rotation);
            temp.GetComponent<Rigidbody2D>().AddForce(transform.up * speedOfBullet);
            nextShooting = Time.time + intervalBetweenShooting;
            PlayerMove.isFire = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolEnemy : MonoBehaviour {

    public float rotationSpeed;
    public float distance;

    public LineRenderer lineOfSight;

    private void Start()
    {
        Physics2D.queriesStartInColliders = false;
    }
    private void Update()
    {
        rotation();
        rayCastFunction();
    }
    void rotation()
    {
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }
    void rayCastFunction()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.right, distance);
        if (hitInfo.collider != null)
        {
            Debug.DrawLine(transform.position, hitInfo.point, Color.red);
            lineOfSight.SetPosition(1,hitInfo.point);
            if(hitInfo.collider.CompareTag("Player"))
            {
                Destroy(hitInfo.collider.gameObject);
            }
        }
        else {
            lineOfSight.SetPosition(1, transform.position + transform.right * distance);
            Debug.DrawLine(transform.position, transform.position + transform.right * distance, Color.green);
        }
    }
    void line()
    {
        lineOfSight.SetPosition(0, transform.position);
    }
}

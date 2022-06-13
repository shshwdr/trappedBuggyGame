using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : MonoBehaviour
{
    public float shootTime = 1f;
    float shootTimer = 0f;
    public GameObject bullet;
    public Vector3 dir = new Vector3(0, 1, 0);
    bool isEnabled = true;

    public void disableFunction()
    {
        isEnabled = false;
    }
    public void enableFunction()
    {
        isEnabled = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isEnabled)
        {
            shootTimer += Time.deltaTime;
            if (shootTimer >= shootTime)
            {
                shootTimer -= shootTime;
                shoot();
            }
        }
    }

    void shoot()
    {
        var go = Instantiate<GameObject>(bullet, transform.position, Quaternion.identity);
        go.GetComponent<Bullet>().init(transform.up);
    }
}

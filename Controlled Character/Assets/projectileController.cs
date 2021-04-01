using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileController : MonoBehaviour
{
    public Camera cam;
    public Transform LHFirePoint, RHFirePoint;
    public GameObject projectile;
    public float projectileSpeed = 30f;
    private Vector3 destination;
    private bool lefthand;
    private float timeToFire;
    public float fireRate = 4;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //fires projectiles
        if (Input.GetButton ("Fire1") && Time.time >= timeToFire)
        {
            timeToFire = Time.time + 1 / fireRate;
            ShootProjectile();
        }
    }
    void ShootProjectile()
    {
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            destination = hit.point;
        }
        else
        {
            destination = ray.GetPoint(1000);
        }
        if (lefthand)
        {
            lefthand = false;
            InstantiateProjectile(LHFirePoint);
        }
        else
        {
            lefthand = true;
            InstantiateProjectile(RHFirePoint);
        }

    }

    void InstantiateProjectile(Transform firePoint)
    {
        var projectileObj = Instantiate(projectile, firePoint.position, Quaternion.identity) as GameObject;
        projectileObj.GetComponent<Rigidbody>().velocity = (destination - firePoint.position).normalized * projectileSpeed;
    }
}


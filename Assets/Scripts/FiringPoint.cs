using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public class FiringPoint : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float projectileSpeed = 1000f;

    [Header("Rayast Projectile")]
    public GameObject laserHitSparks;
    public LineRenderer laser;

    
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            FireProjectile();
        }

        if(Input.GetButtonDown("Fire2"))
            FireRaycast();
    }

    private void FireProjectile()
    {
        //create a refrence to hold our instantiated object
        GameObject projectileInstance;
        //Instatiate our projectile prefab
        projectileInstance = Instantiate(projectilePrefab, transform.position, transform.rotation);
        //get rigid body of our projectile and add force
        projectileInstance.GetComponent<Rigidbody>().AddForce(transform.forward * projectileSpeed);

        

    }
    private void FireRaycast()
    {
        //create Ray
        Ray ray = new Ray(transform.position, transform.forward);
        Debug.DrawRay(transform.position, transform.forward, Color.green);
        //Create refrence to hold info on what we hit
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            //Debug.Log("Hit" + hit.collider.name + "at point" + hit.point + "which was" + hit.distance + "units away");

            laser.SetPosition(0, transform.position);
            laser.SetPosition(1, hit.point);
            StopAllCoroutines();
            StartCoroutine(ShowLaser());

            GameObject laserParticleInstance = Instantiate(laserHitSparks, hit.point, hit.transform.rotation);
            Destroy(laserParticleInstance, 1 );

            if (hit.collider.CompareTag("Enemy"))
                Destroy(hit.collider.gameObject);
        }
    }

    IEnumerator ShowLaser()
    {
        laser.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        laser.gameObject.SetActive(false);
    }

}

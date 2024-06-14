using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject hitParticles;
    public float lifeTime = 3f;

    void Start()
    {
        Invoke("DestroyProjectile", lifeTime);
    }

    public void DestroyProjectile()
    {
        GameObject hitParticlesInstance = Instantiate(hitParticles, transform.position, transform.rotation);

        Destroy(hitParticlesInstance, 2);  

        Destroy(this.gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {

        //print(collision.gameObject.name);
        if(collision.collider.CompareTag("Enemy"))
        {
            //change color when hit
            collision.gameObject.GetComponentInChildren<Renderer>().material.color = Color.red;
            //destroy after 1 sec
            Destroy(collision.gameObject, 1);

        }
        DestroyProjectile();

    }

}


using UnityEngine;

public class Bullet : MonoBehaviour
{ 
    
   public float damage = 50f;

    
    public float speed = 70.0f;
    public float explosionRadius = 0f;

    
    public GameObject impactEffect;
    private Transform _target;

public void Seek (Transform target)
    {
        this._target = target;   
    }


   
    // Update is called once per frame
    void Update()
    {
        if (_target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = _target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }

    void HitTarget ()
    {
       GameObject effectIns = Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy (effectIns, 2f);
       if (explosionRadius > 0f)
        {
            Explode();
        } else
        {
            Damage(_target);
        }
        Destroy(gameObject);
    }
  void Explode ()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider collider in colliders)
        {
            if (collider.tag == "Enemy")
            {
                Damage(collider.transform);
            }
        }
        
    }
   
   void Damage (Transform enemy)
    {
        Enemy e = enemy.GetComponent<Enemy>();
        if (e != null)
        {
            e.TakeDamage(damage);
            
        }
        
        e.TakeDamage(damage);
       
    }
    
}

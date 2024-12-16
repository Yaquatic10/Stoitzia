using System.Collections;
using UnityEngine;

public class TurretLifetimeManager : MonoBehaviour
{
    public float lifetime = 30f; 

    private Node _node;

    void Start()
    {
        
        _node = GetComponentInParent<Node>();

       
        StartCoroutine(DestroyAfterLifetime());
    }

    private IEnumerator DestroyAfterLifetime()
    {
        
        yield return new WaitForSeconds(lifetime);

        
        Destroy(gameObject);

        
        if (_node != null)
        {
            _node.ClearTurret();
        }
    }
}

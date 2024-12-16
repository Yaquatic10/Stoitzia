using System.Collections;
using UnityEngine;

public class TurretLifetimeManager : MonoBehaviour
{
    public float lifetime = 30f; // Tiempo de vida de la torreta en segundos

    private Node _node;

    void Start()
    {
        // Obt�n el componente Node asociado a la torreta
        _node = GetComponentInParent<Node>();

        // Inicia la corutina para destruir la torreta despu�s de su tiempo de vida
        StartCoroutine(DestroyAfterLifetime());
    }

    private IEnumerator DestroyAfterLifetime()
    {
        // Espera el tiempo de vida especificado
        yield return new WaitForSeconds(lifetime);

        // Destruye la torreta
        Destroy(gameObject);

        // Libera el nodo para que se pueda construir una nueva torreta
        if (_node != null)
        {
            _node.ClearTurret();
        }
    }
}

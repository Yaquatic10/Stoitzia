using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Vector3 positionOffset;
    private GameObject _turret;
    private Renderer _rend;
    private Color _startColor;

    void Start()
    {
        _rend = GetComponent<Renderer>();
        _startColor = _rend.material.color;
    }

    void OnMouseDown()
    {
        if (_turret != null)
        {
            Debug.Log("No se puede construir aquí.");
            return;
        }

        // Verificar si el jugador tiene suficiente currency
        CurrencyManager currencyManager = CurrencyManager.instance;  // Asegúrate de que CurrencyManager sea un Singleton o ajusta la forma de acceder a él
        if (currencyManager == null)
        {
            Debug.LogError("CurrencyManager no encontrado.");
            return;
        }

        if (!currencyManager.CanBuildTurret())
        {
            Debug.Log("No hay suficiente currency para construir la torreta.");
            return;
        }

        GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
        _turret = Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);
        currencyManager.BuildTurret();  // Deduct currency after building
    }
    public void ClearTurret()
    {
        _turret = null;
    }
    void OnMouseEnter()
    {
        _rend.material.color = hoverColor;
    }

    void OnMouseExit()
    {
        _rend.material.color = _startColor;
    }
}

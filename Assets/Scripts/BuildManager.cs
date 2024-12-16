using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

   void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Mas de un build manager");
            return;
        }
        instance = this;
    }

    public GameObject standardTurretPrefab;
    void Start ()

    {
        _turretToBuild = standardTurretPrefab;
    }    

    private GameObject _turretToBuild;
    public GameObject GetTurretToBuild()

    { return _turretToBuild; }
       
  
}

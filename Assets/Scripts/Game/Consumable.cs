using System;
using System.Collections.Generic;
using UnityEngine;

//Script on Consummable Box that Instantiate 
public class Consumable : MonoBehaviour {

    private UnityEngine.Object _consumablePrefab;

    public void Start()
    {
        _consumablePrefab = Resources.Load(String.Format("/Prefabs/Consumables/%s", this.gameObject.name));
    }

    public void SetPrefab(UnityEngine.Object prefab)
    {
        _consumablePrefab = prefab;
    }

    public UnityEngine.Object GetPrefab()
    {
        return Instantiate(_consumablePrefab, this.transform.position, this.transform.rotation);
    }
}
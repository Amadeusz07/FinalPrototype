using System;
using UnityEngine;

public class ResourcesWarehouse : Building
{
    PrefabsList PrefabList;

    void Start()
    {
        PrefabList = GameObject.Find("GameManager").GetComponent<PrefabsList>();
    }

    void Update()
    {
        if (PrefabList.ResourcesWarehouseObject.DajMi() <= 0)
            Die(this.gameObject);

        Debug.Log(PrefabList.ResourcesWarehouseObject.DajMi());
    }

    public void Farm()
    {
        //creates funds for buildings
    }
}


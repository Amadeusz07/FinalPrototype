using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoutHouse : Building
{
    PrefabsList PrefabList;

    void Start()
    {
        PrefabList = GameObject.Find("GameManager").GetComponent<PrefabsList>();
    }

    void Update()
    {
        if (PrefabList.ScoutHouseObject.DajMi() <= 0)
            Die(this.gameObject);

        Debug.Log(PrefabList.ScoutHouseObject.DajMi());
    }

    public void Attack()
    {
        //range, damage, target animation
    }
}

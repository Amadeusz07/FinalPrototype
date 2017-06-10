using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CentreOfDefense : Building
{
    [SerializeField]
    private List<GameObject> UnitsToRecruit;

    PrefabsList PrefabList;
    private float Timer;

    void Start()
    {
        PrefabList = GameObject.Find("GameManager").GetComponent<PrefabsList>();
        UnitsToRecruit.Add(PrefabList.Unit[1]);
    }

    void Update()
    {
        Timer += Time.deltaTime;

        if (PrefabList.CentreOfDefenseObject.DajMi() <= 0)
            Die(this.gameObject);

        if (Timer >= PrefabList.MarskmanObject.TimeToRecruit)
        {
            CreateUnit(UnitsToRecruit);
            Timer = 0;
        }

        Debug.Log(PrefabList.CentreOfDefenseObject.DajMi());

    }

}

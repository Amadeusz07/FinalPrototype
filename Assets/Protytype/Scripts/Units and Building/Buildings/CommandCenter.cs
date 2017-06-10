using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandCenter : Building
{
    [SerializeField]
    private List<GameObject> UnitsToRecruit;

    PrefabsList PrefabList;
    private float Timer;

    void Start()
    {
        PrefabList = GameObject.Find("GameManager").GetComponent<PrefabsList>();
        UnitsToRecruit.Add(PrefabList.Unit[0]);
    }

    void Update()
    {
        Timer += Time.deltaTime;

        if (PrefabList.CommandCenterObject.DajMi() <= 0)
            Die(this.gameObject);

        if (Timer >= PrefabList.FighterObject.TimeToRecruit)
        {
            CreateUnit(UnitsToRecruit);
            Timer = 0;
        }

        Debug.Log(PrefabList.CommandCenterObject.DajMi());

    }

    public void Attack()
    {
        //range, damage, target animation
    }
}

using System;
using System.Collections.Generic;
using UnityEngine;

public class PrefabsList : MonoBehaviour
{
    [SerializeField]
    public List<GameObject> Unit;

    [SerializeField]
    public List<GameObject> Building;

    //shotcuts
    public Unit FighterObject;
    public Unit MarskmanObject;
    public Building CommandCenterObject;
    public Building CentreOfDefenseObject;
    public Building ScoutHouseObject;
    public Building ResourcesWarehouseObject;
        
    void Start()
    {
        Unit[0].GetComponent<Unit>().SetUnit("Fighter", 50, 1f);
        Unit[1].GetComponent<Unit>().SetUnit("Marksman", 50, 6f);

        Building[0].GetComponent<Building>().SetBuilding("Command Center", 100);
        Building[1].GetComponent<Building>().SetBuilding("Centre Of Defense", 80);
        Building[2].GetComponent<Building>().SetBuilding("Scout House", 60);
        Building[3].GetComponent<Building>().SetBuilding("Resources Warehouse", 20);


        FighterObject = Unit[0].GetComponent<Unit>();
        MarskmanObject = Unit[1].GetComponent<Unit>();

        CommandCenterObject = Building[0].GetComponent<Building>();
        CentreOfDefenseObject = Building[1].GetComponent<Building>();
        ScoutHouseObject = Building[2].GetComponent<Building>();
        ResourcesWarehouseObject = Building[3].GetComponent<Building>();

    }
}

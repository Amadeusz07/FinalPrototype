using System.Collections.Generic;
using UnityEngine;

abstract public class PlayerEntities : MonoBehaviour
{
    //abstract functions for every entity
    //nothing for now
    
    //functions that every entity has the same
    protected void Die(GameObject entity)
    {
        //play animation and destroy the object
        Destroy(entity);
    }
}

abstract public class Unit : PlayerEntities
{
    protected string Name { get; set; }
    protected int HitPoints { get; set; }
    public float TimeToRecruit { get; set; }

    public void SetUnit(string name, int hitPoints, float timeToRecruit)
    {
        Name = name;
        HitPoints = hitPoints;
        TimeToRecruit = timeToRecruit;
    }

    public object ReturnValue(object parameter)
    {
        if (parameter is int)
            return HitPoints;

        else if (parameter is float)
            return TimeToRecruit;

        else
            return null;
    }

    public void Move()
    {
        //go through the waypoints in selected lane in building, it would be break on attack
    }
}

abstract public class Building : PlayerEntities
{
    protected string Name { get; set; }
    protected int HitPoints { get; set; }
    private GameObject NewUnit;

    public void SetBuilding(string name, int hitPoints) //pseudo-constructor
    {
        Name = name;
        HitPoints = hitPoints;
    }

    public float DajMi()
    {
        return HitPoints;
    }

    public void Build(GameObject prefab)
    {
        //starts constructions of building (animation), after required time it become working building
        //Debug.Log("Start building: " + prefab.name);
    }

    public void CreateUnit(List<GameObject> unitsToRecruit)
    {

        NewUnit = Instantiate(unitsToRecruit[0], new Vector3(5, 5, 5), Quaternion.identity);



        //Debug.Log(unitsToRecruit[0].GetComponent<Building>().DajMi());


        //if (Input.GetKeyDown("p"))
        //{
        //    NewUnit = Instantiate(unitsToRecruit[0], new Vector3(5, 5, 5), Quaternion.identity);
        //    NewUnit.name = 
        //    Debug.Log(NewUnit.GetComponent<Unit>().DajMi());
        //}
    }
}

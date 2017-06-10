using System;
using System.Collections.Generic;
using UnityEngine;

public class BuildingController : MonoBehaviour
{
    private GameObject newObject;
    private PrefabsList PrefabList;
    private bool ConstructionMode;
    private MouseController Mouse;

    void Start()
    {
        PrefabList = this.gameObject.GetComponent<PrefabsList>();
        ConstructionMode = false;
        Mouse = this.gameObject.GetComponent<MouseController>();
    }

    void Update()
    {
        UpdateConstructionMode();
        if (ConstructionMode)
        {
            if (newObject == null)
            {
                switch (Input.inputString)
                {
                    case "c":
                        newObject = Instantiate(PrefabList.Building[0], transform.position, Quaternion.identity);
                        newObject.name = "CommandCenter";
                        break;
                    case "d":
                        newObject = Instantiate(PrefabList.Building[1], transform.position, Quaternion.identity);
                        newObject.name = "CentreOfDefense";
                        break;
                    case "s":
                        newObject = Instantiate(PrefabList.Building[2], transform.position, Quaternion.identity);
                        newObject.name = "ScoutHouse";
                        break;
                    case "r":
                        newObject = Instantiate(PrefabList.Building[3], transform.position, Quaternion.identity);
                        newObject.name = "ResourcesWarehouse";
                        break;
                }
            }
            else if (newObject != null)
            {
                newObject.transform.position = Mouse.CurrentMousePosition;
                if (Input.GetMouseButtonDown(0))
                {
                    newObject.GetComponent<Collider>().enabled = true; //for raycast
                    newObject.GetComponent<Building>().Build(newObject);
                    SetConstructionMode(false);
                }
            }             
        }         
    }

    private void UpdateConstructionMode()
    {
        if (Input.GetKeyDown("b") && !ConstructionMode)
            SetConstructionMode(true);
        if (Input.GetKeyDown(KeyCode.Escape) && ConstructionMode)
            SetConstructionMode(false);  
    }

    #region helpers
    private void SetConstructionMode(bool goOn)
    {
        if (goOn)
        {
            ConstructionMode = true;
            //Debug.Log("Construction Mode is on");
        }
        else
        {
            if (newObject != null)
            {
                if (Input.GetKeyDown(KeyCode.Escape))
                    Destroy(newObject); //remove from scene if escape was clicked while placing  
                newObject = null; // clear memory
            }
            ConstructionMode = false;
            //Debug.Log("Construction Mode is off");
        }
    }


    #endregion


}


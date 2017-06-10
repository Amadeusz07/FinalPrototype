using UnityEngine;

public class MouseController : MonoBehaviour
{
    private RaycastHit Hit;
    private Camera PlayerCamera;
    public Vector3 CurrentMousePosition; //public to building, because we need mouse position per frame

    void Start()
    {
        PlayerCamera = Camera.main;
    }

    void Update()
    {
        Ray ray = PlayerCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out Hit, Mathf.Infinity))
        {
            CurrentMousePosition = Hit.point;
            if (Input.GetMouseButtonDown(0)) ;
                //Debug.Log(Hit.collider.name)
        }//end of raycast
    }

    #region helpers
    //DON'T DELETE
    //public bool playerClickedLeftMouse(Vector3 hitPoint)
    //{
    //    float clickZone = 1.3f;

    //    if (
    //        (mouseDownPoint.x < hitPoint.x + clickZone && mouseDownPoint.x > hitPoint.x - clickZone) &&
    //        (mouseDownPoint.y < hitPoint.y + clickZone && mouseDownPoint.y > hitPoint.y - clickZone) &&
    //        (mouseDownPoint.z < hitPoint.z + clickZone && mouseDownPoint.z > hitPoint.z - clickZone)
    //    )
    //        return true;
    //    else return false;

    //}

    #endregion
}

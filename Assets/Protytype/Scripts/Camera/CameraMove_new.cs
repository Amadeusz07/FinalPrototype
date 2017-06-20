using UnityEngine;
using System.Collections;

public class CameraMove_new : MonoBehaviour
{

    public GameObject Main_Camera; //You just connect this to the main camera
    public struct BoxLimit
    {
        public float LeftLimit;
        public float RightLimit;
        public float TopLimit;
        public float BottomLimit;
    }

    public static BoxLimit cameraLimits = new BoxLimit();
    public static BoxLimit mouseScrollLimits = new BoxLimit();
    public static CameraMove_new Instance;
    private Transform camera_Transform;

    public float cameraMoveSpeed = 50f; //Sensitivity
    private static float mouseBoundary = 10f; //How close mouse must be to the screen borders to start moving the camera
    private float cameraDistance = 35f;//How high camera will be over the colliders

    private float mouseX;//rotation variable

    void Awake()
    {
        Instance = this; //I don't know why this is here
    }

    void Start()
    {
        cameraLimits.LeftLimit = 100f; //Boundaries
        cameraLimits.RightLimit = 470f;
        cameraLimits.TopLimit = 420f;
        cameraLimits.BottomLimit = 40f;

        mouseScrollLimits.LeftLimit = mouseBoundary;
        mouseScrollLimits.RightLimit = mouseBoundary;
        mouseScrollLimits.TopLimit = mouseBoundary;
        mouseScrollLimits.BottomLimit = mouseBoundary;

        camera_Transform = transform;
    }

    void LateUpdate()
    {
        HandleMouseRotation();
        CameraAntiCrashCourse();
        CameraLimitPosition();

        if (CheckIfUserCameraInput()) 
        {
            Vector3 cameraDesireMove = GetDesiredTranslation();
            transform.Translate(cameraDesireMove, Space.Self);
        }

        mouseX = Input.mousePosition.x;

    }

    //Camera will not touch the ground
    public void CameraAntiCrashCourse()
    {
        var curDistance = 0f;
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -transform.up, out hit, 100))
        {
            curDistance = Vector3.Distance(transform.position, hit.point);
        }

        if (curDistance != cameraDistance)
        {
            float difference = cameraDistance - curDistance;

            transform.position = Vector3.Lerp(transform.position, transform.position + new Vector3(0, difference, 0), Time.deltaTime);
        }
    }

    //Rotating the camera
    public void HandleMouseRotation()
    {
        var easeFactor = 10f;
        if (Input.GetMouseButton(2))
        {
            //Horizontal rotation
            if (Input.mousePosition.x != mouseX)
            {
                var cameraRotationY = (Input.mousePosition.x - mouseX) * easeFactor * Time.deltaTime;
                this.transform.Rotate(0, cameraRotationY, 0);
            }
        }
        else if (Input.GetKey(KeyCode.PageDown))
        {
            this.transform.Rotate(0, 10f * easeFactor * Time.deltaTime, 0);
        }
        else if (Input.GetKey(KeyCode.PageUp))
        {
            this.transform.Rotate(0, -10f * easeFactor * Time.deltaTime, 0);
        }
    }

    //Camera will not leave boundries
    private void CameraLimitPosition()
    {

        camera_Transform.position = new Vector3(Mathf.Clamp(camera_Transform.position.x, cameraLimits.LeftLimit, cameraLimits.RightLimit),
            camera_Transform.position.y,
            Mathf.Clamp(camera_Transform.position.z, cameraLimits.BottomLimit, cameraLimits.TopLimit));
    }

    public bool CheckIfUserCameraInput()
    {
        var keyboardMove = AreCameraKeyboardButtonsPressed();
        var mouseMove = IsMousePositionWithinBoundaries();
        return keyboardMove || mouseMove;

    }

    public Vector3 GetDesiredTranslation()
    {
        var moveSpeed = cameraMoveSpeed * Time.deltaTime;
        var desiredZ = 0f;
        var desiredX = 0f;
        Vector3 desiredMove;


        if (AreCameraKeyboardButtonsPressed())
        {
            if (Input.GetKey(KeyCode.UpArrow))
                desiredZ = moveSpeed;
            if (Input.GetKey(KeyCode.DownArrow))
                desiredZ = moveSpeed * -1;
            if (Input.GetKey(KeyCode.LeftArrow))
                desiredX = moveSpeed * -1;
            if (Input.GetKey(KeyCode.RightArrow))
                desiredX = moveSpeed;
        }
        else
        {
            if (Input.mousePosition.y > (Screen.height - mouseScrollLimits.TopLimit))
                desiredZ = moveSpeed;
            if (Input.mousePosition.y < mouseScrollLimits.BottomLimit)
                desiredZ = moveSpeed * -1;
            if (Input.mousePosition.x < mouseScrollLimits.LeftLimit)
                desiredX = moveSpeed * -1;
            if (Input.mousePosition.x > (Screen.width - mouseScrollLimits.RightLimit))
                desiredX = moveSpeed;
        }

        desiredMove = new Vector3(desiredX, 0, desiredZ);
    
        desiredMove = Quaternion.Euler(new Vector3(0f, transform.eulerAngles.y, 0f)) * desiredMove;
        desiredMove = camera_Transform.InverseTransformDirection(desiredMove);

        return desiredMove;

    }

    #region HelperFunctions

    public static bool AreCameraKeyboardButtonsPressed() //Controls
    {
        return (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.RightArrow));
    }

    public static bool IsMousePositionWithinBoundaries()
    {
        //How far beyond the screen mouse can go to move the camera (safety precautions)
        return (Input.mousePosition.x < mouseScrollLimits.LeftLimit && Input.mousePosition.x > -25) ||
            (Input.mousePosition.x > (Screen.width - mouseScrollLimits.RightLimit) && Input.mousePosition.x < (Screen.width + 25)) ||
            (Input.mousePosition.y < mouseScrollLimits.BottomLimit && Input.mousePosition.y > -25) ||
            (Input.mousePosition.y > (Screen.height - mouseScrollLimits.TopLimit) && Input.mousePosition.y < (Screen.height + 25));
    }
    #endregion
}

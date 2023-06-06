using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target; 
    public float sensitivity = 6f; 
    private float currentXAngle = 0f;
    private float currentYAngle = 0f;


    bool cursorlock;
    void Start()
    {
        currentXAngle = transform.eulerAngles.x;
        currentYAngle = transform.eulerAngles.y;
        cursorlock = false;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Vector2 screenCenter = new Vector2(Screen.width / 2f, Screen.height / 2f);
            Cursor.SetCursor(null, screenCenter, CursorMode.Auto);
            Cursor.lockState = CursorLockMode.Locked;
            cursorlock = true;
        }
        if (Input.GetMouseButtonDown(0))
        {
            Cursor.lockState = CursorLockMode.None;
            cursorlock = false;
        }
    }


    void LateUpdate()
    {
        if (cursorlock)
        {
            float mouseX = Input.GetAxis("Mouse X") * sensitivity * 100 * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * sensitivity * 100 * Time.deltaTime;
            currentXAngle -= mouseY;
            currentYAngle += mouseX;
            transform.rotation = Quaternion.Euler(currentXAngle, currentYAngle, 0f);
            transform.position = Vector3.zero;
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gwagicamera : MonoBehaviour
{
    public Transform target;  // 구체의 Transform 컴포넌트
    public float rotationSpeed = 10000f;
    public float verticalRotationLimit = 200f;  // 카메라의 수직 회전 제한 각도

    private float mouseX;
    private float mouseY;
    private float rotationX = 0f;

    private void Update()
    {
        // 마우스 입력 감지
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");

        // 수직 회전 각도 제한
        rotationX -= mouseY * rotationSpeed * Time.deltaTime;
        rotationX = Mathf.Clamp(rotationX, -verticalRotationLimit, verticalRotationLimit);
    }

    private void LateUpdate()
    {
        // 카메라 시야 방향 조정
        Quaternion targetRotation = Quaternion.Euler(rotationX, target.eulerAngles.y + mouseX, 0f);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}

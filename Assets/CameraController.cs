using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target; // ī�޶� ���� ��� ĳ������ Transform
    public float sensitivity = 6f; // ���콺 ����
    public float maxYAngle = 40; // ī�޶��� �ִ� �󰢵�
    public float minYAngle = 0f; // ī�޶��� �ִ� �ϰ���
    public float far = 3;
    private float currentXAngle = 0f;
    private float currentYAngle = 0f;

    void Start()
    {
        // �ʱ�ȭ
        currentXAngle = transform.eulerAngles.x;
        currentYAngle = transform.eulerAngles.y;
        Vector2 screenCenter = new Vector2(Screen.width / 2f, Screen.height / 2f);
        Cursor.SetCursor(null, screenCenter, CursorMode.Auto);
        Cursor.lockState = CursorLockMode.Locked;
    }

    void LateUpdate()
    {
        // ���콺 �Է¿� ���� ���� ��ȭ ���
        float mouseX = Input.GetAxis("Mouse X") * sensitivity *100 * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity*100 * Time.deltaTime;
        currentXAngle -= mouseY;
        currentYAngle += mouseX;

        // ���� ���� ����
        currentXAngle = Mathf.Clamp(currentXAngle, minYAngle, maxYAngle);

        // ī�޶� ȸ��
        transform.rotation = Quaternion.Euler(currentXAngle, currentYAngle, 0f);

        // ī�޶� ��ġ ����
        transform.position = target.position - transform.forward * far;
    }
}
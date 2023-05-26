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
    public Vector3 fixedPosition= new Vector3(1f,1f,1f);
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
        Cursor.visible = true; // 커서를 보이게 설정
        Cursor.lockState = CursorLockMode.None; // 커서를 화면 중앙에 고정하지 않음
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

        transform.position = fixedPosition ;
    }
}
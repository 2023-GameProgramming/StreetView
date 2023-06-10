using UnityEngine;
using UnityEngine.UI;

public class ObjectClickHandler : MonoBehaviour
{
    public Canvas canvas; // 닫을 캔버스
    public Canvas canvas2; 
    public Button closeButton; // 닫을 버튼

    void Start()
    {
        // 초기에는 캔버스를 숨김
        canvas.gameObject.SetActive(false);

        // 버튼에 클릭 이벤트 핸들러 추가
        closeButton.onClick.AddListener(CloseCanvas);
    }

    void Update()
    {
        // 마우스 왼쪽 버튼 클릭 감지
        if (Input.GetMouseButtonDown(0))
        {
            // 클릭한 오브젝트 가져오기
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                // 클릭한 오브젝트가 해당 스크립트를 가진 오브젝트인지 확인
                if (hit.collider.gameObject == gameObject)
                {
                    // 캔버스의 가시성 상태를 변경하여 표시 또는 숨김
                    canvas.gameObject.SetActive(!canvas.gameObject.activeSelf);
                }
            }
        }
    }

    void CloseCanvas()
    {
        // 캔버스를 닫음
        canvas2.gameObject.SetActive(false);
    }
}

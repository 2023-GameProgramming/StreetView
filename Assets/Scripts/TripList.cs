using UnityEngine;
using UnityEngine.UI;

public class TripList : MonoBehaviour
{
    public GameObject photo; // 사진을 표시할 게임 오브젝트
    public Button closeButton; // 사진을 닫는 버튼

    // Start 함수에서 버튼의 클릭 이벤트 핸들러를 설정합니다.
    void Start()
    {
        photo.SetActive(false);
        
    }
    
    void Update(){
        closeButton.onClick.AddListener(OnCloseButtonClicked);
        if (Input.GetMouseButtonDown(0))
        {
            OnObjectClicked();
        }
    }

    // 클릭 이벤트를 처리하는 함수
    public void OnObjectClicked()
    {
        // 사진을 보여주는 동작을 여기에 작성합니다.
        photo.SetActive(true); // 사진을 활성화하여 보이게 합니다.
    }

    // 버튼 클릭 이벤트를 처리하는 함수
    public void OnCloseButtonClicked()
    {
        // 사진을 숨기는 동작을 여기에 작성합니다.
        photo.SetActive(false); // 사진을 비활성화하여 숨깁니다.
    }
}

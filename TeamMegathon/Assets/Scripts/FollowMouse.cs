using UnityEngine;

public class FollowMouse : MonoBehaviour //모노비헤이비어 선언
{
    public Camera cam;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // 이 내용은 새로운 클래스를 선언하여 구별함. 그래서 삭제
        //if (Input.GetMouseButtonDown(0)) // 마우스 왼쪽 버튼이 클릭되었을 때
        //{
            //spriteRenderer.sprite = clickedSprite; // 클릭된 스프라이트로 변경
        //}
        //else if (Input.GetMouseButtonUp(0))
        //{

        //}


        // 마우스가 화면 내에 있는가?
        if (Input.mousePosition.x >= 0 &&
            Input.mousePosition.x <= Screen.width &&
            Input.mousePosition.y >= 0 &&
            Input.mousePosition.y <= Screen.height)
        {
            Vector3 mousePosition = Input.mousePosition; // 마우스 포인터 위치
            Vector3 worldPosition = cam.ScreenToWorldPoint(mousePosition); // 스크린 좌표를 월드좌표로 변환(매우 복잡한 유니티 카메라 체계이니 함부로 사용하지 말것
            worldPosition.z = transform.position.z;

            transform.position = worldPosition; // 마우스 위치로 이동
            spriteRenderer.enabled = true; // 가시화? 불투명화?
        }
        else
        {
            spriteRenderer.enabled = false; // 투명화
        }
    }
}

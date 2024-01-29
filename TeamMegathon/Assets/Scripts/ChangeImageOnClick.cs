using UnityEngine;

public class ChangeImageOnMouseClick : MonoBehaviour
{
    public Sprite newSprite; // 클릭 시 변경할 이미지
    private Sprite originalSprite; // 원래의 이미지

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalSprite = spriteRenderer.sprite;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // 마우스 왼쪽 버튼이 클릭되었을 때
        {
            Vector3 mousePosition = Input.mousePosition; // 마우스의 현재 위치
            if (mousePosition.y <= Screen.height / 3) // 클릭 위치가 화면의 하단 1/3에 포함되는지 확인하고 그 위에서 클릭했으면 클릭으로 인식하지 않는 로직을 다시 재활용.
            {
                spriteRenderer.sprite = newSprite; // 클릭 시 이미지 변경
            }
        
        }
    }
}

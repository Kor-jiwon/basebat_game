using UnityEngine;

public class ChangeImageOnMouseClick : MonoBehaviour
{
    public Sprite newSprite; // Ŭ�� �� ������ �̹���
    private Sprite originalSprite; // ������ �̹���

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalSprite = spriteRenderer.sprite;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // ���콺 ���� ��ư�� Ŭ���Ǿ��� ��
        {
            Vector3 mousePosition = Input.mousePosition; // ���콺�� ���� ��ġ
            if (mousePosition.y <= Screen.height / 3) // Ŭ�� ��ġ�� ȭ���� �ϴ� 1/3�� ���ԵǴ��� Ȯ���ϰ� �� ������ Ŭ�������� Ŭ������ �ν����� �ʴ� ������ �ٽ� ��Ȱ��.
            {
                spriteRenderer.sprite = newSprite; // Ŭ�� �� �̹��� ����
            }
        
        }
    }
}

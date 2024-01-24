using UnityEngine;

public class FollowMouse : MonoBehaviour //�������̺�� ����
{
    public Camera cam;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // ���콺�� ȭ�� ���� �ִ°�?
        if (Input.mousePosition.x >= 0 &&
            Input.mousePosition.x <= Screen.width &&
            Input.mousePosition.y >= 0 &&
            Input.mousePosition.y <= Screen.height)
        {
            Vector3 mousePosition = Input.mousePosition; // ���콺 ������ ��ġ
            Vector3 worldPosition = cam.ScreenToWorldPoint(mousePosition); // ��ũ�� ��ǥ�� ������ǥ�� ��ȯ(�ſ� ������ ����Ƽ ī�޶� ü���̴� �˷��� ���� ���� ��������
            worldPosition.z = transform.position.z;

            transform.position = worldPosition; // ���콺 ��ġ�� �̵�
            spriteRenderer.enabled = true; // ����ȭ? ������ȭ
        }
        else
        {
            spriteRenderer.enabled = false; // ����ȭ
        }
    }
}
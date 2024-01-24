using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement; // �� ������ ���� ���ӽ����̽��� �߰��ߴµ� ���߿� ���δ�..

public class RotateOnClick : MonoBehaviour
{
    public Camera cam;
    private SpriteRenderer spriteRenderer;
    private bool isRotating = false;

    void Start()
    {
        // ��������Ʈ�� ���� ũ��, ��ġ �̷��� �ʿ��ؼ� ��������Ʈ������ ������Ʈ�� ������.
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isRotating)  // ���콺 ���� ��ư�� Ŭ��
        {
            Vector3 mousePosition = Input.mousePosition; // ���콺�� ���� ��ġ
            if (mousePosition.y <= Screen.height / 3) // Ŭ�� ��ġ�� ȭ���� �ϴ� 1/3�� ���ԵǴ��� Ȯ���ϰ� �� ������ Ŭ�������� Ŭ������ �ν����� �ʴ� ����
            {
                Vector3 worldPosition = cam.ScreenToWorldPoint(mousePosition); // ��ũ�� ��ǥ�� ���� ��ǥ�� ��ȯ(ķ ����)
                float objectHeight = spriteRenderer.bounds.size.y;  // ���������� ��ü ����

                // ��ü ��ġ
                transform.position = new Vector3(worldPosition.x + 1, worldPosition.y - 2, cam.nearClipPlane);
                // �˷�ƾ ����
                StartCoroutine(RotateObject());
            }
        }
    }

    IEnumerator RotateObject()
    {
        isRotating = true;
        Quaternion startRotation = transform.rotation; // ȸ�� ���� ����
        Quaternion endRotation = startRotation * Quaternion.Euler(0, 0, 80); // ȸ�� �� ����

        float duration = 0.1f; // ȸ���� �ɸ��� �ð�

        // ��ü ȸ�� ����
        for (float t = 0; t < duration; t += Time.deltaTime)
        {
            transform.rotation = Quaternion.Lerp(startRotation, endRotation, t / duration); // t�ʿ��� ȸ���� ���
            yield return null; // ���� ������ ��ٸ���
        }
     
        transform.rotation = endRotation; // ��ü�� ���� ������ ȸ��
        isRotating = false;

        // ���� ���� �ٽ� ����. �� �κ��� ���߿� �����δ�. �ƴ� �����ߴ�..
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

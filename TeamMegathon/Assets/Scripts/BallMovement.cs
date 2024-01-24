using UnityEngine;
using UnityEngine.SceneManagement; // �� �κ��� ���߿� ������ �ȴ�.

public class BallMovement : MonoBehaviour // Ŭ���� ����
{
    public float speedy; // A = a �� ���� �̷������� ���� ���, ����Ƽ ������ �������� ���� ������ �����ϹǷ� �򰥸��� �ʴ´�.
    public float speedx;
    public float curve;
    public float accel;
    public float growthRate, growthAdd;

    void Update() // ������Ʈ���� ���� �ݺ��Ǹ鼭 �� ���� �޼������ ��� ������
    {
        transform.Translate(speedx * Time.deltaTime, -speedy * Time.deltaTime, 0); // �ӵ��� Ŀ�긦 ����Ͽ� �̵�
        speedx -= curve * Time.deltaTime; // ���� Ŀ�긦 ���� ����
        speedy += accel * Time.deltaTime; // ���� �ٰ����� �ӵ�

        growthRate += growthAdd * Time.deltaTime; // ũ�� ��ȭ ������ ����
        transform.localScale += new Vector3(growthRate, growthRate, growthRate) * Time.deltaTime; // ũ�� ��ȭ

        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>(); // ���� ����
        spriteRenderer.flipX = true; // ���� ������ �ݴ�� x��ǥ�� �ø���Ŵ. �ݴ�������� ���������� �ø����� �ʵ��� �����ؾ���.
    }

    void OnBecameInvisible() // �׽�Ʈ�� �ӽù���. ȭ�� ������ ����̰� ������ ���� �����. ���߿� ����
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // �����ִ� ���� �ٽ� �ε�
    }

}

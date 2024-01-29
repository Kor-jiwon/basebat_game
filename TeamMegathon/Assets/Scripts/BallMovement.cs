using UnityEngine;
using UnityEngine.SceneManagement; // �� �κ��� ���߿� ������ �ȴ�.

public class BallMovement : MonoBehaviour // Ŭ���� ����
{
    public float speedy; // A = a �� ���� �̷������� ���� ���, ����Ƽ ������ �������� ���� ������ �����ϹǷ� �򰥸��� �ʴ´�. �̰� �ƹ��� �𸣴� �������ʰ�޽�ų
    public float speedx;
    public float curve;
    public float accel;
    public float growthRate, growthAdd;

    private int randomSign; // "Ŭ���� ���� ��� ������ ����" <<<<<<<<<< �ſ� �߿�



    //void Update() // ������Ʈ���� ���� �ݺ��Ǹ鼭 �� ���� �޼������ ��� �����ϴ� ������
    //{
    //transform.Translate(speedx * Time.deltaTime, -speedy * Time.deltaTime, 0); // �ӵ��� Ŀ�긦 ����Ͽ� �̵�
    //speedx -= curve * Time.deltaTime; // ���� Ŀ�긦? ���� ����?
    //speedy += accel * Time.deltaTime; // ���� �ٰ����� �ӵ�

    //growthRate += growthAdd * Time.deltaTime; // ũ�� ��ȭ ������ ����
    //transform.localScale += new Vector3(growthRate, growthRate, growthRate) * Time.deltaTime; // ũ�� ��ȭ

    //SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>(); // ���� ����
    //spriteRenderer.flipX = true; // ���� ������ �ݴ�� x��ǥ�� �ø���Ŵ. �ݴ�������� ���������� �ø����� �ʵ��� �����ؾ��� �ʰ��� ����
    //}

    //public float randomValue = Random.Range(0f, 1f);
    //public int randomSign = randomValue < 0.5f ? -1 : 1; // -1 �Ǵ� 1 �� �ϳ��� �������� ����

    void Start() // �� ���� ù ���� �� ������ �ʾƾ� �ϹǷ� start���� ���
    {
        float randomValue = Random.Range(0f, 1f);
        randomSign = randomValue < 0.5f ? -1 : 1;
    }

    void Update() // ������Ʈ���� ���� �ݺ��Ǹ鼭 �� ���� �޼������ ��� �����ϴ� ����
    {

    transform.Translate(randomSign * speedx * Time.deltaTime, -speedy * Time.deltaTime, 0); // �ӵ��� Ŀ�긦 ����Ͽ� �̵�
    speedx -= curve * Time.deltaTime; // ���� Ŀ�긦? ���� ����?
    speedy += accel * Time.deltaTime; // ���� �ٰ����� �ӵ�

    growthRate += growthAdd * Time.deltaTime; // ũ�� ��ȭ ������ ����
    transform.localScale += new Vector3(growthRate, growthRate, growthRate) * Time.deltaTime; // ũ�� ��ȭ

    SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>(); // ���� ����
    spriteRenderer.flipX = true; // ���� ������ �ݴ�� x��ǥ�� �ø���Ŵ. �ݴ�������� ���������� �ø����� �ʵ��� �����ؾ��� �ʰ��� ����
    }



    void OnBecameInvisible() // �׽�Ʈ�� �ӽù����̾�. ȭ�� ������ ����̰� ������ ���� �����. ���߿� �����ؾ��Ԥ���
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // �����ִ� ���� �ٽ� �ε�
    }

}

using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallMovement : MonoBehaviour
{
    public float speedy;
    public float speedx;
    public float curve;
    public float accel;
    public float growthRate, growthAdd;
    public GameObject gong;
    public static int randomSign;
    private bool canUpdate = false;

    IEnumerator Start() // Start를 코루틴으로 변경
    {
        float randomValue = Random.Range(0f, 1f);
        randomSign = randomValue < 0.5f ? -1 : 1;

        yield return new WaitForSeconds(3f); // 3초 기다림
        canUpdate = true; // Update 메서드를 실행 가능하게 함
    }

    void Update()
    {
        if (canUpdate) // canUpdate가 true일 때만 실행
        {
            transform.Translate(randomSign * speedx * Time.deltaTime, -speedy * Time.deltaTime, 0);
            speedx -= curve * Time.deltaTime;
            speedy += accel * Time.deltaTime;

            growthRate += growthAdd * Time.deltaTime;
            transform.localScale += new Vector3(growthRate, growthRate, growthRate) * Time.deltaTime;

            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.flipX = true;

            if (gong.transform.position.y < -5.16)
            {
                SceneManager.LoadScene("die");
            }
        }
    }
}

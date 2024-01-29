using UnityEngine;
using UnityEngine.SceneManagement; // 이 부분은 나중에 지워두 된다.

public class BallMovement : MonoBehaviour // 클래스 선언
{
    public float speedy; // A = a 꼴 말고 이런식으로 적을 경우, 유니티 에디터 내에서만 변수 수정이 가능하므로 헷갈리지 않는다. 이건 아무나 모르는 초초초초고급스킬
    public float speedx;
    public float curve;
    public float accel;
    public float growthRate, growthAdd;

    private int randomSign; // "클래스 레벨 멤버 변수로 변경" <<<<<<<<<< 매우 중요



    //void Update() // 업데이트문은 무한 반복되면서 그 안의 메서드들을 계속 실행하는 구조야
    //{
    //transform.Translate(speedx * Time.deltaTime, -speedy * Time.deltaTime, 0); // 속도와 커브를 고려하여 이동
    //speedx -= curve * Time.deltaTime; // 공이 커브를? 도는 정도?
    //speedy += accel * Time.deltaTime; // 공이 다가오는 속도

    //growthRate += growthAdd * Time.deltaTime; // 크기 변화 정도를 가속
    //transform.localScale += new Vector3(growthRate, growthRate, growthRate) * Time.deltaTime; // 크기 변화

    //SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>(); // 수정 예정
    //spriteRenderer.flipX = true; // 자전 방향이 반대라서 x좌표를 플립시킴. 반대방향으로 던졌을때는 플립되지 않도록 수정해야해 너가해 ㅎㅎ
    //}

    //public float randomValue = Random.Range(0f, 1f);
    //public int randomSign = randomValue < 0.5f ? -1 : 1; // -1 또는 1 중 하나를 랜덤으로 선택

    void Start() // 이 값은 첫 생성 후 변하지 않아야 하므로 start문을 사용
    {
        float randomValue = Random.Range(0f, 1f);
        randomSign = randomValue < 0.5f ? -1 : 1;
    }

    void Update() // 업데이트문은 무한 반복되면서 그 안의 메서드들을 계속 실행하는 구조
    {

    transform.Translate(randomSign * speedx * Time.deltaTime, -speedy * Time.deltaTime, 0); // 속도와 커브를 고려하여 이동
    speedx -= curve * Time.deltaTime; // 공이 커브를? 도는 정도?
    speedy += accel * Time.deltaTime; // 공이 다가오는 속도

    growthRate += growthAdd * Time.deltaTime; // 크기 변화 정도를 가속
    transform.localScale += new Vector3(growthRate, growthRate, growthRate) * Time.deltaTime; // 크기 변화

    SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>(); // 수정 예정
    spriteRenderer.flipX = true; // 자전 방향이 반대라서 x좌표를 플립시킴. 반대방향으로 던졌을때는 플립되지 않도록 수정해야해 너가해 ㅎㅎ
    }



    void OnBecameInvisible() // 테스트용 임시방편이야. 화면 밖으로 방맹이가 나가면 씬을 재시작. 나중에 삭제해야함ㅁㅁ
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // 열려있는 씬을 다시 로드
    }

}

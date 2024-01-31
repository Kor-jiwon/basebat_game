using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement; // 씬 관리를 위한 네임스페이스를 추가했는데 나중에 빼두댐..

public class RotateOnClick : MonoBehaviour
{
    public Camera cam;
    private SpriteRenderer spriteRenderer;
    private bool isRotating = false;
    private int handposition; // 수정에 용이하도록 새 변수를 선언(고정좌표겂)
    public static float mousex;
    public static float bally;
    public GameObject subject;
    public GameObject mouse;

    void Start()
    {
        // 스프라이트의 현재 크기, 위치 이런게 필요해서 스프라이트렌더러 컴포넌트를 가져옴.
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isRotating)  // 마우스 왼쪽 버튼을 클릭
        {
            Vector3 mousePosition = Input.mousePosition; // 마우스의 현재 위치
            if (mousePosition.y <= Screen.height / 3) // 클릭 위치가 화면의 하단 1/3에 포함되는지 확인하고 그 위에서 클릭했으면 클릭으로 인식하지 않는 로직
            {
                //Vector3 worldPosition = cam.ScreenToWorldPoint(mousePosition); // 스크린 좌표를 월드 좌표로 변환(캠 기준일거임 아마)
                Vector3 worldPosition = cam.ScreenToWorldPoint(new Vector3(mousePosition.x, handposition, 0)); // 위에서 안먹혀서 뉴 벡터로 변형
                float objectHeight = spriteRenderer.bounds.size.y;  // 아찬가지로 물체 높이

                // 물체 배치
                transform.position = new Vector3(worldPosition.x + 1, worldPosition.y - 2, cam.nearClipPlane);
                // 똥루틴 시작
                StartCoroutine(RotateObject());
            }
        }
    }

   

    IEnumerator RotateObject()
    {
        isRotating = true;
        Quaternion startRotation = transform.rotation; // 회전 시적 각도
        Quaternion endRotation = startRotation * Quaternion.Euler(0, 0, 80); // 회전 끝 각도

        float duration = 0.1f; // 회전에 걸리는 시간

        // 물체 회전 로직
        for (float t = 0; t < duration; t += Time.deltaTime)
        {
            transform.rotation = Quaternion.Lerp(startRotation, endRotation, t / duration); // t초에서 회전각 계산
            yield return null; // 다음 프레임 기다리기
        }
     
        transform.rotation = endRotation; // 물체를 최종 각도로 회전
        mousex = mouse.transform.position.x;
        bally = subject.transform.position.y;
        wait(0.8f);
        SceneManager.LoadScene("fly");
        Debug.Log("tst");
        isRotating = false;
        
        
    }
    IEnumerator wait( float t)
    {
        yield return new WaitForSeconds(t);
    }
}

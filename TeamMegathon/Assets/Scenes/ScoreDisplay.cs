using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    public gongfly gongflyScript; // gongfly 스크립트 참조
    public Text scoreText; // TextMeshPro 컴포넌트 참조

    void Update()
    {
        scoreText.text = "Score: " + gongflyScript.score.ToString();
    }
}

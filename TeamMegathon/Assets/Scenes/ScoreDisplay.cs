using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    public gongfly gongflyScript; // gongfly ��ũ��Ʈ ����
    public Text scoreText; // TextMeshPro ������Ʈ ����

    void Update()
    {
        scoreText.text = "Score: " + gongflyScript.score.ToString();
    }
}

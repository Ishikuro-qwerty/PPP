using UnityEngine;
using UnityEngine.UI;

public class HaeMoveDEMO : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5f; // 移動速度
    [SerializeField]
    private float rotationSpeed = 180f; // 回転速度
    [SerializeField]
    private int maxClickCount = 3; // 最大クリック回数
    private int clickCount = 0; // クリックされた回数

    public Text clickCountText; // UnityのUI Textコンポーネント

    void Start()
    {
        // UI Textコンポーネントの取得
        clickCountText = GameObject.Find("ClickCountText").GetComponent<Text>();
        UpdateClickCountText();
    }

    void Update()
    {
        // ランダムな方向に移動
        MoveRandomly();

        // ランダムな方向に回転
        RotateRandomly();
    }

    void MoveRandomly()
    {
        // ランダムな方向に進むベクトルを生成
        Vector3 randomDirection = new Vector3(Random.Range(-10f, 10f), Random.Range(-10f, 10f), 0f).normalized;

        // 現在の位置からランダムな方向に移動
        transform.Translate(randomDirection * moveSpeed * Time.deltaTime);
    }

    void RotateRandomly()
    {
        // ランダムな角度で回転
        transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
    }

    public void ClickDestroy()
    {
        clickCount++; // クリック回数を増やす

        // 最大クリック回数以上クリックされたらオブジェクトを破壊
        if (clickCount >= maxClickCount)
        {
            Destroy(gameObject);
        }

        UpdateClickCountText();
    }

    void UpdateClickCountText()
    {
        // UI Textにクリック回数を表示
        clickCountText.text = "HP: " + (maxClickCount - clickCount).ToString();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HaeMove : MonoBehaviour
{
    [SerializeField]
    public float moveSpeed = 5f; // 移動速度
    [SerializeField]
    public float rotationSpeed = 180f; // 回転速度
    [SerializeField]
    private int clicked = 0;

    private int clickCount = 0; // クリックされた回数
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

        // n回以上回以上クリックされたらオブジェクトを破壊
        if (clickCount == clicked)
        {
            Destroy(gameObject);
        }
    }
}

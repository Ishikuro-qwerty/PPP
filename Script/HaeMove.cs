using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HaeMove : MonoBehaviour
{
    [SerializeField]
    public float moveSpeed = 5f; // �ړ����x
    [SerializeField]
    public float rotationSpeed = 180f; // ��]���x
    [SerializeField]
    private int clicked = 0;

    private int clickCount = 0; // �N���b�N���ꂽ��
    void Update()
    {
        // �����_���ȕ����Ɉړ�
        MoveRandomly();

        // �����_���ȕ����ɉ�]
        RotateRandomly();

    }

    void MoveRandomly()
    {
        // �����_���ȕ����ɐi�ރx�N�g���𐶐�
        Vector3 randomDirection = new Vector3(Random.Range(-10f, 10f), Random.Range(-10f, 10f), 0f).normalized;

        // ���݂̈ʒu���烉���_���ȕ����Ɉړ�
        transform.Translate(randomDirection * moveSpeed * Time.deltaTime);
    }

    void RotateRandomly()
    {
        // �����_���Ȋp�x�ŉ�]
        transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
    }

    public void ClickDestroy()
    {
        clickCount++; // �N���b�N�񐔂𑝂₷

        // 3��ȏ�N���b�N���ꂽ��I�u�W�F�N�g��j��
        if (clickCount == clicked)
        {
            Destroy(gameObject);
        }
    }
}

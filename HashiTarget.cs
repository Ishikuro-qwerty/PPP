using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HashiTarget : MonoBehaviour
{
    //���W�p�̕ϐ�
    Vector3 mousePos, worldPos;

    private void Start()
    {
        Cursor.visible = false;
    }
    void Update()
    {
        //�}�E�X���W�̎擾
        mousePos = Input.mousePosition;
        //�X�N���[�����W�����[���h���W�ɕϊ�
        worldPos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 10f));
        //���[���h���W�����g�̍��W�ɐݒ�
        transform.position = worldPos;
    }
}
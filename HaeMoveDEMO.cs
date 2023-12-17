using UnityEngine;
using UnityEngine.UI;

public class HaeMoveDEMO : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5f; // �ړ����x
    [SerializeField]
    private float rotationSpeed = 180f; // ��]���x
    [SerializeField]
    private int maxClickCount = 3; // �ő�N���b�N��
    private int clickCount = 0; // �N���b�N���ꂽ��

    public Text clickCountText; // Unity��UI Text�R���|�[�l���g

    void Start()
    {
        // UI Text�R���|�[�l���g�̎擾
        clickCountText = GameObject.Find("ClickCountText").GetComponent<Text>();
        UpdateClickCountText();
    }

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

        // �ő�N���b�N�񐔈ȏ�N���b�N���ꂽ��I�u�W�F�N�g��j��
        if (clickCount >= maxClickCount)
        {
            Destroy(gameObject);
        }

        UpdateClickCountText();
    }

    void UpdateClickCountText()
    {
        // UI Text�ɃN���b�N�񐔂�\��
        clickCountText.text = "HP: " + (maxClickCount - clickCount).ToString();
    }
}

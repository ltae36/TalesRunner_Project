using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // �÷��̾ ���ϴ� �������� �̵��Ѵ�.
    // ����, �ӷ� = �ӵ�(Vector)     

    public float moveSpeed;
    public bool canMove;    

    // ó�� �����Ǿ��� �� �� ���� ����Ǵ� �Լ�
    void Start()
    {        

    }

    // �� �����Ӹ��� �ݺ��ؼ� �����ϴ� �Լ�
    void Update()
    {
        #region �̵� ����

        // ������� �Է� �ޱ�

        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(h, 0, v);

        // ������ ���̸� ������ 1�� �ٲ۴�.(����ȭ)
        direction.Normalize();

        if (canMove == false)
        {
            moveSpeed = 0;
        }
        else
        {
            moveSpeed = 20f;
        }

        // �̵� ����: p = p0 + vt
        transform.position += direction * moveSpeed * Time.deltaTime;


        #endregion
    }

}

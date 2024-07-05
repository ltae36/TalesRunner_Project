using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // �÷��̾ ���ϴ� �������� �̵��Ѵ�.
    // ����, �ӷ� = �ӵ�(Vector)     

    public float moveSpeed;
    public bool canMove;
    Rigidbody rb;
    Vector3 direction;

    // ó�� �����Ǿ��� �� �� ���� ����Ǵ� �Լ�
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // �� �����Ӹ��� �ݺ��ؼ� �����ϴ� �Լ�
    void Update()
    {
        #region �̵� ����

        // ������� �Է� �ޱ�

        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        direction = new Vector3(h, 0, v);

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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall") 
        {
            // �浹 �� �̵� ����
            direction = Vector3.zero;
        }
    }
   
}

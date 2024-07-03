using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // 플레이어를 원하는 방향으로 이동한다.
    // 방향, 속력 = 속도(Vector)     

    public float moveSpeed;
    public bool canMove;    

    // 처음 생성되었을 때 한 번만 실행되는 함수
    void Start()
    {        

    }

    // 매 프레임마다 반복해서 실행하는 함수
    void Update()
    {
        #region 이동 공식

        // 사용자의 입력 받기

        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(h, 0, v);

        // 벡터의 길이를 무조건 1로 바꾼다.(정규화)
        direction.Normalize();

        if (canMove == false)
        {
            moveSpeed = 0;
        }
        else
        {
            moveSpeed = 20f;
        }

        // 이동 공식: p = p0 + vt
        transform.position += direction * moveSpeed * Time.deltaTime;


        #endregion
    }

}

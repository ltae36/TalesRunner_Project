using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitControll : MonoBehaviour
{
    public Animator anim;
    EnemyPatrolMove move;

    bool isHit = false;

    float currentTime;
    float downTime = 5f;

    void Start()
    {
        if (move == null)
        {
            Debug.LogError("EnemyPatrolMove component not found on this GameObject. Please add it or assign it correctly.");
            move = GetComponent<EnemyPatrolMove>();
        }
    }

    void Update()
    {
        if (move == null || anim == null)
        {
            // Early exit if move or anim is not initialized
            return;
        }

        if (isHit)
        {
            move.moveSpeed = 0;
            currentTime += Time.deltaTime;
            print(currentTime);
            anim.SetBool("HitPlayer", true);
            if (currentTime > downTime)
            {
                move.moveSpeed = 10f;
                anim.SetTrigger("getUp");
                isHit = false;
                currentTime = 0;
            }
        }
        else 
        {
            anim.SetBool("HitPlayer", false);
        }

    }

    // �ٸ� ������Ʈ�� �´ڶ߷�����
    // �÷��̾��� �ε����� �Ѿ�����. ��� �Ŀ� �ٽ� �Ͼ�� �޷�����
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player") 
        {
            isHit = true;
        }
    }
}

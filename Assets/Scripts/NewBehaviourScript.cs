using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    #region 캐릭터 이동
    public float x, v;
    public float speed = 5;
    Vector3 move;

    void Start()
    {
        
    }
    

    void Update()
    {
        x = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(x, 0, v);

        transform.position += move * speed * Time.deltaTime;  // p + p0 + vt
    }
    #endregion

    #region 총알 발사 

    GameObject bulletprefab;
    GameObject fireposition; 




    void start()
    {

    }





void update()
    {
        // 마우스 좌클릭을 누를때 총알이 생성된다
        if(Input.GetMouseButton(0))
        {
            GameObject bullet = Instantiate(bulletprefab);
            // 총알이 fireposition의 위치로 이동한다.
            fireposition.transform.position = bullet.transform.position;
            // fire 포지션의 위치는 player의 위에 위치해있다

            Vector3 firepos = new Vector3(0, 1f, 0);

            firepos = bullet.transform.position;



        }
        #endregion
    }







}
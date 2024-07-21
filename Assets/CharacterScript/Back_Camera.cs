using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class Back_Camera : MonoBehaviour
{
    public Transform character; // 캐릭터의 Transform을 여기에 할당
    public Vector3 offset = new Vector3(0f, 2f, -5f); // 카메라의 상대적 위치(offset) 설정

    void LateUpdate()
    {
        if (character != null)
        {
            // 캐릭터의 위치에 offset을 더해 카메라의 원하는 위치로 이동시킵니다.
            transform.position = character.position + offset;

            // 캐릭터의 회전 값을 가져와서 그에 맞추어 카메라도 회전합니다.
            transform.rotation = character.rotation;

            // 캐릭터를 바라보도록 카메라의 방향을 설정합니다.
            transform.LookAt(character);

        }
    }
}

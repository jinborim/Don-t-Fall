using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public Transform target; //따라갈 대상
    public Vector3 offset; //Ball과 카메라 사이의 거리

    void Start()
    {
        //시작할 때 공과 카메라 사이의 실제 거리를 계산해서 저장
        if(target != null)
        {
            offset = transform.position - target.position;
        }
    }

    void LateUpdate()
    {
        //LateUpdate는 카메라에 사용하기 제일 좋음
        if(target != null)
        {
            transform.position = target.position + offset;
            //공의 현재 위치에 처음에 계산한 거리를 더해서 카메라 위치를 둠
        }
    }
}

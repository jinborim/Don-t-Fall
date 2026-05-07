using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPoint : MonoBehaviour
{
    /**
    * 아이템이 제자리에서 회전을 시켜 시각적인 효과를 줌
    **/

    //아이템이 회전하는 속도
    public float rotateSpeed = 100f;


    // Update is called once per frame
    void Update()
    {
        //매 프레임 회전
        transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
    }
}

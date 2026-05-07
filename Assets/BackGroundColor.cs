using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundColor : MonoBehaviour
{
    /**
     * 배경색을 시간 마다 바꿔줌
     */

    public Color[] colors; //  바꿀 색상들의 리스트
    public float changeSpeed; // 색이 바뀌는 속도

    private Camera cam;         // 카메라 컴포넌트를 담을 변수
    private int colorIndex = 0; // 현재 목표로 하는 color 배열의 번호
    private float lerpTime = 0f;// 다음 색상으로 넘어가기 위해 시간을 재는 타이머

    void Start()
    {
        // 이 스크립트가 붙어 있는 오브젝트에서 카메라 컴포넌트를 가져옴
        cam = GetComponent<Camera>();

        // 색이 최소 2개는 있어야 서로 바꿀 수 있으므로 경고 메세지 출력
        if(colors.Length < 2)
        {
            Debug.LogWarning("색을 2개 이상 설정");
        }
    }

    void Update()
    {
        // 배경색이 부드럽게 전환되도록
        // Color.Lerp(현재색, 목표색, 변화량)
        // changeSpeed가 높을 수록 색 변화 속도가 빨라짐
        cam.backgroundColor = Color.Lerp(cam.backgroundColor, colors[colorIndex], changeSpeed * Time.deltaTime);

        //일정 시간마다 목표 색상을 변경
        lerpTime += Time.deltaTime; // 매 프레임마다 시간을 더함
        if(lerpTime > 3f) //3초마다 다음 색상으로 변경
        {
            lerpTime = 0f; // 시간 초기화

            //%를 사용해서 배열의 마지막 번호를 넘어가면 다시 0번으로 돌아오게 함
            colorIndex = (colorIndex + 1) % colors.Length;
        }
    }
}

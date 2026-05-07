using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mute : MonoBehaviour
{
    public Image buttonImage; // 변경할 버튼의 이미지
    public Sprite soundOn; //소리 킨 아이콘
    public Sprite soundOff; // 소리 끈 아이콘

    private bool isMuted = false;

    public void ObjMuted()
    {
        isMuted = !isMuted; //

        if (isMuted)
        {
            // 클릭시 소리 끄기
            AudioListener.pause = true;
            // 음소거 아이콘으로 변경
            buttonImage.sprite = soundOff;
            Debug.Log("음소거");
        }
        else
        {
            // 클릭시 소리 키기
            AudioListener.pause = false;
            // 소리 아이콘으로 변경
            buttonImage.sprite = soundOn;
            Debug.Log("소리 재생");
        }
    }
}

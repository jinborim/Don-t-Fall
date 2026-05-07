using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Option : MonoBehaviour
{
    [SerializeField] private GameObject optionUI; // 연결할 옵션 UI
    private bool isStop = false; // 일시정지 상태인지 확인

    // 옵션 창 열기
    public void Open()
    {
        optionUI.SetActive(true);   // UI 활성화
        Time.timeScale = 0f;
        Debug.Log("게임 일시정지");
    }

    public void CloseOption()
    {
        optionUI.SetActive(false); // UI 비활성화
        Time.timeScale = 1f;
        Debug.Log("게임 이어서 다시");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    // Start is called before the first frame update
    public void ExitApp()
    {
        #if UNITY_EDITOR
        // 유니티 에디터에서 글 때 실행
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        //실제 안드로이드, pc 앱을 종료할 때 실행
        Application.Quit();
        #endif
        Debug.Log("게임이 종료되었습니다.");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //씬 넘어갈려면 반드시 필요함

public class Scene : MonoBehaviour
{
    public void StartScene()
    {
        SceneManager.LoadScene("Main"); //다음으로 넘어갈 씬 이름
    }
    
}

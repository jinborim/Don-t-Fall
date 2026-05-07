using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    /**
     *  게임의 배경음악과 효과음을 관리
     */

    //어디서든 접근 가능함
    public static SoundManager instance;

    private AudioSource bgmSource; // 배경 사운드
    private AudioSource audioSource; // item 효과음
    private AudioSource gameOverSource; // gameover 효과음

    void Awake()
    {
        //씬이 SoundManager가 하나만 존재하도록 함
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); //씬이 바뀌어도 파괴되지 않음
            
        }
        else
        {
            instance.StopGameOverSound();
            Destroy(gameObject);
            return; // 아래 초기화 로직을 실행하지 않도록 종료
        }
        bgmSource = GetComponent<AudioSource>();
        audioSource = GetComponent<AudioSource>();
        gameOverSource = gameObject.AddComponent<AudioSource>();
    }

    //배경 음악을 재생하는 함수
    public void BgmBackground(AudioClip bgmClip, float volume = 0.5f)
    {
        if (bgmSource.clip == bgmClip) return; // 이미 재생 중이면 무시

        bgmSource.clip = bgmClip;
        bgmSource.volume = volume;
        bgmSource.Play();
    }

    // 게임 오버 효과음을 재생하는 함수
    public void PlayGameOverSound(AudioClip clip)
    {
        if (clip == null) return;
        gameOverSource.clip = clip;
        gameOverSource.Play();
    }

    //외부에서 소리를 재생할 때 호출
    public void PlaySource(AudioClip clip)
    {
        if(clip != null)
        {
            //  기존에 나오던 소리를 끊지 않고 재생
            audioSource.PlayOneShot(clip);
        }
    }

    // 게임 오버 소리를 끔
    public void StopGameOverSound()
    {
        if (gameOverSource != null && gameOverSource.isPlaying)
        {
            gameOverSource.Stop();
        }
    }
}

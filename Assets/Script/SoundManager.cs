using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public static SoundManager instance;

    private AudioSource bgmSource; // 배경 효과음
    private AudioSource audioSource; // item 효과음
    private AudioSource gameOverSource; // gameover 효과음

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); //씬이 바뀌어도 파괴되지 않음
            
        }
        else
        {
            instance.StopGameOverSound();
            Destroy(gameObject);
            return; 
        }
        bgmSource = GetComponent<AudioSource>();
        audioSource = GetComponent<AudioSource>();
        gameOverSource = gameObject.AddComponent<AudioSource>();
    }


    public void BgmBackground(AudioClip bgmClip, float volume = 0.5f)
    {
        if (bgmSource.clip == bgmClip) return; // 이미 재생 중이면 무시

        bgmSource.clip = bgmClip;
        bgmSource.volume = volume;
        bgmSource.Play();
    }

    public void PlayGameOverSound(AudioClip clip)
    {
        if (clip == null) return;
        gameOverSource.clip = clip;
        gameOverSource.Play();
    }

    public void PlaySource(AudioClip clip)
    {
        if(clip != null)
        {
            audioSource.PlayOneShot(clip);
        }
    }

    public void StopGameOverSound()
    {
        if (gameOverSource != null && gameOverSource.isPlaying)
        {
            gameOverSource.Stop();
        }
    }
}

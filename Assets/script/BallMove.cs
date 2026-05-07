using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BallMove : MonoBehaviour
{
    public float speed; //처음 속도
    public float maxspeed; // 최대 속도 제한
    public float acceleration; // 초당 증가할 속도
    private bool movingRight = true; // 공 이동방향 true: 오른쪽 false:앞쪽
    private bool isDead = false; // 게임 오버 상태 확인

    public AudioClip backgroundMusic; // 배경음 파일
    public AudioClip itemSource; // 아이템을 먹었을때 재생할 소리
    public AudioClip gameOverSorce; // 게임 오버 시 재생할 소리

    public GameObject gameOverPanel; // 게임 오버 UI
    private bool isGameStart = false; // 게임 시작 여부
    
    private Rigidbody rb; 
    public float rotationBall = 500f; //공의 회전 속도

    public Text scoreText; // 연결할 점수 Text
    public int score; //점수

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        UpdateScoreUI(); // 시작할 때 점수 초기화
    }
    void Update()
    {
        // 게임 시작 대기
        if (!isGameStart)
        {
            //클릭하면 공이 움직이도록 함
            if (Input.GetMouseButtonDown(0))
            {
                isGameStart = true;

                // SoundManager를 통해 배경음악 재생
                if (SoundManager.instance != null && backgroundMusic != null)
                {
                    SoundManager.instance.BgmBackground(backgroundMusic);
                }
                return;
            }
            return; // 시작 전에는 아래 로직들을 실행하지 않음
        }
        
        // 매 프레임 마다 조금씩 속도 증가
        if(speed < maxspeed)
        {
            speed += acceleration * Time.deltaTime;
        }
        
        // 죽었으면 실행 중지
        if (isDead) return;


        if (Input.GetMouseButtonDown(0))
        {
            movingRight = !movingRight;
        }

        // 이동 및 공 추락 체크
        Move(); 
        CheckFall();   
    }

    void Move()
    {
        // 방향 설정 (오른쪽 or 앞)
        Vector3 direction = movingRight ? Vector3.right : Vector3.forward;
        
        //실제 위치 이동
        transform.position += direction * speed * Time.deltaTime;

        // 공이 이동 방향에 맞춰 구르도록 구현
        Vector3 rotationAxis = new Vector3(direction.z, 0, -direction.x);
        transform.Rotate(rotationAxis, rotationBall * Time.deltaTime, Space.World);

    }

    void CheckFall()
    {
        // 공의 높이 -2 보다 낮아지면 추락으로 인식하며 게임 오버가 됨
        if (transform.position.y < -2f && !isDead)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        isDead = true;
        // 게임 오버 효과음
        if(SoundManager.instance != null && gameOverSorce != null)
        {
            SoundManager.instance.PlayGameOverSound(gameOverSorce);
        }
  
        // 게임 오버 UI
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }
    }

    // 버튼을 눌렀을 때 실행될 함수
    public void RestartGame()
    {
        if(SoundManager.instance != null)
        {
            SoundManager.instance.StopGameOverSound();
        }
        // 현재 열려 있는 씬을 다시 로드
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OnCollisionExit(Collision collision)
    {
        // "Floor" 태그를 가진 발판을 미리 생성 (무한 생성 로직)
        if (collision.gameObject.CompareTag("Floor"))
        {
            FindObjectOfType<PathSpawner>().SpawnFloor();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //충돌한 오브젝트의 태그가 "Item"인지 확인
        if (other.gameObject.CompareTag("Item"))
        {
            SoundManager.instance.PlaySource(itemSource);   // 아이템 획득 효과음
            Destroy(other.gameObject);  // 아이템을 먹으면 삭제
            score += 5; // 충돌할때마다 5점 추가
            UpdateScoreUI(); // 화면 점수

        }
    }

    // 현재 점수 상태를 화면에서 갱신
    void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score :" + score;
        }
    }
}

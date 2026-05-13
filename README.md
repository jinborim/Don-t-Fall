플레이 영상 https://www.youtube.com/shorts/GDUrLYqpGDI?si=9YmgwBZ92IL5BwYZ


클릭 기반 방향 전환, 점수 시스템 및 사운드/UI 처리가 포함된 3D 공 이동 제어 스크립트

BallMove.cs

전처리기 지시문을 활용하여 에디터 및 런타임 환경에서 동작하는 앱 종료 기능 구현

Exit.cs

Time.deltaTime을 활용하여 부드럽고 일정한 속도로 자전하는 아이템 회전 로직

ItmePoint.cs

LateUpdate와 Offset 벡터를 활용하여 타겟의 움직에 맞춰 시점을 이동시키는 카메라 추적 로직

MainCamera.cs

상태 기반 (bool) 체크를 통해 오디오 일시정지 및 UI 스프라이트를 실시간으로 변겨하는 사운드 제어 로직

Mute.cs

옵션 메뉴의 활성화 상태에 따라 게임 흐름 (일시정지 / 재개)을 제어하는 UI 스크립트

Option.cs

랜덤 분기 로직과 Instantiate를 활용하여 동적으로 경로와 아이템을 자동 생성하는 절차적 맵 빌더

PathSpawner.cs

유니티 SceneManager API를 활용하여 게임 시작 또는 씬 간 전환을 처리하는 로직

Scene.cs

싱글톤 패턴을 활용하여 배경음, 효과음, 게임 오버 사운드를 통합 관리하고 씬 전환 시에도 유지되는 오디오 매니저

SoundManager.cs

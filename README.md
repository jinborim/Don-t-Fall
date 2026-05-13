BallMove.cs 코드 요약
BallMove.cs는 플레이어 캐릭터(공)의 이동, 점수 획득, 그리고 게임 상태(시작/오버)를 관리하는 핵심 스크립트입니다.

- Movement: 클릭 시 방향 전환(Zig-Zag 이동) 및 시간 경과에 따른 가속 시스템.
- Score System: 아이템 획득 시 5점 추가 및 UI 실시간 반영.
- Game Flow: 시작 대기, 추락 시 게임 오버 UI 표시 및 재시작 기능.
- Map Interaction: 발판을 벗어날 때마다 새로운 길을 생성하는 무한 로직 연동.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathSpawner : MonoBehaviour
{
    public GameObject floorPrefab;
    public GameObject pointPrefab; // 아이템 프리팹
    private Vector3 lastPos;

    public int itemPoint = 20; // 아이템이 나올 확률 

    void Start()
    {
        //첫 발판의 위치를 기억
        lastPos = floorPrefab.transform.position;
        //시작 시 블록 100개깔기
        for (int i = 0; i < 100; i++) {
            SpawnFloor();
        }

    }
    public void SpawnFloor()
    {
        // 0이면 오른쪽(+X), 1이면 앞쪽(+Z)
        // 공은 오른쪽으로 움직이는데 게임 처음 시작때 발판이 왼쪽에 생기면 갈 수가 없음
        int rand = Random.Range(0, 2);
        Vector3 spawnPos = Vector3.zero;

        if (rand == 0) spawnPos = Vector3.right;   // 오른쪽
        else spawnPos = Vector3.forward;           // 앞쪽
        
        lastPos += spawnPos; // 발판 크기가 1인 경우
        GameObject newFloor = Instantiate(floorPrefab, lastPos, Quaternion.identity);

        //랜덤 확률로 아이템 생성
        if(Random.Range(0, 101) <= itemPoint)
        {
            SpawnItem(newFloor);
        }
    }

    void SpawnItem(GameObject floor)
    {
        Vector3 itemPos = floor.transform.position + new Vector3(0, 1.0f, 0);

        GameObject item = Instantiate(pointPrefab, itemPos, Quaternion.identity);

        //발판이 사라질 때 같이 사라지도록 아이템을 발판의 자식으로 설정
        item.transform.SetParent(floor.transform);
    }
}

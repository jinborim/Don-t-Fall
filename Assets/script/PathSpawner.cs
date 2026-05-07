using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathSpawner : MonoBehaviour
{
    public GameObject floorPrefab;
    public GameObject pointPrefab; 
    private Vector3 lastPos;

    public int itemPoint = 20; 

    void Start()
    {
        lastPos = floorPrefab.transform.position;
        //시작 시 블록 100개깔기
        for (int i = 0; i < 100; i++) {
            SpawnFloor();
        }

    }
    public void SpawnFloor()
    {
        int rand = Random.Range(0, 2);
        Vector3 spawnPos = Vector3.zero;

        if (rand == 0) spawnPos = Vector3.right;  
        else spawnPos = Vector3.forward;          
        
        lastPos += spawnPos; 
        GameObject newFloor = Instantiate(floorPrefab, lastPos, Quaternion.identity);

        if(Random.Range(0, 101) <= itemPoint)
        {
            SpawnItem(newFloor);
        }
    }

    void SpawnItem(GameObject floor)
    {
        Vector3 itemPos = floor.transform.position + new Vector3(0, 1.0f, 0);

        GameObject item = Instantiate(pointPrefab, itemPos, Quaternion.identity);

        item.transform.SetParent(floor.transform);
    }
}

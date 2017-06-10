using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour {

    public Transform tilePrefab;
    public Transform NavMeshFloor;
    public Transform NavMeshMask;
    public Vector2 mapSize;
    public Vector2 MaxMapSize;

    [Range(0,1)]
    public float outlinePercent;

    void Start()
    {
        GenerateMap();
    }

    public void GenerateMap()
    {
        string holderName = "Generated Map";
        if(transform.FindChild(holderName))
        {
            DestroyImmediate(transform.FindChild(holderName).gameObject);
        }

        Transform mapHolder = new GameObject(holderName).transform;
        mapHolder.parent = transform;

        for(int x = 0; x < mapSize.x; x++)
        {
            for(int y = 0; y < mapSize.y; y++)
            {
                Vector3 tilePosition = new Vector3(-mapSize.x / 2 + 0.5f + x, 0, -mapSize.y / 2 + 0.5f + y);
                Transform newTile = Instantiate(tilePrefab, tilePosition, Quaternion.Euler(Vector3.right * 90)) as Transform;
                newTile.localScale = Vector3.one * (1 - outlinePercent);
                newTile.parent = mapHolder;
            }
        }

        Transform maskLeft = Instantiate(NavMeshMask, Vector3.left * (mapSize.x + MaxMapSize.x) / 4, Quaternion.identity) as Transform;
        maskLeft.parent = mapHolder;
        maskLeft.localScale = new Vector3((MaxMapSize.x - mapSize.x) / 2, 1, mapSize.y);

        Transform maskRight = Instantiate(NavMeshMask, Vector3.right * (mapSize.x + MaxMapSize.x) / 4, Quaternion.identity) as Transform;
        maskRight.parent = mapHolder;
        maskRight.localScale = new Vector3((MaxMapSize.x - mapSize.x) / 2, 1, mapSize.y);

        Transform maskTop = Instantiate(NavMeshMask, Vector3.forward * (mapSize.y + MaxMapSize.y) / 4, Quaternion.identity) as Transform;
        maskTop.parent = mapHolder;
        maskTop.localScale = new Vector3(MaxMapSize.x, 1, (MaxMapSize.y - mapSize.y)/2);

        Transform maskBottom= Instantiate(NavMeshMask, Vector3.back * (mapSize.y + MaxMapSize.y) / 4, Quaternion.identity) as Transform;
        maskBottom.parent = mapHolder;
        maskBottom.localScale = new Vector3(MaxMapSize.x, 1, (MaxMapSize.y - mapSize.y) / 2);

        NavMeshFloor.localScale = new Vector3(MaxMapSize.x, MaxMapSize.y);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    private const float PLAYER_SPAWN_LEVEL_PART = 200f;
    [SerializeField] private Transform Level_Start;
    [SerializeField] private List<Transform> Level_Part_List;

    [SerializeField] private GameObject player;

    private Vector3 lastEndPosition;

    private void Awake(){
        lastEndPosition = Level_Start.Find("EndPosition").position;

        int startingSpawnLevelPart = 5;
        for(int i = 0; i < startingSpawnLevelPart; ++i){
            SpawnLevelPart();
        }
    }

    private void Update(){
        if(Vector3.Distance(player.transform.position, lastEndPosition) < PLAYER_SPAWN_LEVEL_PART){
            SpawnLevelPart();
        }
    }

    private void SpawnLevelPart(){
        Transform chosenLevelPart = Level_Part_List[Random.Range(0, Level_Part_List.Count)];
        Transform lastLevelPartTransform = SpawnLevelPart(chosenLevelPart, lastEndPosition);
        lastEndPosition = lastLevelPartTransform.Find("EndPosition").position;
    }

    private Transform SpawnLevelPart(Transform levelPart, Vector3 spawnPosition){
        Transform levelPartTransform = Instantiate(levelPart, spawnPosition, Quaternion.identity);
        return levelPartTransform;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    private static LevelGenerator instance;

    private const float PLAYER_DISTANCE_SPAWN_LEVEL_PART = 200f;

    [SerializeField] private Transform levelpartStart;
    [SerializeField] private List<Transform> levelpartEasyList;
    [SerializeField] private List<Transform> levelpartMediumList;
    [SerializeField] private List<Transform> levelpartHardList;
    [SerializeField] private List<Transform> levelpartImpossibleList;
    [SerializeField] private PlayerController player;

    private enum Difficulty
    {
        Easy, Medium, Hard, Imposible
    }

    private Vector3 lastEndPosition;
    private int levelPartsSpawned;

    private void Awake()
    {
        instance = this;

        lastEndPosition = levelpartStart.Find("EndPosition").position;

        int startingSpawnLevelParts = 5;
        for (int i = 0; i < startingSpawnLevelParts; i++)
        {
            SpawnLevelPart();
        }
    }

    private void Update()
    {
        if (Vector3.Distance(player.GetPosition(), lastEndPosition) < PLAYER_DISTANCE_SPAWN_LEVEL_PART)
        {
            SpawnLevelPart();
        }
    }

    private void SpawnLevelPart()
    {
        List<Transform>difficultyLevelPartList;

        switch (GetDifficulty())
        {
            default:
            //Select Easy Level Part
            case Difficulty.Easy: difficultyLevelPartList = levelpartEasyList; break;
            //Select Medium Level Part
            case Difficulty.Medium: difficultyLevelPartList = levelpartMediumList; break;
            //Select Hard Level Part
            case Difficulty.Hard: difficultyLevelPartList = levelpartHardList; break;
            //Select Impossible Level Part
            case Difficulty.Imposible: difficultyLevelPartList = levelpartImpossibleList; break;
        }

        Transform chosenLevelPart = difficultyLevelPartList[Random.Range(0, difficultyLevelPartList.Count)];

        Transform lastLevelPartTransform = SpawnLevelPart(chosenLevelPart, lastEndPosition);
        lastEndPosition = lastLevelPartTransform.Find("EndPosition").position;
        levelPartsSpawned++;
    }

    private Transform SpawnLevelPart(Transform levelParts, Vector3 spawnPosition)
    {
        Transform levelpartTransform = Instantiate(levelParts, spawnPosition, Quaternion.identity); 
        return levelpartTransform;
    }

    private Difficulty GetDifficulty()
    {
        if (levelPartsSpawned >= 15) return Difficulty.Imposible;
        if (levelPartsSpawned >= 10) return Difficulty.Hard;
        if (levelPartsSpawned >= 5) return Difficulty.Medium;
        return Difficulty.Easy;
    }

    public static int GetlevelPartsSpawned()
    {
        return instance.levelPartsSpawned;
    }
}

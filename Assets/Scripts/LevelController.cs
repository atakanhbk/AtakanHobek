using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] private LevelData levelData;

    private static LevelController instance;
    private static GameObject currentLevel;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        LevelController.CreateOrNextLevel();
    }

    public static void CreateOrNextLevel()
    {
        if (currentLevel != null)
        {
            Destroy(currentLevel);
        }

         var spawnedLevel = Instantiate(instance.levelData.levelList[instance.levelData.levelNumber], Vector3.zero, Quaternion.identity);
         currentLevel = spawnedLevel; 
    }

    public void Restart()
    {
        Destroy(currentLevel);
        var spawnedLevel = Instantiate(instance.levelData.levelList[instance.levelData.levelNumber], Vector3.zero, Quaternion.identity);
        currentLevel = spawnedLevel;
    }
}
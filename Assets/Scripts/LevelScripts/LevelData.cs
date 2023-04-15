using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "NewLevelData", menuName = "Create New Level Data")]
public class LevelData : ScriptableObject
{
    public List<GameObject> levelList = new List<GameObject>();
    public GameObject gameOverScreen;
    public int levelNumber;
    public int totalCubeNumber;


    public void ResetData()
    {
        totalCubeNumber = 0;
    }
}

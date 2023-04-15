using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "NewPlayerData" , menuName = "Create New Player Data")]
public class PlayerData : ScriptableObject
{
    public int playerSpeed;
    public int playerTurnSpeed;
}

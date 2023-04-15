using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeCounter : MonoBehaviour
{
   
    [SerializeField] private LevelData levelData;
    [SerializeField] private ObjectColor objectColor;
    private Material objectMaterial;

    private void Start()
    { 
        levelData.totalCubeNumber++;
        objectMaterial = GetComponent<MeshRenderer>().material;
        Color pink = new Color(1,0,1);
        Color orange = new Color(1,0.5f,0);

        switch (objectColor)
        {
            case ObjectColor.Black: objectMaterial.color = Color.black;
                break;
            case ObjectColor.White: objectMaterial.color = Color.white;
                break;
            case ObjectColor.Red: objectMaterial.color = Color.red;
                break;
            case ObjectColor.Green: objectMaterial.color = Color.green;
                break;
            case ObjectColor.Blue: objectMaterial.color = Color.blue;
                break;
            case ObjectColor.Yellow: objectMaterial.color = Color.yellow;
                break;
            case ObjectColor.Cyan: objectMaterial.color = Color.cyan;
                break;
            case ObjectColor.Pink: objectMaterial.color = pink;
                break;
            case ObjectColor.Orange: objectMaterial.color = orange;
                break;
        }
    }

}

public enum ObjectColor
{
    Black,
    White,
    Red,
    Green,
    Blue,
    Yellow,
    Pink,
    Orange,
    Cyan
}







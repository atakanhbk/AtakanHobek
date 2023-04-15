using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EndPoint : MonoBehaviour
{

    [SerializeField] private LevelData levelData;
    [SerializeField] private EndPointData endPointData;

    float pullRadius, pullForce;

    int totalCollectedCubes = 0;
    int totalCubeNumber = 0;

    public GameObject killer;
    public Slider levelProgressionSlider;
    bool gameFinished;


    public GameObject levelProgression;

    private void Start()
    {
       GetNeededDatas();
    }

 
    void GetNeededDatas()
    {
        totalCubeNumber = levelData.totalCubeNumber;
        pullRadius = endPointData.pullRadius;
        pullForce = endPointData.pullForce;
    }

    private void OnTriggerStay(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "Cube":
                Rigidbody rb = other.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    Vector3 direction = transform.position - other.transform.position;
                    //direction.y = 0f; // Y ekseni çekmeyi engelle
                    float distance = direction.magnitude;

                    if (distance < pullRadius)
                    {
                        direction.Normalize();
                        float strength = (1f - distance / pullRadius) * pullForce;
                        rb.AddForce(direction * strength, ForceMode.Acceleration);
                    }
                }
                break;

            default:
                if (gameFinished && !other.gameObject.CompareTag("Untagged"))
                {
                    
                        other.gameObject.tag = "Cube";
                        SetFalseKinematic(other.gameObject);
                        
                }
                break;
        }

    }



    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, pullRadius); // Çekim alanýný göster
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Cube"))
        {
            IncraseLevelProgression();
            StartCoroutine(SetDisableCubesComponents(other.gameObject));
        }
    }


    IEnumerator SetDisableCubesComponents(GameObject otherObject)
    {
        SetCollectedCubesColor(otherObject,new Color(1,0.6f,0,1));
        otherObject.gameObject.layer = 7;
        yield return new WaitForSeconds(0.5f);
        otherObject.gameObject.tag = "CollectedCube";
        SetTrueKinematic(otherObject);
        CountCollectedCubes();
    }

    void SetTrueKinematic(GameObject otherObject)
    {
        otherObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
    }

    void SetFalseKinematic(GameObject otherObject)
    {
            otherObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;    
    }

    void CountCollectedCubes() {
        totalCollectedCubes++;

        if (totalCollectedCubes == totalCubeNumber)
        {
            GameFinishedFunction();
        }
    }

    void SetCollectedCubesColor(GameObject otherObject,Color color)
    {
        otherObject.GetComponent<MeshRenderer>().material.color = color;
    }

    void GameFinishedFunction()
    {
        gameFinished = true;
        killer.gameObject.AddComponent<KillCollectedCubes>();
        levelProgression.GetComponent<LevelProgression>().LevelCompleted();
  
    }

    void IncraseLevelProgression()
    {   
        levelProgressionSlider.value += (1.0f / totalCubeNumber);
    }

}

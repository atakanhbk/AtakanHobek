using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
public class LevelProgression : MonoBehaviour
{
    [SerializeField] private LevelData levelData;
    [SerializeField] private TMP_Text currentLevelText;
    [SerializeField] private TMP_Text nextLevelText;
    [SerializeField] private TMP_Text levelCompleted;
    [SerializeField] private ParticleSystem confetti;
    [SerializeField] private GameObject levelProgression;
     private GameObject gameOverScreen;
    float transitionTime = 1.0f;
    [SerializeField] private int levelNumber;

    private void Start()
    {
        SetTexts();
        levelData.ResetData();
    }
    void SetTexts()
    {
        currentLevelText.text = "" + (levelData.levelNumber + 1);
        nextLevelText.text = "" + (levelData.levelNumber + 2);
        levelCompleted.text = "LEVEL " + (levelData.levelNumber + 1) + " COMPLETED";
    }
    public void LevelCompleted()
    {

        var spawnedConfetti = Instantiate(confetti, new Vector3(0, 30, 30), Quaternion.identity);
        levelCompleted.gameObject.SetActive(true);
        levelProgression.gameObject.SetActive(false);
        StartCoroutine(OpenPanelAndCloseGame());
    }

   
    IEnumerator OpenPanelAndCloseGame()
    {
        var spawnedPanel = Instantiate(levelData.gameOverScreen, Vector3.zero, Quaternion.identity);
        gameOverScreen = spawnedPanel.transform.GetChild(0).gameObject;
        yield return new WaitForSeconds(2);
        gameOverScreen.gameObject.SetActive(true);
        Image panelImage = gameOverScreen.GetComponent<Image>();
        panelImage.color = new Color(0, 0, 0, 0);
        panelImage.DOFade(1.0f, transitionTime)
          .SetEase(Ease.InOutQuad);
        yield return new WaitForSeconds(2);
        NextLevel();
        panelImage.DOFade(0.0f, transitionTime)
            .SetEase(Ease.InOutQuad)
            .OnComplete(() => {
                Destroy(gameOverScreen.gameObject);
            });
    }
    void NextLevel()
    {
        levelData.levelNumber++;
        LevelController.CreateOrNextLevel();
    }

}

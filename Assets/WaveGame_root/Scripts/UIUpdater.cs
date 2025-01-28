using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIUpdater : MonoBehaviour
{
    [Header("GameStatusPanels")]
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] GameObject gameWinPanel;

    public TMP_Text pointsText;


    void Update()
    {
        PointsUpdater();
    }

    void PointsUpdater()
    {
        pointsText.text = "Points: " + GameManager.Instance.currentPoints.ToString();
    }

    void GameStatusChanger()
    {
        switch (GameManager.Instance.currentGameState)
        {
            case (GameManager.GameStatus.gameRunning):
                    break;

            case (GameManager.GameStatus.gameOver):
                gameOverPanel.SetActive(true);
                    break;
            case (GameManager.GameStatus.gamePaused):
                break;

        }    
    }
}

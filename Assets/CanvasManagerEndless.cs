using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManagerEndless : CanvasManager
{
    [SerializeField] protected GameObject GameOverScreen;

    public void GameOver()
    {
        GameUI.SetActive(false);
        GameUIBackground.SetActive(false);
        GameOverScreen.SetActive(true);
        Time.timeScale = 0f;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SMGameComplete : MonoBehaviour
{
    [SerializeField] private string gameProgression = "SMProgression";

    /// <summary>
    /// function to set SMProgression to 3, signaling the game is completed
    /// </summary>
    public void GameCompleted()
    {
        PlayerPrefs.SetInt(gameProgression, 3);
        Debug.Log("Secure.me Game Completed");
    }
}

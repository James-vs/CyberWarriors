using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndlessHighScore : MonoBehaviour
{
    [SerializeField] protected TextMeshProUGUI EndlessHighScoreText;
    [SerializeField] protected string endlessHighScoreString = "PBHighScoreLevelEndless";

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey(endlessHighScoreString)) EndlessHighScoreText.text = "" + PlayerPrefs.GetInt(endlessHighScoreString);
        Debug.Log("High Score: " + PlayerPrefs.GetInt(endlessHighScoreString));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

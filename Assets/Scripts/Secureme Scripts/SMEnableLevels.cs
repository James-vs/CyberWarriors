using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SMEnableLevels : MonoBehaviour
{
    [SerializeField] protected GameObject[] LevelUnlockList;
    [SerializeField] protected TextMeshProUGUI[] HighScoreTexts;
    [SerializeField] protected TextMeshProUGUI HighScoreLevel1;
    //[SerializeField] protected GameObject sessionController;
    [SerializeField] protected string pBDevMode = "SMDevMode";
    [SerializeField] protected string[] sMHighScoreStrings;
    [SerializeField] protected string sMTotalHighscore = "SMTotalHighscore";
    //[SerializeField] private string gameProgression = "SMProgression";
    [SerializeField] private string browserProgression = "SMBProgression";


    // Start is called before the first frame update
    void Start()
    {
        // Check if it is the first time player is playing the game
        if (!PlayerPrefs.HasKey(browserProgression))
        {
            PlayerPrefs.SetInt(browserProgression, 0);
        }

        // Display highscore for level 1 if it exists
        if (PlayerPrefs.HasKey(sMHighScoreStrings[0].ToString()))
        {
            string tempScore = PlayerPrefs.GetFloat(sMHighScoreStrings[0]).ToString("0");
            HighScoreLevel1.text = tempScore;
            //PlayerPrefs.SetInt(sMTotalHighscore, tempScore);
        }

        UnlockLevelButtons(PlayerPrefs.GetInt(browserProgression));

    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="value">number of LS buttons to enable</param>
    private void UnlockLevelButtons(int value)
    {
        for (int i = 1; i <= value; i++)
        {
            if (i > LevelUnlockList.Length) break;
            Debug.Log("Unlocked level " + i);
            // display highscore for completed levels past the tutorial
            var playerPrefsKey = sMHighScoreStrings[i];
            if (PlayerPrefs.HasKey(playerPrefsKey))
            {
                var levelScore = PlayerPrefs.GetFloat(playerPrefsKey).ToString("0");
                HighScoreTexts[i - 1].text = levelScore;
                //UpdateTotalHighscore(playerPrefsKey);
                //PlayerPrefs.SetInt(pBTotalHighscore, PlayerPrefs.GetInt(pBTotalHighscore) + levelScore);
            }

            var element = LevelUnlockList[i - 1];
            if (element.GetComponent<Button>() != null)
            {
                element.SetActive(true);
            }
            else
            {
                element.SetActive(false);
            }
        }

        //Debug.Log("Total Game score: " + PlayerPrefs.GetInt(pBTotalHighscore));
        //sessionController.GetComponent<SessionController>().UploadScore();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

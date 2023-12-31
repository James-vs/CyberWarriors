using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnableLevels : MonoBehaviour
{
    [SerializeField] protected GameObject[] LevelUnlockList;
    [SerializeField] protected TextMeshProUGUI[] HighScoreTexts;
    [SerializeField] protected TextMeshProUGUI HighScoreLevel1;
    [SerializeField] protected GameObject sessionController;
    [SerializeField] protected string pBProgress = "PBProgress";
    [SerializeField] protected string pBDevMode = "PBDevMode";
    [SerializeField] protected string pBHighScoreBase = "PBHighScoreLevel";
    [SerializeField] protected string pBTotalHighscore = "PBTotalHighscore";


    // Start is called before the first frame update
    void Start()
    {
        // Check if it is the first time player is playing the game
        if (!PlayerPrefs.HasKey(pBProgress))
        {
            PlayerPrefs.SetInt(pBProgress, 0);
        }

        // Display highscore for level 1 if it exists
        if (PlayerPrefs.HasKey(pBHighScoreBase + "1"))
        {
            int tempScore = PlayerPrefs.GetInt(pBHighScoreBase + "1");
            HighScoreLevel1.text = "" + tempScore;
            //PlayerPrefs.SetInt(pBTotalHighscore, tempScore);
        }
        
        // Display all levels if Developer mode is on
        if (PlayerPrefs.GetInt(pBDevMode) == 1)
        {
            UnlockLevelButtons(LevelUnlockList.Length);
        } 
        else
        {
            UnlockLevelButtons(PlayerPrefs.GetInt(pBProgress));
        }
        
    }

    /// <summary>
    /// function to enable level select buttons according to user progress or development mode status
    /// AND to display highscores of completed levels
    /// </summary>
    /// <param name="value">number of LS buttons to enable</param>
    private void UnlockLevelButtons(int value)
    {
        for (int i = 1; i <= value; i++)
        {
            if (i > LevelUnlockList.Length) break;
            Debug.Log("Unlocked level " + i);
            // display highscore for completed levels > 1
            var playerPrefsKey = pBHighScoreBase + "" + (i+1);
            if (PlayerPrefs.HasKey(playerPrefsKey))
            {
                var levelScore = PlayerPrefs.GetInt(playerPrefsKey);
                HighScoreTexts[i - 1].text = "" + levelScore;
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
        
        Debug.Log("Total Game score: " + PlayerPrefs.GetInt(pBTotalHighscore));
        //sessionController.GetComponent<SessionController>().UploadScore();
    }

    /// <summary>
    /// function to display high scores
    /// </summary>
    private void DisplayHighScores()
    {
        // for loop across the highscore text GOs, get playerprefs values from the base string and display them
        for (int i = 0; i < HighScoreTexts.Length; i++) 
        {
            
        }
    }


    // maybe will delete this function...
    /// <summary>
    /// function to update the total game highscore
    /// </summary>
    /// <param name="levelKey">single level key to add its value to the total</param>
    private void UpdateTotalHighscore(string levelKey)
    {
        if (PlayerPrefs.HasKey(pBTotalHighscore))
        {
            //sljdnajdgnd
        }
        else
        {
            PlayerPrefs.SetInt(pBTotalHighscore, PlayerPrefs.GetInt(levelKey));
        }
    }
}

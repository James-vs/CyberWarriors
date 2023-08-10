using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelEnd : MonoBehaviour
{
    [SerializeField] protected ScoreManager scoreManager;
    [SerializeField] protected CanvasManager canvasManager;
    [SerializeField] protected string normalModeComplete = "PBNormModeComplete";
    [SerializeField] protected bool resetNormalModeComplete = false;
    public float blockCount = 0f;
    public float totalBlocks = 0f;
    protected bool levelEnded = false;
    [SerializeField] protected string devModeString = "PBDevMode";
    [SerializeField] protected string pBProgress = "PBProgress";
    [SerializeField] protected string pBHighScoreBase = "PBHighScoreLevel";
    [SerializeField] protected int numberOfLevels = 11;

    // Start is called before the first frame update
    void Start() => Debug.Log("LevelEnd script start");
    

    //method called at the beginning of each frame
    void Update() {
        if (blockCount == totalBlocks && !levelEnded){
            EndLevel();
        }
    }


    /// <summary>
    /// function that calls canvasmanager to display level end screen
    /// </summary>
    public virtual void EndLevel() {
        Debug.Log("Level ended");
        canvasManager.LevelComplete();
        scoreManager.SetHighScore();
        levelEnded = true;
    }


    /// <summary>
    /// function to increase the blocks broken counter
    /// </summary>
    public virtual void IncreaseBlockCount() {
        this.blockCount += 1f;
        scoreManager.UpdateBricksBrokenScore(((int)blockCount));
    }


    /// <summary>
    /// function to reload the current scene
    /// </summary>
    public virtual void RestartLevel() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    

    /// <summary>
    /// function to open the settings scene from within a level
    /// </summary>
    public void OpenSettings() {
        PlayerPrefs.SetInt("ReturnToScene", SceneManager.GetActiveScene().buildIndex);
        Debug.Log("Return to scene " + SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene("PBSettings", LoadSceneMode.Single);
    }


    /// <summary>
    /// function to handle the first time settings is loaded
    /// </summary>
    public void FirstTimeSettings() => PlayerPrefs.SetInt("ReturnToScene", SceneManager.GetActiveScene().buildIndex+3);
    

    /// <summary>
    /// function to handle which game mode is selected
    /// </summary>
    /// <param name="choice">bool value representing the options</param>
    public void SelectNormalMode(bool choice)
    {
        if (choice) 
        {
            PlayerPrefs.SetInt("PBModeSelection", 1);
        } else
        {
            PlayerPrefs.SetInt("PBModeSelection", 0);
        }
    }


    /// <summary>
    /// function to handle initialising the game normal mode
    /// </summary>
    public void InitialiseNormalModeNoSQLValue()
    {
        //PlayerPrefs.DeleteKey(normalModeComplete); // for development purposes only
        if (resetNormalModeComplete)
        {
            PlayerPrefs.SetInt(normalModeComplete, 0);
            PlayerPrefs.SetInt(pBProgress, 0);
            for (int i = 0; i < numberOfLevels; i++)
            {
                PlayerPrefs.DeleteKey(pBHighScoreBase + "" + (i + 1));
                //Debug.Log("Player Prefs Keys for highscores: " + pBHighScoreBase + "" + (i + 1)); - for testing
            }
        }
        if (!PlayerPrefs.HasKey(normalModeComplete))
        {
            PlayerPrefs.SetInt(normalModeComplete, 0);
        }
    }
    

    /// <summary>
    /// function to handle when the normal mode is completed
    /// </summary>
    public void NormalModeComplete() => PlayerPrefs.SetInt(normalModeComplete, 1);
    

    /// <summary>
    /// function to handle developer mode
    /// </summary>
    /// <param name="val">bool true/on or false/off</param>
    public void DevModeOn(Toggle toggle)
    {
        if (toggle.isOn)
        {
            PlayerPrefs.SetInt(devModeString, 1);
            //Debug.Log("Dev Mode value changed to: " + PlayerPrefs.GetInt(devModeString));
        } 
        else
        {
            PlayerPrefs.SetInt(devModeString, 0);
            //Debug.Log("Dev Mode value changed to: " + PlayerPrefs.GetInt(devModeString));
        }
        
        Debug.Log("Dev Mode toggle changed to: " + PlayerPrefs.GetInt(devModeString));
    }
}

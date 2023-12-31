using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [Header("Score Values")]
    [SerializeField] protected int score = 0;
    protected int overallScore = 0;
    [SerializeField] protected int bricksBroken = 0;
    [SerializeField] protected int lives;
    [SerializeField] protected float difficulty;
    [SerializeField] protected int multiplier = 1;
    private bool newReset = true;
    public string difficultyKey = "PBDifficulty";
    [SerializeField] protected string pBHighScoreString = "PBHighScoreLevel1";
    [SerializeField] protected string pBTotalHighscore = "PBTotalHighscore";
    [SerializeField] protected GameObject sessionController;

    [Header("Game UI Text Objects")]
    [SerializeField] protected TextMeshProUGUI gameUIScoreText;
    [SerializeField] protected TextMeshProUGUI multiplierText;

    [Header("Pause Screen Text Objects")]
    [SerializeField] protected TextMeshProUGUI pauseScoreText;

    [Header("End Screen Text Objects")]
    [SerializeField] protected TextMeshProUGUI baseScoreText;
    [SerializeField] protected TextMeshProUGUI difficultyBonusText;
    [SerializeField] protected TextMeshProUGUI livesBonusText;
    [SerializeField] protected TextMeshProUGUI overallScoreText;
    protected int livesWeight;

    // Start is called before the first frame update
    void Start() => GetDifficulty();

    // Update is called once per frame
    void Update() => CalculateScore();

    /// <summary>
    /// function to calculate the score (int)
    /// </summary>
    protected virtual void CalculateScore() {
        GetLivesWeight();
        overallScore = GetBaseScore() + GetDifficultyWeight() + livesWeight;
        UpdateScoreText();
    }

    /// <summary>
    /// function to calculate the brickbroken weight
    /// </summary>
    /// <returns>bricksBroken weighting</returns>
    protected int GetBaseScore() {
        return score;
    }

    /// <summary>
    /// function to calculate the difficulty weight
    /// </summary>
    /// <returns>difficulty weighting</returns>
    protected int GetDifficultyWeight() {
        if (difficulty == 2) {
            return 1000;
        } else if (difficulty == 1) {
            return 500;
        } else {
            return 0;
        }
        
    }

    /// <summary>
    /// function that calculates a weight for number of lives left
    /// </summary>
    /// <returns>lives weighting</returns>
    protected void GetLivesWeight() {
        if (difficulty == 2 || (difficulty == 1 && lives == 2) || (difficulty == 0 && lives == 3)) {
            livesWeight = 1000;
        } else {
            livesWeight = 0;
        }
    }

    /// <summary>
    /// PUBLIC function that returns the current score value
    /// </summary>
    /// <returns>score value (int)</returns>
    public int GetScore() {
        return score;
    }

    /// <summary>
    /// function to update the value of difficulty
    /// </summary>
    protected void GetDifficulty() {
        difficulty = PlayerPrefs.GetFloat(difficultyKey);
    }

    /// <summary>
    /// function to update the bricksBroken variable
    /// </summary>
    /// <param name="value">number of broken bricks</param>
    public void UpdateBricksBrokenScore(int value) {
        if (bricksBroken < value && newReset != true) {
            multiplier += value - bricksBroken;
        } else {
            newReset = false;
            multiplierText.transform.parent.gameObject.SetActive(true);
        }
        score += (value - bricksBroken) * multiplier * 100;
        bricksBroken = value;
    }

    /// <summary>
    /// function to update the lives variable
    /// </summary>
    /// <param name="value">number of lives</param>
    public void UpdateLives(int value) {
        lives = value;
    }

    /// <summary>
    /// function to update the score in the pause menu 
    /// </summary>
    public virtual void UpdateScoreText () {
        pauseScoreText.text = "" + score;
        baseScoreText.text = "" + score;
        gameUIScoreText.text = "Score: " + score;
        multiplierText.text = "x" + multiplier;
        overallScoreText.text = "" + overallScore;
        
        
        difficultyBonusText.text = "" + GetDifficultyWeight();
        livesBonusText.text = "" + livesWeight;
    }

    /// <summary>
    /// function to reset the multiplier when the ball hits the paddle
    /// </summary>
    public void ResetMultiplier() {
        multiplier = 1;
        newReset = true;
        multiplierText.transform.parent.gameObject.SetActive(false);
    }

    /// <summary>
    /// function to return the overallScore variable
    /// </summary>
    /// <returns>overallScore (int)</returns>
    public int GetOverallScore()
    {
        return overallScore;
    }

    /// <summary>
    /// function to set the base score of a level (only used for i)
    /// </summary>
    /// <param name="baseScore"></param>
    public void SetBaseScore(int baseScore) 
    { 
        score = baseScore;
    }

    /// <summary>
    /// function to check for and set the highscore
    /// </summary>
    public virtual void SetHighScore()
    {
        if (PlayerPrefs.HasKey(pBHighScoreString))
        {
            var levelHighScore = PlayerPrefs.GetInt(pBHighScoreString);
            if (overallScore > levelHighScore)
            {
                var initialTHighscore = PlayerPrefs.GetInt(pBTotalHighscore);
                PlayerPrefs.SetInt(pBTotalHighscore, initialTHighscore + (overallScore - levelHighScore));
                PlayerPrefs.SetInt(pBHighScoreString, overallScore);
            }
        }
        else
        {
            PlayerPrefs.SetInt(pBTotalHighscore, PlayerPrefs.GetInt(pBTotalHighscore)+ overallScore);
            PlayerPrefs.SetInt(pBHighScoreString, overallScore);
        }
        sessionController.GetComponent<SessionController>().UploadScore();
    }
}

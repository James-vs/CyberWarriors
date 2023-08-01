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
        //Debug.Log("Score: " + score);
        UpdateScoreText();
    }

    /// <summary>
    /// function to calculate the brickbroken weight
    /// </summary>
    /// <returns>bricksBroken weighting</returns>
    protected int GetBaseScore() {
        //Debug.Log("Bricks weight: " + bricksBroken * 100);
        return score;
    }

    /// <summary>
    /// function to calculate the difficulty weight
    /// </summary>
    /// <returns>difficulty weighting</returns>
    protected int GetDifficultyWeight() {
        if (difficulty == 2) {
            //Debug.Log("Diff weight: " + 2000);
            return 1000;
        } else if (difficulty == 1) {
            //Debug.Log("Diff weight: " + 1000);
            return 500;
        } else {
            //Debug.Log("Diff weight: " + 0);
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
        //Debug.Log("Lives weight: " + livesWeight);
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
        //Debug.Log("PBDifficulty: " + PlayerPrefs.GetInt(difficultyKey));
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
}

using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] protected int score = 0;
    //[SerializeField] private static int OverallScore = 0;
    [SerializeField] protected int bricksBroken = 0;
    [SerializeField] protected int lives;
    [SerializeField] protected float difficulty;
    public string difficultyKey = "PBDifficulty";
    [SerializeField] protected TextMeshProUGUI scoreText;
    [SerializeField] protected TextMeshProUGUI difficultyBonusText;
    [SerializeField] protected TextMeshProUGUI livesBonusText;
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
        score = GetBricksWeight() + GetDifficultyWeight() + livesWeight;
        //Debug.Log("Score: " + score);
        UpdateScoreText();
    }

    /// <summary>
    /// function to calculate the brickbroken weight
    /// </summary>
    /// <returns>bricksBroken weighting</returns>
    protected int GetBricksWeight() {
        //Debug.Log("Bricks weight: " + bricksBroken * 100);
        return bricksBroken * 100;
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
    /// returns the current score value
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
    public void UpdateBricksBroken(int value) {
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
        scoreText.text = "Score: " + score;
        difficultyBonusText.text = "" + GetDifficultyWeight();
        livesBonusText.text = "" + livesWeight;
    }
}
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private int score = 0;
    //[SerializeField] private static int OverallScore = 0;
    [SerializeField] private int bricksBroken = 0;
    [SerializeField] private int lives;
    [SerializeField] private int difficulty;
    [SerializeField] private TextMeshProUGUI scoreText;
    public string difficultyKey = "PBDifficulty";

    private int livesWeight;

    // Start is called before the first frame update
    void Start() => GetDifficulty();

    // Update is called once per frame
    void Update() => CalculateScore();

    /// <summary>
    /// function to calculate the score (int)
    /// </summary>
    private void CalculateScore() {
        GetLivesWeight();
        score = GetBricksWeight() + GetDifficultyWeight() + livesWeight;
        Debug.Log("Score: " + score);
        UpdateScoreText();
    }

    /// <summary>
    /// function to calculate the brickbroken weight
    /// </summary>
    /// <returns>bricksBroken weighting</returns>
    private int GetBricksWeight() {
        //Debug.Log("Bricks weight: " + bricksBroken * 100);
        return bricksBroken * 100;
    }

    /// <summary>
    /// function to calculate the difficulty weight
    /// </summary>
    /// <returns>difficulty weighting</returns>
    private int GetDifficultyWeight() {
        GetDifficulty();
        //Debug.Log("Difficulty weight: " + difficulty * 1000);
        return difficulty * 1000;
    }

    /// <summary>
    /// function that calculates a weight for number of lives left
    /// </summary>
    /// <returns>lives weighting</returns>
    private void GetLivesWeight() {
        if (difficulty == 2 || (difficulty == 1 && lives == 2) || (difficulty == 0 && lives == 3)) {
            livesWeight = 3000;
        } else if ((difficulty == 1 && lives == 1) || (difficulty == 0 && lives == 2)) {
            livesWeight = 2000;
        } else {
            livesWeight = 1000;
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
    private void GetDifficulty() {
        difficulty = PlayerPrefs.GetInt(difficultyKey);
        Debug.Log("PBDifficulty: " + PlayerPrefs.GetInt(difficultyKey));
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
    public void UpdateScoreText () {
        scoreText.text = "Score: " + score;
    }
}

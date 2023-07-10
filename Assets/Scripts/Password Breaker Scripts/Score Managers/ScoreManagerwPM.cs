using UnityEngine;
using TMPro;

public class ScoreManagerwPM : ScoreManager
{
    [SerializeField] protected TextMeshProUGUI PMBonusText;
    protected int PMCount = 0;

    protected int PMBonus() {
        return PMCount * 1000;
    }
    
    /// <summary>
    /// function to calculate the score (int)
    /// </summary>
    protected override void CalculateScore() {
        GetLivesWeight();
        score = GetBricksWeight() + GetDifficultyWeight() + livesWeight + PMBonus();
        //Debug.Log("Score: " + score);
        UpdateScoreText();
    }

    /// <summary>
    /// function to update the score in the pause menu 
    /// </summary>
    public override void UpdateScoreText () {
        scoreText.text = "Score: " + score;
        difficultyBonusText.text = "" + GetDifficultyWeight();
        livesBonusText.text = "" + livesWeight;
        PMBonusText.text = "" + PMBonus();
    }


    /// <summary>
    /// function to update the PM destroyed count
    /// </summary>
    public void UpdatePMBonus() {
        PMCount += 1;
    }
}

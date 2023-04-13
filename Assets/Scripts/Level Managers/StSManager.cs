using UnityEngine;
using TMPro;

public class StSManager : MonoBehaviour
{
    //class to be inherited from for game level scripts

    [SerializeField] protected GameObject success;
    [SerializeField] protected GameObject fail;
    [SerializeField] protected LoadNextScene loadNextScene;
    [SerializeField] protected bool gameOver = false;
    protected int matches = 0;
    [SerializeField] protected TextMeshProUGUI matchesUI;
    [SerializeField] protected Timer timer;
    [SerializeField] protected bool outOfTime = false;
    

    //function to end the game if the timer runs out
    public void OutOfTime (bool value) {
        Debug.Log("OutOfTime called");
        gameOver = value;
        outOfTime = value;
    }

    //function to handle logic for matching and selecting of buttons
    public float Match(bool firstMatch, bool pair1, bool match1) {
        if (!firstMatch && !outOfTime) {
            if (!pair1 && !match1) {
                return 1; //if button selected
            } else {
                return 2; //if button deselected
            }
        }
        return 3; //do nothing
    }


    // #### FUNCTIONS TO HANDLE NoSQL DATABASE QUERIES

    // function to save the score + append the highscore
    protected void SaveScore(string scoreKey, string highScoreKey){
        float score = matches * (1000 + (timer.GetValue() * 10));
        PlayerPrefs.SetFloat(scoreKey,score);

        if (PlayerPrefs.GetFloat(highScoreKey) < score) {
            PlayerPrefs.SetFloat(highScoreKey,score);
        }
    }

    // function to check if a highscore PlayerPrefs key exists, creates one if not
    protected void CheckForHighscore(string highScoreKey) {
        if (!PlayerPrefs.HasKey(highScoreKey)) {
            PlayerPrefs.SetFloat(highScoreKey,0f);
        }
    }
}

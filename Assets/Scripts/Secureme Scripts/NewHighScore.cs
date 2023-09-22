using UnityEngine;

public class NewHighScore : MonoBehaviour
{
    [SerializeField] private GameObject newHighScore;
    [SerializeField] private string scoreKey;
    [SerializeField] private string highScoreKey;
    
    // Start is called before the first frame update
    void Start()
    {
        //display new highscore object if highscore == score
        newHighScore.SetActive(false);
        if (PlayerPrefs.GetFloat(scoreKey) == PlayerPrefs.GetFloat(highScoreKey)) {
            newHighScore.SetActive(true);
        }
    }
}

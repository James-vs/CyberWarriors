using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameResetter : MonoBehaviour
{
    [SerializeField] private int lives = 3;
    [SerializeField] private TextMeshProUGUI livesDisplay;
    [SerializeField] private TextMeshProUGUI pauseLivesDisplay;
    [SerializeField] private string difficultyKey = "PBDifficulty";
    [SerializeField] private ScoreManager scoreManager;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("GameResetter script start");
        lives = GetLifeSettings();
        this.livesDisplay.text = "" + lives;
        pauseLivesDisplay.text = this.livesDisplay.text;
    }

    private void Update() {
        scoreManager.UpdateLives(this.lives);
    }

    public void OnCollisionEnter2D(Collision2D other) {
        float ballsLeft = gameObject.GetComponent<BallManager>().ballCount;
        if (other.gameObject.CompareTag("Ball") && ballsLeft == 1 && lives < 2) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        } else if (other.gameObject.CompareTag("Ball") && ballsLeft == 1 && lives > 1) {
           Debug.Log("Detected life lost");
           LifeLost(gameObject.GetComponent<BallManager>()); 
           gameObject.GetComponent<BallManager>().DecreaseBallCount();
           Destroy(other.gameObject);

        } else {
            // livesLost is in the wrong place in this if statement!!!!
            gameObject.GetComponent<BallManager>().DecreaseBallCount();
            Destroy(other.gameObject);
        }
    }


    // functions to handle gaining or losing a life
    public void LifeLost(BallManager manager) {
        manager.SpawnBall();
        this.lives -= 1;
        this.livesDisplay.text = "" + lives;
        pauseLivesDisplay.text = this.livesDisplay.text;
        scoreManager.UpdateLives(lives);
    }
    public void LifeGained() {
        // for use later in development
        this.lives += 1;
        this.livesDisplay.text = "" + lives;
        pauseLivesDisplay.text = this.livesDisplay.text;
        scoreManager.UpdateLives(lives);
    }

    // function to get the difficulty setting value
    private int GetLifeSettings() {
        if (PlayerPrefs.GetFloat(difficultyKey) == 0) {
            return 3;
        } else if (PlayerPrefs.GetFloat(difficultyKey) == 1) {
            return 2;
        } else if (PlayerPrefs.GetFloat(difficultyKey) == 2){
            return 1;
        } else {
            // error case - easy difficulty default
            return 3;
        }
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEnd : MonoBehaviour
{
    [SerializeField] protected ScoreManager scoreManager;
    [SerializeField] protected CanvasManager canvasManager;
    public float blockCount = 0f;
    public float totalBlocks = 0f;
    protected bool levelEnded = false;
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("LevelEnd script start");
    }

    //method called at the beginning of each frame
    void Update() {
        if (blockCount == totalBlocks && !levelEnded){
            EndLevel();
        }
    }

    public virtual void EndLevel() {
        Debug.Log("Level ended");
        canvasManager.LevelComplete();
        levelEnded = true;
    }

    public virtual void IncreaseBlockCount() {
        this.blockCount += 1f;
        scoreManager.UpdateBricksBrokenScore(((int)blockCount));
    }

    public virtual void RestartLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OpenSettings() {
        PlayerPrefs.SetInt("ReturnToScene", SceneManager.GetActiveScene().buildIndex);
        Debug.Log("Return to scene " + SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene(24);
    }

    public void FirstTimeSettings() {
        PlayerPrefs.SetInt("ReturnToScene", SceneManager.GetActiveScene().buildIndex+3);
    }

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
    
}

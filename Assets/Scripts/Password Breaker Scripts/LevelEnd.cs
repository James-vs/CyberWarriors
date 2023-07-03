using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEnd : MonoBehaviour
{
    
    public float blockCount = 0f;
    public float totalBlocks = 0f;
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("LevelEnd script start");
    }

    //method called at the beginning of each frame
    void Update() {
        if (blockCount == totalBlocks){
            EndLevel();
        }
    }

    public void EndLevel() {
        Debug.Log("Level ended");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void IncreaseBlockCount() {
        this.blockCount += 1f;
    }

    public void RestartLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OpenSettings() {
        PlayerPrefs.SetInt("ReturnToScene", SceneManager.GetActiveScene().buildIndex);
        Debug.Log("Return to scene " + SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene(23);
    }

    public void FirstTimeSettings() {
        PlayerPrefs.SetInt("ReturnToScene", SceneManager.GetActiveScene().buildIndex+2);
    }
    
}

using System.Collections;
using System.Collections.Generic;
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
    
}

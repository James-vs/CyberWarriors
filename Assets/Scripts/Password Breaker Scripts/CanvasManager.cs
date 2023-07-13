using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasManager : MonoBehaviour
{
    [Header("Pause Menu UI Objects")]
    [SerializeField] protected GameObject GameUI;
    [SerializeField] protected GameObject PauseUI;
    [SerializeField] protected GameObject EndScreen;
    protected bool IsPaused = false;

    // Start is called before the first frame update
    void Start()
    {
        // if ReturnToScene == buildIndex of current scene, then pause menu must've been used
        if (PlayerPrefs.GetInt("ReturnToScene") == SceneManager.GetActiveScene().buildIndex) {
            Pause();
            Debug.Log("ReturnToScene = " + PlayerPrefs.GetInt("ReturnToScene"));
            PlayerPrefs.SetInt("ReturnToScene", 100);
        } else {
            Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (IsPaused) {
                Play();
            } else {
                Pause();
            }
        }
    }

    /// <summary>
    /// functions to pause the level and display pause menu
    /// </summary>
    public void Pause() {
        GameUI.SetActive(false);
        PauseUI.SetActive(true);
        Time.timeScale = 0f;
    }

    /// <summary>
    /// function to resume gameplay
    /// </summary>
    public void Play() {
        GameUI.SetActive(true);
        PauseUI.SetActive(false);
        Time.timeScale = 1f;
    }

    /// <summary>
    /// function to return the time to normal when home is selected
    /// </summary>
    public void Home() {
        Time.timeScale = 1f;
    }

    /// <summary>
    /// function to restart the level
    /// </summary>
    public void Retry() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    /// <summary>
    /// function to start the next scene
    /// </summary>
    public void NextScene() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    /// <summary>
    /// function to display the level complete screen
    /// </summary>
    public void LevelComplete() {
        GameUI.SetActive(false);
        PauseUI.SetActive(false);
        EndScreen.SetActive(true);
        Time.timeScale = 0f;
    }
}

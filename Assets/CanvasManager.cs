using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasManager : MonoBehaviour
{
    [Header("Pause Menu UI Objects")]
    [SerializeField] private GameObject GameUI;
    [SerializeField] private GameObject PauseUI;
    private bool IsPaused = false;

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

    //functions to pause & play the level
    public void Pause() {
        GameUI.SetActive(false);
        PauseUI.SetActive(true);
        Time.timeScale = 0f;
    }
    public void Play() {
        GameUI.SetActive(true);
        PauseUI.SetActive(false);
        Time.timeScale = 1f;
    }

    // function to return the time to normal when home is selected
    public void Home() {
        Time.timeScale = 1f;
    }
}

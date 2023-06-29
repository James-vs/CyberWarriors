using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameSettingsManager : MonoBehaviour
{
    [Header("Slider")]
    [SerializeField] private Slider slider;
    [SerializeField] private float sliderValue = 0f;
    [SerializeField] private string difficultyKey = "PBDifficulty";
    [Header("Close Settings Button")]
    [SerializeField] private Button doneBtn;
    [Header("UI Aesthetics")]
    [SerializeField] private GameObject normalImage;
    [SerializeField] private GameObject hardImage;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("GameSettingsManager script started");
        //called to keep settings value continuety
        if (!PlayerPrefs.HasKey(difficultyKey)) PlayerPrefs.SetFloat(difficultyKey,0);
        slider.value = PlayerPrefs.GetFloat(difficultyKey);
        ChangeDifficulty();
    }

    // function to change the scene once the player has chosen their settings
    public void SettingsChosen() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


    // function to change the difficulty setting in the NoSQL database
    public void ChangeDifficulty() {
        sliderValue = slider.value;
        if (sliderValue == 1) {
            PlayerPrefs.SetFloat(difficultyKey, sliderValue);
            Debug.Log("Hard difficulty chosen: " + PlayerPrefs.GetFloat(difficultyKey));
            NormalAesthetics(false);
        } else if (sliderValue == 0) {
            PlayerPrefs.SetFloat(difficultyKey, sliderValue);
            Debug.Log("Normal difficulty chosen: " + PlayerPrefs.GetFloat(difficultyKey));
            NormalAesthetics(true);
        } else {
            Debug.Log("Error: Difficulty settings value not in expected range");
        }
    }

    // function to handle aesthetic changes in the setting screen
    private void NormalAesthetics(bool norm) {
        hardImage.SetActive(!norm);
        normalImage.SetActive(norm);   
    }
}

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class GameSettingsManager : MonoBehaviour
{
    [Header("Slider")]
    [SerializeField] private Slider slider;
    [SerializeField] private float sliderValue = 0f;
    [SerializeField] private string difficultyKey = "PBDifficulty";
    [Header("Close Settings Button")]
    [SerializeField] private TextMeshProUGUI doneText;
    private int scene;
    
    [Header("UI Aesthetics")]
    [SerializeField] private GameObject easyImage;
    [SerializeField] private GameObject normalImage;
    [SerializeField] private GameObject hardImage;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("GameSettingsManager script started");
        //handle NoSQL database variable initialisation
        if (!PlayerPrefs.HasKey(difficultyKey)) PlayerPrefs.SetFloat(difficultyKey,0);
        if (!PlayerPrefs.HasKey("ReturnToScene")) PlayerPrefs.SetInt("ReturnToScene", SceneManager.GetActiveScene().buildIndex + 1);
        scene = PlayerPrefs.GetInt("ReturnToScene");
        //called to keep settings value continuety
        slider.value = PlayerPrefs.GetFloat(difficultyKey);
        ChangeDifficulty();
        CheckTargetScene();
    }

    private void CheckTargetScene() {
        if (scene > SceneManager.GetActiveScene().buildIndex + 1) {
            doneText.text = "Back";
        }
    }

    // function to change the scene once the player has chosen their settings
    public void SettingsChosen() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


    // function to change the difficulty setting in the NoSQL database
    public void ChangeDifficulty() {
        sliderValue = slider.value;
        if (sliderValue == 2) {
            PlayerPrefs.SetFloat(difficultyKey, sliderValue);
            Debug.Log("Hard difficulty chosen: " + PlayerPrefs.GetFloat(difficultyKey));
            HardAesthetics();
        } else if (sliderValue == 1) {
            PlayerPrefs.SetFloat(difficultyKey, sliderValue);
            Debug.Log("Normal difficulty chosen: " + PlayerPrefs.GetFloat(difficultyKey));
            NormalAesthetics();
        } else if (sliderValue == 0) {
            PlayerPrefs.SetFloat(difficultyKey, sliderValue);
            Debug.Log("Easy difficulty chosen: " + PlayerPrefs.GetFloat(difficultyKey));
            EasyAesthetics();
        } else {
            Debug.Log("Error: Difficulty settings value not in expected range");
        }
    }

    // functions to handle aesthetic changes in the setting screen
    private void EasyAesthetics() {
        hardImage.SetActive(false);
        normalImage.SetActive(false);
        easyImage.SetActive(true);   
    }
    private void NormalAesthetics() {
        hardImage.SetActive(false);
        normalImage.SetActive(true);
        easyImage.SetActive(false);   
    }
    private void HardAesthetics() {
        hardImage.SetActive(true);
        normalImage.SetActive(false);
        easyImage.SetActive(false);   
    }

    public void ReturnToScene() {
        Debug.Log("Return back to scene: " + scene);
        SceneManager.LoadScene(scene);
    }
}

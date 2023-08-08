using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitGame : MonoBehaviour
{
    public void Quit() {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void Home(){
        Debug.Log("Home");
        SceneManager.LoadScene("PBWelcome", LoadSceneMode.Single);
    }

    public void GameSelect() {
        Debug.Log("Game Select Scene");
        SceneManager.LoadScene("GameSelect", LoadSceneMode.Single);
    }

    public void ModeSelect()
    {
        Debug.Log("Mode Select Scene");
        SceneManager.LoadScene("PBModeSelect", LoadSceneMode.Single);
    }

    public void LevelSelect()
    {
        SceneManager.LoadScene("PBLevelSelect", LoadSceneMode.Single);
    }
}

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
        SceneManager.LoadScene(22);
    }

    public void GameSelect() {
        Debug.Log("Game Select Scene");
        SceneManager.LoadScene(0);
    }

    public void ModeSelect()
    {
        Debug.Log("Mode Select Scene");
        SceneManager.LoadScene(23);
    }
}

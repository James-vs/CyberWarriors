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
}

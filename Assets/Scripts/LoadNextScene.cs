using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextScene : MonoBehaviour
{
    //function to change the game to a different scene
    public void ChangeScene(int increase) {
        if (increase > 0 ) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + increase);
        } else if (increase == 0) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        } else {
            if ((SceneManager.GetActiveScene().buildIndex + increase) < 0) {
                SceneManager.LoadScene(0);
            } else {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + increase);
            }
        }
    }

    public void ChangeScene(string sceneName) 
    {
        Debug.Log("Name of scene: " + sceneName);
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }
}

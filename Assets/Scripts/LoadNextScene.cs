using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextScene : MonoBehaviour
{
    //function to change the game to a different scene
    public void ChangeScene(int increase) {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + increase);
    }

}

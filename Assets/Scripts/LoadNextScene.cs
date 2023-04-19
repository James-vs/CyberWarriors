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
            //Debug.Log("Error, negative number given as arg");
            if ((SceneManager.GetActiveScene().buildIndex + increase) < 0) {
                SceneManager.LoadScene(0);
            } else {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + increase);
            }
        }
    }
}

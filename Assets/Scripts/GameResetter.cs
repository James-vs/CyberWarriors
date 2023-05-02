using UnityEngine;
using UnityEngine.SceneManagement;

public class GameResetter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("GameResetter script start");
    }

    public void OnCollisionEnter2D(Collision2D other) {
        float ballsLeft = gameObject.GetComponent<BallManager>().ballCount;
        if (other.gameObject.CompareTag("Ball") && ballsLeft == 1) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        } else {
            gameObject.GetComponent<BallManager>().DecreaseBallCount();
            Destroy(other.gameObject);
            return;
        }
    }
}

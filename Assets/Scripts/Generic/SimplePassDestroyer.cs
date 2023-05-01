using UnityEngine;

public class SimplePassDestroyer : MonoBehaviour
{
    //reference to the ball's script
    public BallInitialiser ball;
    public GameObject eventSystem;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("SimplePassDestoryer script start");
        eventSystem = GameObject.Find("EventSystem");
        
    }

    //method to Destroy the brick if a ball collides with it
    public void OnCollisionEnter2D(Collision2D other) {
        if (!other.gameObject.CompareTag("Ball")) return;
        eventSystem.GetComponent<LevelEnd>().IncreaseBlockCount();
        Destroy(gameObject);
        //other.gameObject.GetComponent<BallInitialiser>().IncreaseSpeed();
    }

    //method to generate random number 0<=x<10
    int GetRandomFloat() {
        return Random.Range(0, 10);
    }

}

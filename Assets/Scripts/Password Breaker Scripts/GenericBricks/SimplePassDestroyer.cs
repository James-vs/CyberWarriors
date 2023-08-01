using UnityEngine;

public class SimplePassDestroyer : MonoBehaviour
{
    //reference to the ball's script
    //public BallInitialiser ball;
    protected GameObject eventSystem;

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
    }
}

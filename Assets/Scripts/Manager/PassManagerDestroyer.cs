using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassManagerDestroyer : MonoBehaviour
{
    // variable to count collisions for stronger brick types
    private float collisionCount = 5f;
    // variables to spawn in new bricks
    public GameObject simplePass;
    public GameObject mediumPass;
    public GameObject strongPass;

    public GameObject ball;
    public GameObject eventSystem;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("PassManagerDestroyer script start");
        eventSystem = GameObject.Find("EventSystem");
    }

    //method to Destroy the brick if a ball collides with it twice
    public void OnCollisionEnter2D(Collision2D other) {
        if (!other.gameObject.CompareTag("Ball")) return;
        SpriteRenderer manager = this.GetComponent<SpriteRenderer>();
        if (collisionCount >= 5f) {
            collisionCount -= 1f;
            manager.color = new Color32(0,130,255,210);
        } else if (collisionCount >= 4f) {
            collisionCount -= 1f;
            manager.color = new Color32(0,130,255,175);
        } else if (collisionCount >= 3f) {
            collisionCount -= 1f;
            manager.color = new Color32(0,130,255,140);
        } else if (collisionCount >= 2f) {
            collisionCount -= 1f;
            manager.color = new Color32(0,130,255,110);
        } else if (collisionCount >= 1f) {
            collisionCount -= 1f;
            manager.color = new Color32(0,130,255,80);
        } else {
            Destroy(gameObject);
            GameObject ballManager = GameObject.Find("BottomWall");
            Instantiate(ball, new Vector3(transform.position.x - 1.5f, transform.position.y, transform.position.z), transform.rotation);
            ballManager.GetComponent<BallManager>().IncreaseBallCount();
            Instantiate(ball, new Vector3(transform.position.x + 1.5f, transform.position.y, transform.position.z), transform.rotation);
            ballManager.GetComponent<BallManager>().IncreaseBallCount();
            Instantiate(ball, new Vector3(transform.position.x, transform.position.y - 1.25f, transform.position.z), transform.rotation);
            ballManager.GetComponent<BallManager>().IncreaseBallCount();
            Instantiate(ball, new Vector3(transform.position.x, transform.position.y + 1.25f, transform.position.z), transform.rotation);
            ballManager.GetComponent<BallManager>().IncreaseBallCount();
            Instantiate(ball, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);
            ballManager.GetComponent<BallManager>().IncreaseBallCount();
            var paddle = GameObject.Find("Paddle");
            paddle.transform.localScale = new Vector3(9f,0.3f,1f);
            eventSystem.GetComponent<LevelEnd>().IncreaseBlockCount();
        }
    }
}

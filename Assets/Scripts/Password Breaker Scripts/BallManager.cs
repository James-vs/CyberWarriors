using UnityEngine;

public class BallManager : MonoBehaviour
{
    [Header("Ball Count Tracking")]
    public float ballCount = 1f;
    
    [Header("Ball Spawning")]
    [SerializeField] private GameObject ball;
    [SerializeField] private float xPosition = 0f;
    [SerializeField] private float yPosition = -2.5f;



    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("BallManager script start");
    }

    public void DecreaseBallCount() {
        this.ballCount -= 1f;
    }

    public void IncreaseBallCount() {
        this.ballCount += 1f;
    }

    public void SpawnBall() {
        Instantiate(ball, new Vector3(xPosition,yPosition,0), ball.transform.rotation);
        ballCount += 1f;
    }
}

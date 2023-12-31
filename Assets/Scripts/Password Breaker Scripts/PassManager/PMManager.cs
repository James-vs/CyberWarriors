using UnityEngine;

public class PMManager : MonoBehaviour
{
    // variable to count collisions for stronger brick types
    private float collisionCount = 5f;
    [SerializeField] private GameObject eventSystem;
    [SerializeField] private GameObject radialTimer;
    [SerializeField] private GameObject ball;
    public GameObject firewallShield;
    public bool shielded = false;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("PassManagerDestroyer script start");
        eventSystem = GameObject.Find("EventSystem");
        radialTimer = GameObject.Find("Radial");
        //ball = GameObject.FindGameObjectWithTag("Ball");
        radialTimer.GetComponent<PMRadialTimer>().SetPassManager(this);
    }


    /// <summary>
    /// function to handle collisions w the ball, spawning the shield, damaging the PM and initiating the BreakPM() function
    /// </summary>
    /// <param name="other">the other detected Collision2D object</param>
    public void OnCollisionEnter2D(Collision2D other) {
        if (!other.gameObject.CompareTag("Ball")) return;
        if (!shielded) {
            SpriteRenderer manager = this.GetComponent<SpriteRenderer>();
            if (collisionCount >= 5f) {
                OnHitDetected(manager, 210);
            } else if (collisionCount >= 4f) {
                OnHitDetected(manager, 175);
            } else if (collisionCount >= 3f) {
                OnHitDetected(manager, 140);
            } else if (collisionCount >= 2f) {
                OnHitDetected(manager, 110);
            } else if (collisionCount >= 1f) {
                OnHitDetected(manager, 80);
            } else {
                BreakPM();
            }
        }
    }

    /// <summary>
    /// function to set the value of shielded
    /// </summary>
    /// <param name="value">shielded variable set to this value</param>
    public void SetShield(bool value) {
        // only run this code when the shielded value is to be changed
        if (value != shielded) {
            shielded = value;
            // if shielded == false, shrink the firewall shield
            if (shielded == false) firewallShield.GetComponent<GrowShield>().originalSize();
            Debug.Log("Shielded value changed: " + shielded);
        }
        
    }

    /// <summary>
    /// function to handle spawning ball, destroying this game object and widening the paddle
    /// </summary>
    private void BreakPM() {
        Destroy(gameObject);

        // add PM Bonus to score
        eventSystem.GetComponent<ScoreManagerwPM>().UpdatePMBonus();

        // spawn more balls and increase the level ball count
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

        // find and scale the paddle game object
        var paddle = GameObject.Find("Paddle");
        paddle.transform.localScale = new Vector3(6f, 0.3f, 1f);

    }


    /// <summary>
    /// function to handle damage procedure
    /// </summary>
    /// <param name="renderer">SpriteRenderer component of this PM</param>
    /// <param name="value">Opacity value</param>
    private void OnHitDetected(SpriteRenderer renderer, byte value) {
        // decrease the collisionCount variable
        collisionCount -= 1f;
        // change PM opacity
        renderer.color = new Color32(0,130,255,value);
        // start shield growth
        firewallShield.GetComponent<GrowShield>().grow();
        // start the timer
        radialTimer.GetComponent<PMRadialTimer>().StartPMRadialTimer();
    }
}

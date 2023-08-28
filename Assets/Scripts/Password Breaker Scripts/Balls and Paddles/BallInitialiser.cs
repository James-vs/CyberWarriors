using UnityEngine;

public class BallInitialiser : MonoBehaviour
{

    protected Rigidbody2D rb;
    [Header("Max Speed")]
    [SerializeField] protected float speed = 7f;

    [Header("Initial Trajectory")]
    // variables for testing ball-wall ricochet angle 
    [SerializeField] protected bool randomTrajectory = true;
    [SerializeField] protected float xTrajectory = 1f;
    [SerializeField] protected float yTrajectory = 0f;
    
    [Header("Settings Handling")]
    [SerializeField] protected string difficultyKey = "PBDifficulty";

    //Get the physics component of the ball
    protected void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("BallInitialiser script start");
        //handle settings
        ApplySettings();

        if (randomTrajectory)
        {
            Invoke(nameof(SetRandomTrajectory), 1.5f);
        }
        else
        {
            Invoke(nameof(SetSpecificTrajectory), 1.5f);
        }
    }

    // function to generate random starting trajectory for the ball
    protected void SetRandomTrajectory () {
        Vector2 force = Vector2.zero;
        force.x = Random.Range(-0.5f,0.5f);
        force.y = -1f;

        rb.AddForce(force.normalized * speed * 50); 
        // constant 50 found to achieve optimal ball velocity
    }

    // function to generate random starting trajectory for the ball
    public void SetRandomTrajectory(float xForce, float yForce)
    {
        
        Vector2 force = Vector2.zero;
        force.x = xForce;
        force.y = yForce;

        rb.AddForce(force.normalized * speed * 50);
        // constant 50 found to achieve optimal ball velocity
    }

    // used for testing ball-wall ricochet angle 
    protected void SetSpecificTrajectory () {
        Vector2 force = Vector2.zero;
        force.x = xTrajectory;
        force.y = yTrajectory;

        rb.AddForce(force.normalized * speed * 50);
        // constant 50 found to achieve optimal ball velocity
    }

    // function to increase the speed of the ball 
    public void IncreaseSpeed() {
        speed += 1f;
    }

    // using FixedUpdate to maintain constant ball speed
    protected void FixedUpdate() => CheckSpeed();

    // check the velocity of the ball is constant, adjust it otherwise
    protected void CheckSpeed() {
        // keep the velocity magnitude approx. the original speed of the ball
        if (rb.velocity.magnitude > speed + 0.5f) {
            // clamp the velocity magnitude under the max speed
            rb.velocity = Vector2.ClampMagnitude(vector: rb.velocity, speed);
        } else if (rb.velocity.magnitude < speed - 0.5f) {
            // normalise the velocity magnitude to 1 to set the speed
            rb.velocity = rb.velocity.normalized * speed;
        }
    }

    /// <summary>
    /// function to apply difficulty adjustments
    /// </summary>
    protected void ApplySettings() {
        // only affects speed of the ball 
        if (PlayerPrefs.GetFloat(difficultyKey) == 0) {
            return;
        } else if (PlayerPrefs.GetFloat(difficultyKey) == 1) {
            speed += 1;
        } else if (PlayerPrefs.GetFloat(difficultyKey) == 2) {
            speed += 2;
        }
    }

    /// <summary>
    /// function to handle perpendicular collisions in all directions 
    /// </summary>
    /// <param name="other">other object's collider</param>
    protected void OnCollisionEnter2D(Collision2D other) {
        float rightRicochet = Vector2.SignedAngle(Vector2.right, rb.velocity);
        float leftRicochet = Vector2.SignedAngle(Vector2.left, rb.velocity);
        float upRicochet = Vector2.SignedAngle(Vector2.up, rb.velocity);
        float downRicochet = Vector2.SignedAngle(Vector2.down, rb.velocity);
        if (rightRicochet < 1f && rightRicochet > -1f) {
            Debug.Log("Left collision detected");
            float newAngle = Mathf.Clamp(rightRicochet, -90f, -3f);
            Quaternion rotation = Quaternion.AngleAxis(newAngle, Vector3.forward);
            rb.velocity = rotation * Vector2.right * rb.velocity.magnitude;
        } else if (leftRicochet < 1f && leftRicochet > -1f) {
            Debug.Log("Right collision detected");
            float newAngle = Mathf.Clamp(leftRicochet, 3f, 90f);
            Quaternion rotation = Quaternion.AngleAxis(newAngle, Vector3.forward);
            rb.velocity = rotation * Vector2.left * rb.velocity.magnitude;
        } else if (upRicochet < 1f && upRicochet > -1f) {
            Debug.Log("Up collision detected");
            float newAngle = Mathf.Clamp(upRicochet, 3f, 90f);
            Quaternion rotation = Quaternion.AngleAxis(newAngle, Vector3.forward);
            rb.velocity = rotation * Vector2.up * rb.velocity.magnitude;
        } else if (downRicochet < 1f && downRicochet > -1f) {
            Debug.Log("down collision detected");
            float newAngle = Mathf.Clamp(downRicochet, 3f, 90f);
            Quaternion rotation = Quaternion.AngleAxis(newAngle, Vector3.forward);
            rb.velocity = rotation * Vector2.down * rb.velocity.magnitude;
        }
    }
}

using UnityEngine;

public class BallInitialiser : MonoBehaviour
{

    private Rigidbody2D rb {get; set;}
    [Header("Max Speed")]
    [SerializeField] private float speed = 7f;

    
    [Header("Initial Trajectory")]
    // variables for testing ball-wall ricochet angle 
    [SerializeField] private bool randomTrajectory = true;
    [SerializeField] private float xTrajectory = 1f;
    [SerializeField] private float yTrajectory = 0f;
    

    //Get the physics component of the ball
    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("BallInitialiser script start");
        
        if (randomTrajectory) {
            Invoke(nameof(SetRandomTrajectory), 1.5f);
        } else {
            Invoke(nameof(SetSpecificTrajectory), 1.5f);
        }
    }

    // function to generate random starting trajectory for the ball
    private void SetRandomTrajectory () {
        Vector2 force = Vector2.zero;
        force.x = Random.Range(-0.5f,0.5f);
        force.y = -1f;

        rb.AddForce(force.normalized * speed * 50); 
        // constant 50 found to achieve optimal ball velocity
    }

    // used for testing ball-wall ricochet angle 
    private void SetSpecificTrajectory () {
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

    public float GetSpeed() {
        return speed;
    }

    // using FixedUpdate to maintain constant ball speed
    private void FixedUpdate() {
        // keep the velocity magnitude approx. the original speed of the ball
        Debug.Log(rb.velocity.magnitude);
        
    }
}

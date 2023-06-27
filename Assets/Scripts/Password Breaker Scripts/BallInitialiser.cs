using UnityEngine;

public class BallInitialiser : MonoBehaviour
{

    private Rigidbody2D rb {get; set;}
    public float speed = 100f;

    //Get the physics component of the ball
    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("BallInitialiser script start");

        Invoke(nameof(SetRandomTrajectory), 1.5f);
    }

    // Update is called once per frame
    private void SetRandomTrajectory () {
        Vector2 force = Vector2.zero;
        force.x = Random.Range(-0.5f,0.5f);
        force.y = -1f;

        rb.AddForce(force.normalized * speed);
    }

    public void IncreaseSpeed() {
        speed += 10f;
    }
}

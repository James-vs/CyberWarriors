using UnityEngine;

public class PaddleController : MonoBehaviour
{
    //reference to this objects rigidbody component
    private Rigidbody2D rb;
    private Vector2 direction;
    public float speed = 30f;
    private float maxBounceAngle = 75f;
    private GameObject eventSystem;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("PaddleController script start");
        rb = GetComponent<Rigidbody2D>();
        eventSystem = GameObject.Find("EventSystem");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) {
            direction = Vector2.left;
        } else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) {
            direction = Vector2.right;
        } else {
           direction = Vector2.zero;
        }
    }

    //method to handle physics
    void FixedUpdate () {
        if (direction == Vector2.zero) {
            return;
        }
        rb.AddForce(direction * speed);
    }

    //method to handle ball riquochet math
    private void OnCollisionEnter2D(Collision2D other) {
        if (!other.gameObject.CompareTag("Ball")) return;
        eventSystem.GetComponent<ScoreManager>().ResetMultiplier();
        Vector3 paddlePosition = transform.position;
        Vector2 contactPoint = other.GetContact(0).point;

        // get the offset and width components of the collision
        float offset = paddlePosition.x - contactPoint.x;
        float width = other.otherCollider.bounds.size.x / 2;

        // use offset and width to calculate a new angle
        float currentAngle = Vector2.SignedAngle(Vector2.up, other.rigidbody.velocity);
        float bounceAngle = (offset / width) * maxBounceAngle;
        float newAngle = Mathf.Clamp(currentAngle + bounceAngle, -maxBounceAngle, maxBounceAngle);

        // use the angle to calculate the new rotation of the ball and resultant velocity
        Quaternion rotation = Quaternion.AngleAxis(newAngle, Vector3.forward);
        other.rigidbody.velocity = rotation * Vector2.up * other.rigidbody.velocity.magnitude;
        
    }
}

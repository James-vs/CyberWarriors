using UnityEngine;

public class BallRicochet : MonoBehaviour
{
    [SerializeField] private bool isLeftWall = false;

    // function to prevent perfect 90 degree ricochets off walls
    private void OnCollisionEnter2D(Collision2D other) {
        // clamp the angle s.t. ball always deflected down if collides perpendicular with walls
        //Debug.Log("Wall collision detected");
        switch (isLeftWall)
        {
            case true:
                float ricochetAngle = Vector2.SignedAngle(Vector2.right, other.rigidbody.velocity);
                //Debug.Log(ricochetAngle);
                if (ricochetAngle < 1f && ricochetAngle > -1f) {
                    //Debug.Log("90 degree collision");
                    float newAngle = Mathf.Clamp(ricochetAngle, -90f, -3f);
                    Quaternion rotation = Quaternion.AngleAxis(newAngle, Vector3.forward);
                    other.rigidbody.velocity = rotation * Vector2.right * other.rigidbody.velocity.magnitude;
                }
                break;
            
            case false:
                ricochetAngle = Vector2.SignedAngle(Vector2.left, other.rigidbody.velocity);
                //Debug.Log(ricochetAngle);
                if (ricochetAngle < 1f && ricochetAngle > -1f) {
                    //Debug.Log("90 degree collision");
                    float newAngle = Mathf.Clamp(ricochetAngle, 3f, 90f);
                    Quaternion rotation = Quaternion.AngleAxis(newAngle, Vector3.forward);
                    other.rigidbody.velocity = rotation * Vector2.left * other.rigidbody.velocity.magnitude;
                }
                break;
        }
    }
}

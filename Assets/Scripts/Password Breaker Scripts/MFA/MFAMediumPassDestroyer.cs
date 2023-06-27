using UnityEngine;

public class MFAMediumPassDestroyer : MonoBehaviour
{
    // variable to count collisions for stronger brick types
    public float collisionCount = 1f;
    // variable to spawn a new medium brick
    public GameObject go;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("MFAMediumPassDestroyer script start");
    }

    //method to Destroy the brick if a ball collides with it twice
    public void OnCollisionEnter2D(Collision2D other) {
        if (!other.gameObject.CompareTag("Ball")) return;
        if (collisionCount == 0) {
            Destroy(gameObject);
            Instantiate(go, transform.position, transform.rotation);
        } else {
            collisionCount -= 1f;
            SpriteRenderer brick = this.GetComponent<SpriteRenderer>();
            brick.color = new Color32(140, 121, 0, 255);
        }
    }
}

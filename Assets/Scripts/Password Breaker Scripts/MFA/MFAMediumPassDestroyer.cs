using UnityEngine;

public class MFAMediumPassDestroyer : MFABrick
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("MFAMediumPassDestroyer script start");
        collisionCount = 1f;
    }

    //method to Destroy the brick after a ball collides with it twice
    private void OnCollisionExit2D(Collision2D other) {
        if (!other.gameObject.CompareTag("Ball")) return;
        if (collisionCount == 0) {
            Destroy(gameObject);
            Instantiate(go, transform.position, transform.rotation);
        } else {
            var tmpCount = collisionCount;
            collisionCount = tmpCount - 1f;
            SpriteRenderer brick = this.GetComponent<SpriteRenderer>();
            brick.color = new Color32(140, 121, 0, 255);
        }
    }
}

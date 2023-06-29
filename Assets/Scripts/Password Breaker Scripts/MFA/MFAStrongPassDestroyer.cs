using UnityEngine;

public class MFAStrongPassDestroyer : MFABrick
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("MFAStrongPassDestroyer script start");
        collisionCount = 2f;
    }

    //method to Destroy the brick after a ball collides with it 3 times
    private void OnCollisionExit2D(Collision2D other) {
        if (!other.gameObject.CompareTag("Ball")) return;
        SpriteRenderer brick = this.GetComponent<SpriteRenderer>();
        if (collisionCount == 2) {
            var tmpCount = collisionCount;
            collisionCount = tmpCount - 1f;
            brick.color = new Color32(40, 180, 0, 255);
        } else if (collisionCount == 1){
            var tmpCount = collisionCount;
            collisionCount = tmpCount - 1f;
            brick.color = new Color32(40, 180, 0, 100);
        } else {
            Destroy(gameObject);
            Instantiate(go, transform.position, transform.rotation);
        }
    }
}

using UnityEngine;

public class StrongPassDestroyer : MonoBehaviour
{
    // variable to count collisions for stronger brick types
    protected float collisionCount = 2f;
    protected GameObject eventSystem;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("StrongPassDestroyer script start");
        eventSystem = GameObject.Find("EventSystem");
    }

    //method to Destroy the brick if a ball collides with it twice
    public void OnCollisionEnter2D(Collision2D other) {
        if (!other.gameObject.CompareTag("Ball")) return;
        SpriteRenderer brick = this.GetComponent<SpriteRenderer>();
        if (collisionCount == 2) {
            collisionCount -= 1f;
            brick.color = new Color32(40, 180, 0, 255);
        } else if (collisionCount == 1){
            collisionCount -= 1f;
            brick.color = new Color32(40, 180, 0, 100);
        } else {
            eventSystem.GetComponent<LevelEnd>().IncreaseBlockCount();
            Destroy(gameObject);
        }
    }
}

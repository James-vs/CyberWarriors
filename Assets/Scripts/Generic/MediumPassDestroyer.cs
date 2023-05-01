using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediumPassDestroyer : SimplePassDestroyer
{
    // variable to count collisions for stronger brick types
    public float collisionCount = 1f;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("MediumPassDestroyer script start");
        eventSystem = GameObject.Find("EventSystem");

    }

    //method to Destroy the brick if a ball collides with it twice
    public new void OnCollisionEnter2D(Collision2D other) {
        if (!other.gameObject.CompareTag("Ball")) return;
        if (collisionCount == 0) {
            eventSystem.GetComponent<LevelEnd>().IncreaseBlockCount();
            Destroy(gameObject);
        } else {
            collisionCount -= 1f;
            SpriteRenderer brick = this.GetComponent<SpriteRenderer>();
            brick.color = new Color32(140, 121, 0, 255);
        }
    }
}

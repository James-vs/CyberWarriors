using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MFAStrongPassDestroyer : MonoBehaviour
{
    // variable to count collisions for stronger brick types
    private float collisionCount = 2f;
    // variable to spawn in a new brick
    public GameObject go;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("MFAStrongPassDestroyer script start");
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
            Destroy(gameObject);
            Instantiate(go, transform.position, transform.rotation);
        }
    }
}

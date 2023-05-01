using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComplexPassManagerDestroyer : MonoBehaviour
{
    // variable to count collisions for stronger brick types
    private float collisionCount = 5f;
    // variables to spawn in new bricks
    public GameObject simplePass;
    public GameObject mediumPass;
    public GameObject strongPass;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("PassManagerDestroyer script start");
    }

    //method to Destroy the brick if a ball collides with it twice
    public void OnCollisionEnter2D(Collision2D other) {
        if (!other.gameObject.CompareTag("Ball")) return;
        SpriteRenderer manager = this.GetComponent<SpriteRenderer>();
        if (collisionCount >= 7f) {
            collisionCount -= 1f;
            manager.color = new Color32(0,130,255,210);
        } else if (collisionCount >= 6f) {
            collisionCount -= 1f;
            manager.color = new Color32(0,130,255,190);
        } else if (collisionCount >= 5f) {
            collisionCount -= 1f;
            manager.color = new Color32(0,130,255,170);
        } else if (collisionCount >= 4f) {
            collisionCount -= 1f;
            manager.color = new Color32(0,130,255,150);
        } else if (collisionCount >= 3f) {
            collisionCount -= 1f;
            manager.color = new Color32(0,130,255,130);
        } else if (collisionCount >= 2f) {
            collisionCount -= 1f;
            manager.color = new Color32(0,130,255,110);
        } else if (collisionCount >= 1f) {
            collisionCount -= 1f;
            manager.color = new Color32(0,130,255,80);
        } else {
            Destroy(gameObject);
            Instantiate(strongPass, new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z), transform.rotation);
            Instantiate(strongPass, new Vector3(transform.position.x + 2f, transform.position.y, transform.position.z), transform.rotation);
            Instantiate(strongPass, new Vector3(transform.position.x - 2f, transform.position.y, transform.position.z), transform.rotation);
            Instantiate(mediumPass, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);
            Instantiate(mediumPass, new Vector3(transform.position.x - 2f, transform.position.y + 1f, transform.position.z), transform.rotation);
            Instantiate(mediumPass, new Vector3(transform.position.x + 2f, transform.position.y + 1f, transform.position.z), transform.rotation);
            Instantiate(mediumPass, new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z), transform.rotation);
            Instantiate(simplePass, new Vector3(transform.position.x + 2f, transform.position.y - 1f, transform.position.z), transform.rotation);
            Instantiate(simplePass, new Vector3(transform.position.x - 2f, transform.position.y - 1f, transform.position.z), transform.rotation);
        }
        other.gameObject.GetComponent<BallInitialiser>().IncreaseSpeed();
    }
}

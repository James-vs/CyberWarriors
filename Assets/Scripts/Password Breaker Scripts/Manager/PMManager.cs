using UnityEngine;

public class PMManager : MonoBehaviour
{
    // variable to count collisions for stronger brick types
    private float collisionCount = 5f;
    [SerializeField] private GameObject eventSystem;
    [SerializeField] private GameObject radialTimer;
    public GameObject firewallShield;
    public bool shielded = false;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("PassManagerDestroyer script start");
        eventSystem = GameObject.Find("EventSystem");
        firewallShield.SetActive(false);
    }

    private void Update() {
        if (shielded) {
            firewallShield.SetActive(true);
        } else {
            firewallShield.SetActive(false);
        }
    }


    //method to Destroy the brick if a ball collides with it twice
    public void OnCollisionEnter2D(Collision2D other) {
        if (!other.gameObject.CompareTag("Ball")) return;
        if (!shielded) {
            firewallShield.SetActive(false);
            SpriteRenderer manager = this.GetComponent<SpriteRenderer>();
            if (collisionCount >= 5f) {
                collisionCount -= 1f;
                manager.color = new Color32(0,130,255,210);
                radialTimer.GetComponent<PMRadialTimer>().StartPMRadialTimer();
            } else if (collisionCount >= 4f) {
                collisionCount -= 1f;
                manager.color = new Color32(0,130,255,175);
                radialTimer.GetComponent<PMRadialTimer>().StartPMRadialTimer();
            } else if (collisionCount >= 3f) {
                collisionCount -= 1f;
                manager.color = new Color32(0,130,255,140);
                radialTimer.GetComponent<PMRadialTimer>().StartPMRadialTimer();
            } else if (collisionCount >= 2f) {
                collisionCount -= 1f;
                manager.color = new Color32(0,130,255,110);
                radialTimer.GetComponent<PMRadialTimer>().StartPMRadialTimer();
            } else if (collisionCount >= 1f) {
                collisionCount -= 1f;
                manager.color = new Color32(0,130,255,80);
                radialTimer.GetComponent<PMRadialTimer>().StartPMRadialTimer();
            } else {
                Destroy(gameObject);
                eventSystem.GetComponent<LevelEnd>().IncreaseBlockCount();
            }
        }
    }

    public void SetShield(bool value) {
        shielded = value;
        Debug.Log("Shielded: " + shielded);
    }
}

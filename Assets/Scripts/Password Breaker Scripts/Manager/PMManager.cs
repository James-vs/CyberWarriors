using UnityEngine;

public class PMManager : MonoBehaviour
{
    // variable to count collisions for stronger brick types
    private float collisionCount = 5f;
    [SerializeField] private GameObject eventSystem;
    [SerializeField] private GameObject radialTimer;
    public GameObject ball;
    public GameObject firewallShield;
    public bool shielded = false;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("PassManagerDestroyer script start");
        eventSystem = GameObject.Find("EventSystem");
        //firewallShield.SetActive(false);
    }

    private void Update() {
        /*if (shielded) {
            firewallShield.SetActive(true);
        } else {
            firewallShield.SetActive(false);
        }*/
    }


    //method to Destroy the brick if a ball collides with it twice
    public void OnCollisionEnter2D(Collision2D other) {
        if (!other.gameObject.CompareTag("Ball")) return;
        if (!shielded) {
            //firewallShield.SetActive(false);
            SpriteRenderer manager = this.GetComponent<SpriteRenderer>();
            if (collisionCount >= 5f) {
                collisionCount -= 1f;
                manager.color = new Color32(0,130,255,210);
                firewallShield.GetComponent<GrowShield>().grow();
                radialTimer.GetComponent<PMRadialTimer>().StartPMRadialTimer();
            } else if (collisionCount >= 4f) {
                collisionCount -= 1f;
                manager.color = new Color32(0,130,255,175);
                firewallShield.GetComponent<GrowShield>().grow();
                radialTimer.GetComponent<PMRadialTimer>().StartPMRadialTimer();
            } else if (collisionCount >= 3f) {
                collisionCount -= 1f;
                manager.color = new Color32(0,130,255,140);
                firewallShield.GetComponent<GrowShield>().grow();
                radialTimer.GetComponent<PMRadialTimer>().StartPMRadialTimer();
            } else if (collisionCount >= 2f) {
                collisionCount -= 1f;
                manager.color = new Color32(0,130,255,110);
                firewallShield.GetComponent<GrowShield>().grow();
                radialTimer.GetComponent<PMRadialTimer>().StartPMRadialTimer();
            } else if (collisionCount >= 1f) {
                collisionCount -= 1f;
                manager.color = new Color32(0,130,255,80);
                firewallShield.GetComponent<GrowShield>().grow();
                radialTimer.GetComponent<PMRadialTimer>().StartPMRadialTimer();
            } else {
                Destroy(gameObject);
                GameObject ballManager = GameObject.Find("BottomWall");
                Instantiate(ball, new Vector3(transform.position.x - 1.5f, transform.position.y, transform.position.z), transform.rotation);
                ballManager.GetComponent<BallManager>().IncreaseBallCount();
                Instantiate(ball, new Vector3(transform.position.x + 1.5f, transform.position.y, transform.position.z), transform.rotation);
                ballManager.GetComponent<BallManager>().IncreaseBallCount();
                Instantiate(ball, new Vector3(transform.position.x, transform.position.y - 1.25f, transform.position.z), transform.rotation);
                ballManager.GetComponent<BallManager>().IncreaseBallCount();
                Instantiate(ball, new Vector3(transform.position.x, transform.position.y + 1.25f, transform.position.z), transform.rotation);
                ballManager.GetComponent<BallManager>().IncreaseBallCount();
                Instantiate(ball, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);
                ballManager.GetComponent<BallManager>().IncreaseBallCount();
                var paddle = GameObject.Find("Paddle");
                paddle.transform.localScale = new Vector3(9f,0.3f,1f);
                eventSystem.GetComponent<LevelEnd>().IncreaseBlockCount();
            }
        }
    }

    public void SetShield(bool value) {
        if (value != shielded) {
            shielded = value;
            if (shielded == false) firewallShield.GetComponent<GrowShield>().originalSize();
            Debug.Log("Shielded value changed: " + shielded);
        }
        
    }
}

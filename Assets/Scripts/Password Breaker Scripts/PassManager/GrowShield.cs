using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class GrowShield : MonoBehaviour {
 
    //Public variables
    //When triggering shrink() GameObject will scale down to [shrunkScale] over [time]
    //public Vector3 shrunkScale;
    //When triggering grow() GameObject will scale up to [grownScale] over [time]
    public Vector3 grownScale;
    //Growth/shriuking time (MILLISECONDS)
    public float time;
    //Private variables
    private bool active = false;
    private Vector3 originalScale;
    //private bool shrinking;
    private float timePassed = 0.0f;
    private float progress;
    public enum State { ORIGINAL_SIZE, GROWN }
    private State state = State.ORIGINAL_SIZE;
    private enum Actions { NORMALIZING, GROWING }
    private Actions action = Actions.NORMALIZING;
 
    // Use this for initialization
    void Start ()
    {
        originalScale = transform.localScale;
        Debug.Log(originalScale);
    }
 
    private void FixedUpdate()
    {
        if (active)
        {
            timePassed += Time.deltaTime * 1000.0f;
            //0 - 1 with time
            progress = (timePassed / time);
        }
        switch (action) {
            case Actions.NORMALIZING:
                switch (state) {
                    case State.GROWN:
                        transform.localScale = new Vector3(
                            (1 - progress) * grownScale.x + progress * originalScale.x,
                            (1 - progress) * grownScale.y + progress * originalScale.y,
                            (1 - progress) * grownScale.z + progress * originalScale.z
                        );
                        break;
                    default:
                        break;
                }
                break;
            case Actions.GROWING:
                switch (state)
                {
                    case State.ORIGINAL_SIZE:
                        transform.localScale = new Vector3(
                            (1 - progress) * originalScale.x + progress * grownScale.x,
                            (1 - progress) * originalScale.y + progress * grownScale.y,
                            (1 - progress) * originalScale.z + progress * grownScale.z
                        );
                        break;
                    default:
                        break;
                }
                break;
        }
        if (progress >= 1)
        {
            active = false;
            
            switch (action) {
                case Actions.GROWING:
                    state = State.GROWN;
                    break;
                case Actions.NORMALIZING:
                    state = State.ORIGINAL_SIZE;
                    gameObject.SetActive(false);
                    break;
            }
        }
    }
 
    public void grow()
    {
        // if grow called while normalising, do not use SetActive since GO already active
        if (action == Actions.NORMALIZING) {
            active = false;
            state = State.ORIGINAL_SIZE;
            transform.localScale = originalScale;
            active = true;
            action = Actions.GROWING;
            timePassed = 0.0f;
        }
        Debug.Log("grow");
        gameObject.SetActive(true);
        active = true;
        action = Actions.GROWING;
        timePassed = 0.0f;
    }

    public void originalSize()
    {
        Debug.Log("normalizing");
        active = true;
        action = Actions.NORMALIZING;
        timePassed = 0.0f;
    }
}

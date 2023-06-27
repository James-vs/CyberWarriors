using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    public float ballCount = 1f;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("BallManager script start");
    }

    // Update is called once per frame
    void Update()
    {
        //uft
    }

    public void DecreaseBallCount() {
        this.ballCount -= 1f;
    }

    public void IncreaseBallCount() {
        this.ballCount += 1f;
    }
}

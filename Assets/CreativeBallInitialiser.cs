using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreativeBallInitialiser : BallInitialiser
{
    [SerializeField] protected bool startLevel = false;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("CreativeBallInitialiser script start");
        //handle settings
        ApplySettings();
    }

    // Update is called once per frame
    void Update()
    {
        //if (startLevel) StartMovement();
    }

    /// <summary>
    /// function to start ball movement
    /// </summary>
    protected void StartMovement()
    {
        if (randomTrajectory)
        {
            Invoke(nameof(SetRandomTrajectory), 1.5f);
        }
        else
        {
            Invoke(nameof(SetSpecificTrajectory), 1.5f);
        }
    }

    /// <summary>
    /// public function to start the level
    /// </summary>
    public void StartLevel()
    {
        if (startLevel) StartMovement();
    }

    public void AllBricksCreated()
    {
        startLevel = true;
    }
}

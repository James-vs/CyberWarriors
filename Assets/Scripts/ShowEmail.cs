using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowEmail : MonoBehaviour
{
    [SerializeField] private GameObject dfault;
    [SerializeField] private GameObject email;
    [SerializeField] private bool showing = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // function to show the email gameobject
    public void OnClick() {
        if (showing) {
            email.SetActive(false);
            dfault.SetActive(true);
            showing = false;
        } else {
            email.SetActive(true);
            dfault.SetActive(false);
            showing = true;
        }
    }
}

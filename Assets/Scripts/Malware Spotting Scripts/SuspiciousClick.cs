using UnityEngine;

public class SuspiciousClick : MonoBehaviour
{
    [SerializeField] private GameObject susZone;

    // function to handle clicks on suspicious elements
    public void SusClick() {
        
        susZone.SetActive(true); 
        
    }
}

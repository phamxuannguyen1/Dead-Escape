using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    public GameObject _ammoBox;
    public GameObject _ammoDisplay;
    private void OnTriggerEnter(Collider other)
    {
       _ammoBox.SetActive(false);
       _ammoDisplay.SetActive(true);
        GlobalAmmo._ammoCout += 7;
    }
}

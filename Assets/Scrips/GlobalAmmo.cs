using TMPro;
using UnityEngine;

public class GlobalAmmo : MonoBehaviour
{
    public static int _ammoCout = 0;       
    public static int _currentMagazine = 7; 
    public static int _maxMagazine = 7;

    [SerializeField] private TMP_Text _ammoDisplay;

    void Update()
    {
        if (_ammoDisplay != null)
        {
            _ammoDisplay.text = _currentMagazine + "/" + _ammoCout;
        }
    }
}
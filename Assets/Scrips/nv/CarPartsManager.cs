using UnityEngine;
using TMPro;

public class CarPartsManager : MonoBehaviour
{
    [SerializeField] private int _totalParts = 7;
    [SerializeField] private TMP_Text _missionText;

    private int _currentParts;

    void Start()
    {
        UpdateUI();
    }

    public void AddPart()
    {
        _currentParts++;

        UpdateUI();

        if (_currentParts >= _totalParts)
        {
            _missionText.text = "Mission: Go to the car and escape!";
        }
    }

    void UpdateUI()
    {
        _missionText.text = "Repair Car: " + _currentParts + " / " + _totalParts;
    }

    public bool IsCarRepaired()
    {
        return _currentParts >= _totalParts;
    }
}
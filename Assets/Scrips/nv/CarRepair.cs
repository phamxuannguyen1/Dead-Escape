using UnityEngine;

public class CarRepair : MonoBehaviour
{
    [SerializeField] private CarPartsManager _partsManager;
    [SerializeField] private GameObject _repairText;

    private bool _playerNear;

    void Update()
    {
        if (_playerNear && PlayerCarry._isCarrying)
        {
            _repairText.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                Repair();
            }
        }
        else
        {
            _repairText.SetActive(false);
        }
    }

    void Repair()
    {
        Destroy(PlayerCarry._currentItem);

        PlayerCarry.DropItem();

        _partsManager.AddPart();

        _repairText.SetActive(false);

        if (_partsManager.IsCarRepaired())
        {
            Debug.Log("Car fully repaired");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _playerNear = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _playerNear = false;
            _repairText.SetActive(false);
        }
    }
} 
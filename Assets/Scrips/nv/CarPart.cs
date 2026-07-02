using UnityEngine;

public class CarPart : MonoBehaviour
{
    [SerializeField] private GameObject _pickupText;

    private bool _playerNear;

    void Update()
    {
        if (_playerNear && Input.GetKeyDown(KeyCode.E) && !PlayerCarry._isCarrying)
        {
            PlayerCarry.PickItem(gameObject);

            transform.SetParent(Camera.main.transform);
            transform.localPosition = new Vector3(-0.45f, -0.3f, 0.8f);

            _pickupText.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _playerNear = true;

            if (!PlayerCarry._isCarrying)
            {
                _pickupText.SetActive(true);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _playerNear = false;
            _pickupText.SetActive(false);
        }
    }
} 
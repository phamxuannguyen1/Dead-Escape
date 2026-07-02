using UnityEngine;
using System.Collections;
using TMPro;

public class CarEscapeRepair : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private CarPartsManager _partsManager;
    [SerializeField] private GameObject _player;
    [SerializeField] private Camera _playerCamera;
    [SerializeField] private Camera _carCamera;

    [Header("UI")]
    [SerializeField] private TMP_Text _messageText;
    [SerializeField] private GameObject _messagePanel;

    [Header("Controllers")]
    [SerializeField] private MonoBehaviour _playerController;
    [SerializeField] private MonoBehaviour _carController;

    private bool _playerNear;
    private bool _repairing;

    void Start()
    {
        if (_carCamera != null)
            _carCamera.enabled = false;

        if (_carController != null)
            _carController.enabled = false;

        if (_messagePanel != null)
            _messagePanel.SetActive(false);

        if (_messageText != null)
            _messageText.text = "";
    }

    void Update()
    {
        if (_playerNear && !_repairing && _partsManager.IsCarRepaired())
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                StartCoroutine(RepairCar());
            }
        }
    }

    IEnumerator RepairCar()
    {
        _repairing = true;

        ShowMessage("Repairing Car...");

        if (_playerController != null)
            _playerController.enabled = false;

        if (_carController != null)
            _carController.enabled = false;

        yield return new WaitForSeconds(10f);

        StartEscape();
    }

    void StartEscape()
    {
        ShowMessage("ESCAPING...");

        if (_playerCamera != null)
            _playerCamera.enabled = false;

        if (_carCamera != null)
            _carCamera.enabled = true;

        if (_carController != null)
            _carController.enabled = true;

        StartCoroutine(CarDrive());
    }

    IEnumerator CarDrive()
    {
        float timer = 0f;

        while (timer < 6f)
        {
            transform.Translate(Vector3.forward * 10f * Time.deltaTime);
            timer += Time.deltaTime;
            yield return null;
        }

        ShowMessage("YOU ESCAPED!");
    }

    void ShowMessage(string message)
    {
        if (_messagePanel != null)
            _messagePanel.SetActive(true);

        if (_messageText != null)
            _messageText.text = message;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            _playerNear = true;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            _playerNear = false;
    }
}
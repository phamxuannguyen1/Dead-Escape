using UnityEngine;

public class CarMissionTrigger : MonoBehaviour
{
    [SerializeField] private GameObject _missionUI;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _missionUI.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _missionUI.SetActive(false);
        }
    }
}
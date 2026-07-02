using UnityEngine;
using UnityEngine.SceneManagement;

public class WInTrigger : MonoBehaviour
{
    [SerializeField] private CarPartsManager _partsManager;
    [SerializeField] private GameObject _player;
    [SerializeField] private MonoBehaviour _carController;

    private bool _won = false;

    private void OnTriggerEnter(Collider other)
    {
        if (_won) return;

        if (other.CompareTag("win"))
        {
            if (_partsManager != null && _partsManager.IsCarRepaired())
            {
                StartCoroutine(WinGame());
            }
        }
    }

    System.Collections.IEnumerator WinGame()
    {
        _won = true;

        Debug.Log("YOU WIN!");

        // Tắt player
        if (_player != null)
            _player.SetActive(false);

        // Tắt điều khiển xe
        if (_carController != null)
            _carController.enabled = false;

        yield return new WaitForSeconds(2f);

        SceneManager.LoadScene(3); // scene WIN
    }
}
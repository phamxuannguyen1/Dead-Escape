using UnityEngine;
using UnityEngine.SceneManagement;

public class CarEscape : MonoBehaviour
{
    [SerializeField] private CarPartsManager _partsManager;
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _car;

    private bool _playerNear;
    private bool _isEscaping;
    void Update()
    {
        if (_playerNear && !_isEscaping && _partsManager.IsCarRepaired())
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                StartCoroutine(Escape());
            }
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
        }
    }

    System.Collections.IEnumerator Escape()
    {
        _isEscaping = true;

        _player.SetActive(false);

        float timer = 0;

        while (timer < 5f)
        {
            _car.transform.Translate(Vector3.forward * 10 * Time.deltaTime);
            timer += Time.deltaTime;
            yield return null;
        }

        yield return new WaitForSeconds(2f);

        SceneManager.LoadScene(3);
    }

}
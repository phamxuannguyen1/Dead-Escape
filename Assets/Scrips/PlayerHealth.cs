using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerHealth : MonoBehaviour
{
    [Header("Health Settings")]
    [SerializeField] private int _maxHealth = 100;

    [Header("UI")]
    [SerializeField] private Slider _healthBar;

    [Header("Effects")]
    [SerializeField] private GameObject _bloodScreen;

    [SerializeField] private GameObject _playerRoot; 
    [SerializeField] private MonoBehaviour[] _playerScripts; 
    private int _currentHealth;
    private bool _isDead;

    void Start()
    {
        _currentHealth = _maxHealth;

        if (_healthBar != null)
        {
            _healthBar.maxValue = _maxHealth;
            _healthBar.value = _currentHealth;
        }
    }

    public void TakeDamage(int damage)
    {
        if (_isDead) return;

        _currentHealth -= damage;

        if (_healthBar != null)
        {
            _healthBar.value = _currentHealth;
        }

        ShowBlood();

        if (_currentHealth <= 0)
        {
            Die();
        }
    }

    void ShowBlood()
    {
        if (_bloodScreen != null)
        {
            _bloodScreen.SetActive(true);
            Invoke(nameof(HideBlood), 1.0f);
        }
    }

    void HideBlood()
    {
        _bloodScreen.SetActive(false);
    }

    void Die()
    {
        _isDead = true;

        foreach (MonoBehaviour script in _playerScripts)
        {
            script.enabled = false;
        }

        Collider col = GetComponent<Collider>();
        if (col != null)
            col.enabled = false;

        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
            rb.linearVelocity = Vector3.zero;

        if (_playerRoot != null)
            _playerRoot.SetActive(false);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        Invoke(nameof(Gameover), 2f);
    }

    void Gameover()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(2);
    }
}
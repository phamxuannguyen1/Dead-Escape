using UnityEngine;
using UnityEngine.AI;

public class ZombieAI : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform _player;
    [SerializeField] private Animator _anim;
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private Collider _collider;

    [Header("Distance Settings")]
    [SerializeField] private float _detectDistance = 15f;
    [SerializeField] private float _runDistance = 7f;
    [SerializeField] private float _attackDistance = 2f;

    [Header("Speed")]
    [SerializeField] private float _walkSpeed = 2f;
    [SerializeField] private float _runSpeed = 4f;

    [Header("Wander")]
    [SerializeField] private float _wanderRadius = 10f;
    [SerializeField] private float _wanderTimer = 5f;

    [Header("Attack")]
    [SerializeField] private float _attackCooldown = 2f;
    [SerializeField] private int _damage = 10;

    [Header("Health")]
    [SerializeField] private int _maxHealth = 100;

    private int _currentHealth;
    private float _attackTimer;
    private float _wanderTime;

    private bool _isDead;
    private bool _hasDetectedPlayer;

    private PlayerHealth _playerHealth;

    private void Start()
    {
        _currentHealth = _maxHealth;

        if (_player == null)
        {
            GameObject playerObj = GameObject.FindGameObjectWithTag("Player");

            if (playerObj != null)
            {
                _player = playerObj.transform;
            }
        }

        if (_player != null)
        {
            _playerHealth = _player.GetComponent<PlayerHealth>();
        }
    }

    private void Update()
    {
        if (_isDead) return;
        if (_player == null) return;

        float distance = Vector3.Distance(transform.position, _player.position);

        if (!_hasDetectedPlayer && distance <= _detectDistance)
        {
            _hasDetectedPlayer = true;
        }

        if (!_hasDetectedPlayer)
        {
            Wander();
            return;
        }

        if (distance <= _attackDistance)
        {
            Attack();
        }
        else if (distance <= _runDistance)
        {
            Chase(_runSpeed, 1f);
        }
        else
        {
            Chase(_walkSpeed, 0.5f);
        }
    }

    private void Chase(float speed, float animSpeed)
    {
        _agent.isStopped = false;
        _agent.speed = speed;
        _agent.SetDestination(_player.position);

        _anim.SetFloat("Speed", animSpeed);
    }

    private void Wander()
    {
        _wanderTime += Time.deltaTime;

        if (_wanderTime >= _wanderTimer)
        {
            Vector3 newPos = RandomNavSphere(transform.position, _wanderRadius);
            _agent.SetDestination(newPos);

            _wanderTime = 0f;
        }

        _agent.isStopped = false;
        _agent.speed = _walkSpeed;

        _anim.SetFloat("Speed", 0.5f);
    }

    private Vector3 RandomNavSphere(Vector3 origin, float distance)
    {
        Vector3 randDirection = Random.insideUnitSphere * distance;
        randDirection += origin;

        NavMeshHit navHit;

        NavMesh.SamplePosition(randDirection, out navHit, distance, NavMesh.AllAreas);

        return navHit.position;
    }

    private void Attack()
    {
        _agent.isStopped = true;

        _anim.SetFloat("Speed", 0f);

        _attackTimer += Time.deltaTime;

        if (_attackTimer >= _attackCooldown)
        {
            _attackTimer = 0f;

            _anim.SetTrigger("Attack");

            if (_playerHealth != null)
            {
                _playerHealth.TakeDamage(_damage);
            }
        }
    }

    public void TakeDamage(int damage)
    {
        if (_isDead) return;

        _currentHealth -= damage;

        if (_currentHealth <= 0)
        {
            Die();
        }
        else
        {
            _anim.SetTrigger("GetHit");
        }
    }
    public void HearNoise(Vector3 noisePosition)
    {
        if (_isDead) return;

        _hasDetectedPlayer = true;

        _agent.isStopped = false;
        _agent.SetDestination(noisePosition);
    }
    private void Die()
    {
        _isDead = true;

        ZombieLife _zombieLife = GetComponent<ZombieLife>();

        if (_zombieLife != null)
        {
            _zombieLife.NotifyDeath();
        }

        _agent.isStopped = true;
        _agent.enabled = false;

        _collider.enabled = false;

        _anim.SetTrigger("Die");

        Destroy(gameObject, 6f);
    }
}
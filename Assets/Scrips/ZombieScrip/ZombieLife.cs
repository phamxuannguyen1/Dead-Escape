using UnityEngine;

public class ZombieLife : MonoBehaviour
{
    private ZombieSpawner _spawner;
    private ZombieAI _zombieAI;
    private bool _isDeadCalled;

    private void Awake()
    {
        _zombieAI = GetComponent<ZombieAI>();
    }

    public void SetSpawner(ZombieSpawner spawner)
    {
        _spawner = spawner;
    }

    public void NotifyDeath()
    {
        if (_isDeadCalled) return;

        _isDeadCalled = true;

        if (_spawner != null)
        {
            _spawner.ZombieDied();
        }
    }
}
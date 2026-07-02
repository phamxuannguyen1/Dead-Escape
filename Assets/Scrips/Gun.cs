using UnityEngine;

public class Gun : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Camera _cam;

    [Header("Gun Settings")]
    [SerializeField] private float _range = 50f;
    [SerializeField] private int _damage = 25;

    [Header("Reload Settings")]
    [SerializeField] private float _reloadTime = 1.2f;

    private bool _isReloading;

    void Update()
    {
        if (_isReloading) return;

        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }
    }

    void Shoot()
    {
        if (GlobalAmmo._currentMagazine <= 0)
        {
            return;
        }

        GlobalAmmo._currentMagazine--;

        RaycastHit hit;
        Vector3 direction = _cam.transform.forward;

        Debug.DrawRay(_cam.transform.position, direction * _range, Color.red, 1f);

        if (Physics.Raycast(_cam.transform.position, direction, out hit, _range))
        {
            ZombieAI zombie = hit.collider.GetComponentInParent<ZombieAI>();

            if (zombie != null)
            {
                zombie.TakeDamage(_damage);
            }
        }
    }

    void Reload()
    {
        if (GlobalAmmo._ammoCout <= 0) return;
        if (GlobalAmmo._currentMagazine >= GlobalAmmo._maxMagazine) return;

        int needAmmo = GlobalAmmo._maxMagazine - GlobalAmmo._currentMagazine;

        if (GlobalAmmo._ammoCout >= needAmmo)
        {
            GlobalAmmo._currentMagazine += needAmmo;
            GlobalAmmo._ammoCout -= needAmmo;
        }
        else
        {
            GlobalAmmo._currentMagazine += GlobalAmmo._ammoCout;
            GlobalAmmo._ammoCout = 0;
        }
    }
}
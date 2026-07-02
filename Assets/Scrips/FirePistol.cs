using System.Collections;
using UnityEngine;

public class FirePistol : MonoBehaviour
{
    [SerializeField] private GameObject _theGun;
    [SerializeField] private GameObject _theBullet;
    [SerializeField] private AudioSource _gunfire;

    private bool _isFiring = false;

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && GlobalAmmo._currentMagazine >= 1 && !_isFiring)
        {
            _isFiring = true;

            

            StartCoroutine(firePistol1());
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }
    }

    IEnumerator firePistol1()
    {
        _theGun.GetComponent<Animation>().Play("PistolShotanim");

        _theBullet.SetActive(true);
        _theBullet.GetComponent<Animation>().Play("firefighteranim");

        _gunfire.Play();

        yield return new WaitForSeconds(0.5f);

        _theBullet.SetActive(false);

        _isFiring = false;
    }

    void Reload()
    {
        if (GlobalAmmo._ammoCout <= 0) return;

        int needAmmo = GlobalAmmo._maxMagazine - GlobalAmmo._currentMagazine;

        if (needAmmo <= 0) return;

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
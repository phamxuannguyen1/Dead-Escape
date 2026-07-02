using UnityEngine;

public class ZombieDead : MonoBehaviour
{
    public int _zombieHP;
    public GameObject _zombie;

    public void DamageZombie(int damage)
    {
        _zombieHP -= damage;
        
    }
    void Update()
    {
        if(_zombieHP <= 0) 
            {

            } 
    }
}

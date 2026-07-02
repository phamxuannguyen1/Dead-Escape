using UnityEngine;

public class GunNoise : MonoBehaviour
{
    [SerializeField] private float _noiseRadius = 25f;

    public void MakeNoise()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, _noiseRadius);

        foreach (Collider hit in hits)
        {
            ZombieAI zombie = hit.GetComponent<ZombieAI>();

            if (zombie != null)
            {
                zombie.HearNoise(transform.position);
            }
        }
    }
}
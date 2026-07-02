using UnityEngine;

public class ActionCasting : MonoBehaviour
{
    public static float DistanceFromTarget;
    [SerializeField] private float _totarget;
    
    void Update()
    {
        RaycastHit Hit;
        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out Hit))
        {
            _totarget = Hit.distance;
            DistanceFromTarget = _totarget;

        }
       
    }
    
}

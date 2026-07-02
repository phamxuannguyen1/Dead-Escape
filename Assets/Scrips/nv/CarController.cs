using UnityEngine;

public class CarController : MonoBehaviour
{
    [SerializeField] private CarPartsManager _carManager;
    [SerializeField] private float _speed = 10f;
    [SerializeField] private float _turnSpeed = 80f;

    private bool _canDrive;

    void Update()
    {
        if (_carManager.IsCarRepaired())
        {
            _canDrive = true;
        }

        if (!_canDrive) return;

        float move = Input.GetAxis("Vertical");
        float turn = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.forward * move * _speed * Time.deltaTime);
        transform.Rotate(Vector3.up * turn * _turnSpeed * Time.deltaTime);
    }
}
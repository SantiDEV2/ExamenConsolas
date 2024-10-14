using UnityEngine;

public class BallBounce : MonoBehaviour
{
    [SerializeField] private float _speed = 1f;
    [SerializeField] private float _initialSpeed = 1f;

    private void Start()
    {
        _speed = _initialSpeed;
    }


    private void OnCollisionEnter(Collision collision)
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        _speed += 0.1f;
        rb.velocity = rb.velocity.normalized * _speed;
    }

    public void ResetSpeed()
    {
        _speed = _initialSpeed;
    }
}

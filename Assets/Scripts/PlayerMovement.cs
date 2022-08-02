using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float turnSpeed = 20.0f;
    private Vector3 _movement;
    private Quaternion _rotation = Quaternion.identity;
    private Animator _animator;
    private Rigidbody _rigidBody;
    private AudioSource _audioSource;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidBody = GetComponent<Rigidbody>();
        _audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        _movement.Set(horizontal, 0.0f, vertical);
        _movement.Normalize(); //Normalizing means keeping the vector direction but reduce the magnitude to 1

        bool isWalking = !Mathf.Approximately(horizontal, 0.0f) || !Mathf.Approximately(vertical, 0.0f);
        _animator.SetBool("isWalking", isWalking);

        if(isWalking)
        {
            if(!_audioSource.isPlaying)
                _audioSource.Play();
        }
        else
        {
            _audioSource.Stop();
        }

        Vector3 desiredForward = Vector3.RotateTowards(transform.forward, _movement, turnSpeed * Time.deltaTime, 0.0f);
        _rotation = Quaternion.LookRotation(desiredForward);
    }

    private void OnAnimatorMove() {
        _rigidBody.MovePosition(_rigidBody.position + _movement * _animator.deltaPosition.magnitude);
        _rigidBody.MoveRotation(_rotation);
    }
}

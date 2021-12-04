using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [SerializeField] private float _speed;
    [SerializeField] private float _acceleration;

    [SerializeField] private float _rotationControl;

    private float MovY, MovX = 1.0f;
    private Rigidbody2D _rb2D;

    private void Awake() {
        _rb2D = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        if (Input.GetKey(KeyCode.Mouse0)) {
            MovY = 1;
        }
        else MovY = -.5f;
    }

    private void FixedUpdate() {
        Vector2 velocity = transform.right * (MovX * _acceleration);
        _rb2D.AddForce(velocity);

        float direction = Vector2.Dot(_rb2D.velocity, _rb2D.GetRelativeVector(Vector2.right));

        if (_acceleration > 0) {
            if (direction > 0) {
                _rb2D.rotation += MovY * _rotationControl * (_rb2D.velocity.magnitude / _speed);
            } else {
                _rb2D.rotation -= MovY * _rotationControl * (_rb2D.velocity.magnitude / _speed);
            }
        }
        float thrustForce = Vector2.Dot(_rb2D.velocity, _rb2D.GetRelativeVector(Vector2.down)) * 2.0f;
        Vector2 relForce = Vector2.up * thrustForce;
        _rb2D.AddForce(_rb2D.GetRelativeVector(relForce));

        if (_rb2D.velocity.magnitude > _speed) {
            _rb2D.velocity = _rb2D.velocity.normalized * _speed;
        }
    }

}
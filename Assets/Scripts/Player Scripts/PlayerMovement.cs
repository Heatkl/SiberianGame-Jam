using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] Camera _camera;

    private Rigidbody2D _myRigidbody;

    private Vector2 _movement;
    private Vector2 _mousePos;
    private float _angle;
    private void Start()
    {
        _myRigidbody = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        Run();
        GazeDirection();
    }
    private void Run()
    {
        float controlThrowX = Input.GetAxis("Horizontal");
        float controlThrowY = Input.GetAxis("Vertical");
        _movement = new Vector2(controlThrowX, controlThrowY).normalized;
        _movement *= _moveSpeed;
    }
    private void FixedUpdate()
    {
        _myRigidbody.velocity = _movement;
        _myRigidbody.rotation = _angle;
    }
    private void GazeDirection()
    {
        _mousePos = _camera.ScreenToWorldPoint(Input.mousePosition);
        Vector2 lookDir = _mousePos - _myRigidbody.position;
        _angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
    }
}

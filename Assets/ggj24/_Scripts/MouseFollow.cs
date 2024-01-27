using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MouseFollow : MonoBehaviour
{
    [SerializeField] float _speed = 5f; // Adjust the speed of movement
    private Vector3 _startPosition;

    public Vector3 StartPosition { get => _startPosition; set => _startPosition = value; }

    private void Start() 
    {
        _startPosition = transform.position;
    }
    void Update()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = Vector2.MoveTowards(transform.position, mousePosition, _speed * Time.deltaTime);
    }
}
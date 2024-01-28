using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class HandManager : MonoBehaviour
{
    [Header("Hands")]
    [SerializeField] MouseFollow _leftHand;
     [SerializeField] MouseFollow _rightHand;
    private MouseFollow _currentHand;

    [Header("Head")]
    [SerializeField] SpriteRenderer _head;
    [SerializeField] Vector3 _headMovVec;
    [SerializeField] float _headMovDuration = 3f;
    [SerializeField] int _headMovVibrato = 5;
    [SerializeField] float _headMovElasticity = .5f;

    // Start is called before the first frame update
    void Start()
    {
        _head.transform.DOPunchPosition(_headMovVec,_headMovDuration,_headMovVibrato,_headMovElasticity).SetLoops(-1);
        _currentHand = (Input.mousePosition.x >= Mathf.Epsilon) ? _rightHand : _leftHand;
    }

    // Update is called once per frame
    void Update()
    {
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if(mousePos.x >= Mathf.Epsilon && _currentHand == _leftHand)
        {
            SwitchHands();
        }

        if(mousePos.x < Mathf.Epsilon && _currentHand == _rightHand)
        {
            SwitchHands();
        }
    }

    private void SwitchHands()
    {
        _currentHand.enabled = false;
        _currentHand.transform.DOMove(_currentHand.StartPosition, 1f).SetAutoKill(false);

        _currentHand = (_currentHand == _leftHand) ? _rightHand : _leftHand;

        DOTween.Kill(_currentHand.transform);
        _currentHand.enabled = true;
        // Debug.Log("hand swicthed to:" + _currentHand.name);
    }
}
